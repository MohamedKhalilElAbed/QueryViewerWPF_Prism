using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Ioc;
using Client.Services.Api;
using Prism.Events;
using Client.Core.Events;
using System.Windows.Controls;
using System.ComponentModel;
using TabControlRegion.Core;


namespace Client.D_ViewModels
{
    public class QueryViewModel : ViewModelBase
    {
        private static int DefaultPageSize = 2;

        protected void OnPropertyChanged(object src, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case "PageCount":
                    PaginateInfosVisible = _PageCount > 1;
                    break;
                case "PaginationOption":

                    IsPaginateOn = _PaginationOption;
                    PageSize = IsPaginateOn ? DefaultPageSize : int.MaxValue;
                    PageCount = ComputePageCount();
                    PaginateInfosVisible = IsPaginateOn && PaginationOption && PageCount > 1;
                    if (columns != null)
                        FillPage();
                    break;
                case "IsPaginateOn":
                    PaginateInfosVisible = IsPaginateOn && PaginationOption && PaginationOption && PageCount > 1;
                    break;
                default:
                    break;
            }

        }
        List<object[]> valuesCache;

        public string[] columns;

        public Dictionary<string, int> colDisplayIndex = new Dictionary<string, int>();

        public Dictionary<string, string> colHeader = new Dictionary<string, string>();

        private string _LastExecuted;
        public string LastExecuted
        {
            get { return _LastExecuted; }
            set { SetProperty(ref _LastExecuted, value); }
        }

        private int _TotalNumberOfRows;
        public int TotalNumberOfRows
        {
            get { return _TotalNumberOfRows; }
            set { SetProperty(ref _TotalNumberOfRows, value); }
        }

        private int _PageSize;
        public int PageSize
        {
            get { return _PageSize; }
            set { SetProperty(ref _PageSize, value); }
        }
        private int _CurrentPage;
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { SetProperty(ref _CurrentPage, value); }
        }
        private int _PageCount;
        public int PageCount
        {
            get { return _PageCount; }
            set { SetProperty(ref _PageCount, value); }
        }
        private bool _HasPreviousPage;
        public bool HasPreviousPage
        {
            get { return _HasPreviousPage; }
            set { SetProperty(ref _HasPreviousPage, value); }
        }
        private bool _HasNextPage;
        public bool HasNextPage
        {
            get { return _HasNextPage; }
            set { SetProperty(ref _HasNextPage, value); }
        }
        private DataView _ResultDataView;
        public DataView ResultDataView
        {
            get { return _ResultDataView; }
            set { SetProperty(ref _ResultDataView, value); }
        }
        public bool _PaginationOption;
        public bool PaginationOption
        {
            get { return _PaginationOption; }
            set
            {
                SetProperty(ref _PaginationOption, value); if (value != _PaginationOption)
                {
                    if (value)
                        ActivatePagination();
                    else
                    {
                        DeActivatePagination();
                    }
                }
            }
        }

        public bool _IsPaginateOn;
        public bool IsPaginateOn
        {
            get { return _IsPaginateOn; }
            set { SetProperty(ref _IsPaginateOn, value); }
        }

        private bool _PaginateInfosVisible;
        public bool PaginateInfosVisible
        {
            get { return _PaginateInfosVisible; }
            set { SetProperty(ref _PaginateInfosVisible, value); }
        }
        private IDialogService _DialogService;
        public QueryViewModel(IRegionManager regionManager, IContainerProvider containerProvider, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _ea = ea;
            CurrentPageKeyDownCommand = new RelayCommand<KeyEventArgs>(OnCurrentPageKeyDownRequested);
            PaginateCheckBoxUnCheckedCommand = new RelayCommand<string>(OnPaginateCheckBoxUnCheckedRequested);
            PaginateCheckBoxCheckedCommand = new RelayCommand<string>(OnPaginateCheckBoxCheckedRequested);
            PageSizeTextBoxKeyDownCommand = new RelayCommand<KeyEventArgs>(OnPageSizeTextBoxKeyDownRequested);
            ExecutePreviousPageCommand = new RelayCommand<string>(OnExecutePreviousPageRequested);
            ExecuteNextPageCommand = new RelayCommand<string>(OnExecuteNextPageRequested);

            CurrentPageKeyDown += CurrentPage_KeyDown;
            PaginateCheckBoxUnChecked += PaginateCheckBox_Unchecked;
            PaginateCheckBoxChecked += PaginateCheckBox_Checked;
            PageSizeTextBoxKeyDown += PageSizeTextBox_KeyDown;
            ExecutePreviousPage += Execute_PreviousPage;
            ExecuteNextPage += Execute_NextPage;
            PropertyChanged += OnPropertyChanged;

            _DialogService = containerProvider.Resolve<IDialogService>();
            CurrentPage = 1;
            PaginationOption = true;
            _ea.GetEvent<NavigationOptionEvent>().Subscribe(NavigationOptionMessageReceived);
            _ea.GetEvent<ColumnRenameEvent>().Subscribe(ColumnRenameMessageReceived, ((object o,  string s1, string   s2) arg) => arg.o == this);
            _ea.GetEvent<RefreshEvent>().Subscribe(Execute_Refesh, (object o) => o == this);

        }
        private void NavigationOptionMessageReceived(bool message)
        {
            PaginationOption = message;
        }
        private void ColumnRenameMessageReceived((object, string , string) arg)
        {

            (object content,string label, string nouveauNom) = arg;
            colHeader[label] = nouveauNom;
        }
        private IRegionManager _regionManager;
        private IContainerProvider _containerProvider;

        public RelayCommand<KeyEventArgs> CurrentPageKeyDownCommand { get; private set; }
        public event Action<KeyEventArgs> CurrentPageKeyDown = delegate { };
        void OnCurrentPageKeyDownRequested(KeyEventArgs keyEventArgs)
        {
            CurrentPageKeyDown(keyEventArgs);
        }
        private void CurrentPage_KeyDown(KeyEventArgs e)
        {
            //use seperate input validator .
            if (CurrentPage < 1 || CurrentPage > PageCount)
                return;
            FillPage();
            /* in the validator int pagenum; if (int.TryParse(currentPage.Text, out pagenum)) if (pagenum >= 1 && pagenum <= pageCount)*/
        }
        public RelayCommand<string> PaginateCheckBoxCheckedCommand { get; private set; }
        public event Action PaginateCheckBoxChecked = delegate { };
        void OnPaginateCheckBoxCheckedRequested(object parameter)
        {
            PaginateCheckBoxChecked();
        }

        private void PaginateCheckBox_Checked()
        {
            SetPaginationPropertiesOn();
            FillPage();
        }

        public RelayCommand<string> PaginateCheckBoxUnCheckedCommand { get; private set; }
        public event Action PaginateCheckBoxUnChecked = delegate { };

        void OnPaginateCheckBoxUnCheckedRequested(object parameter)
        {
            PaginateCheckBoxUnChecked();
        }
        private void PaginateCheckBox_Unchecked()
        {
            SetPaginationPropertiesOff();
            FillPage();
        }
        public void Execute_Refesh(object o)
        {
            ExecuteRequest(null, null);
        }

        private void renameCompete(IDialogResult obj)
        {
            throw new NotImplementedException();
        }

        public RelayCommand<KeyEventArgs> PageSizeTextBoxKeyDownCommand { get; private set; }
        public event Action<bool, int> PageSizeTextBoxKeyDown = delegate { };
        void OnPageSizeTextBoxKeyDownRequested(KeyEventArgs args)
        {
            
            if (args.Key != Key.Enter)
                return;
            int size;
            if(int.TryParse((args.Source as TextBox).Text, out size) && size > 0)
                PageSizeTextBoxKeyDown(true, size);
        }

        private void PageSizeTextBox_KeyDown(bool modifyDefaultPageSize , int size)
        {
            PageSize = size;
            CurrentPage = 1;
            CurrentPage = 1;
            PageCount = ComputePageCount();
            if (modifyDefaultPageSize)
                DefaultPageSize = PageSize;
            FillPage();
            /*In the Validator  int pageSizeEntered; if (int.TryParse(pageSizeTextBox.Text, out pageSizeEntered)) if (pageSizeEntered >= 1)
            */
        }

        public RelayCommand<string> ExecutePreviousPageCommand { get; private set; }

        public event Action ExecutePreviousPage = delegate { };
        void OnExecutePreviousPageRequested(object parameter)
        {
            ExecutePreviousPage();
        }

        private void Execute_PreviousPage()
        {
            if (CurrentPage == 1)
                return;
            --CurrentPage;
            FillPage(); // TODO : check it if it is necessary since Current page value change is bound to fill page
        }
        public RelayCommand<string> ExecuteNextPageCommand { get; private set; }

        public event Action ExecuteNextPage = delegate { };
        void OnExecuteNextPageRequested(object parameter)
        {
            ExecuteNextPage();
        }

        private void Execute_NextPage()
        {
            if (CurrentPage == PageCount)
                return;
            ++CurrentPage;
            FillPage();
        }

        internal void ActivatePagination()
        {
            PaginationOption = true;
            if (!IsPaginateOn)
            {
                IsPaginateOn = true;
                PageSize = DefaultPageSize;
                PageSizeTextBoxKeyDown(false, PageSize);
            }

        }
        internal void DeActivatePagination()
        {

            PaginationOption = false;
            if (IsPaginateOn)
            {
                IsPaginateOn = false;
                //PageSize = int.MaxValue;

                //PageSizeTextBoxKeyDown(false);
            }

        }
        private void SetPaginationPropertiesOff()
        {
            PageSize = int.MaxValue;
            CurrentPage = 1;
            PageCount = 1;
            IsPaginateOn = false;
        }

        private void SetPaginationPropertiesOn()
        {
            PageSize = DefaultPageSize;
            CurrentPage = 1;
            PageCount = ComputePageCount();
            IsPaginateOn = true;
        }

        public override void ExecuteRequest(object sender, RoutedEventArgs e)
        {
            LastExecuted = "Last Execution date : " + DateTime.UtcNow.ToLongDateString() + " " + DateTime.UtcNow.ToLongTimeString();
            IEnumerable<dynamic> queryResult = _containerProvider.Resolve<IRequetesExecutionService>().ExecuteRequete(Request);
            CurrentPage = 1;
            PageCount = 1;
            TotalNumberOfRows = queryResult.Count();
            if (queryResult.Count() == 0)
            {
                return;
            }
            PageCount = ComputePageCount();
            IDictionary<string, object> firstElement = queryResult.ElementAt(0);
            columns = firstElement.Keys.ToArray();

            valuesCache = queryResult.Select(d => ((IDictionary<string, object>)d).Values.ToArray()).AsList<object[]>();
            CurrentPage = 1;
            FillPage(); // TODo ChIfNe
        }
        private int ComputePageCount()
        {
            return TotalNumberOfRows / PageSize + (TotalNumberOfRows % PageSize == 0 ? 0 : 1);
        }

        private void FillPage()
        {
            DataTable datatable = new DataTable();
            for (int i = 0; i < columns.Length; ++i)
                datatable.Columns.Add(columns[i]);

            datatable.BeginLoadData();
            for (int i = (CurrentPage - 1) * PageSize; i < Math.Min(valuesCache.Count, (CurrentPage) * PageSize); ++i)
            {
                datatable.LoadDataRow(valuesCache[i], true);
            }
            datatable.EndLoadData();
            ResultDataView = datatable.DefaultView;
            HasPreviousPage = CurrentPage > 1;
            HasNextPage = CurrentPage < PageCount;
        }
    }
}



/*
        private void CurrentPage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
          int pagenum;
          e.Handled = int.TryParse(currentPage.Text, out pagenum) && pagenum >= 1 && pagenum <= pageCount;
        }
        */