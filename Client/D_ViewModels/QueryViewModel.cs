using Client.D_Views;
//using Client.F_Common;
using Dapper;
using Interactivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Mvvm;
using Prism.Regions;
using Client.DataModels.C_Models;
using Prism.Services.Dialogs;
using Prism.Ioc;
using Client.Services.Api;
using Microsoft.Windows.Themes;
using Prism.Events;
using Client.Core.Events;
using System.Windows.Controls;
using System.ComponentModel;
using TabControlRegion.Core;
//using Unity;


namespace Client.D_ViewModels
{
    public class QueryViewModel : ViewModelBase
    {
        public Requete Request { get; set; }
        IEventAggregator _ea;

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
                    PaginateInfosVisible = IsPaginateOn && PaginationOption && PageCount > 1;
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

        private Dictionary<string, int> colDisplayIndex = new Dictionary<string, int>();

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
        public static bool _PaginationOption;
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
            ExecuteRefeshRequestedCommand = new RelayCommand<DataGrid>(OnExecuteRefeshRequested);
            GridViewColumnHeaderClickedHandlerCommand = new RelayCommand<RoutedEventArgs>(OnGridViewColumnHeaderClickedHandlerRequested);
            PageSizeTextBoxKeyDownCommand = new RelayCommand<KeyEventArgs>(OnPageSizeTextBoxKeyDownRequested);
            ExecutePreviousPageCommand = new RelayCommand<string>(OnExecutePreviousPageRequested);
            ExecuteNextPageCommand = new RelayCommand<string>(OnExecuteNextPageRequested);

            CurrentPageKeyDown += CurrentPage_KeyDown;
            PaginateCheckBoxUnChecked += PaginateCheckBox_Unchecked;
            PaginateCheckBoxChecked += PaginateCheckBox_Checked;
            ExecuteRefeshRequested += Execute_Refesh;
            GridViewColumnHeaderClickedHandler += GridViewColumnHeader_ClickedHandler;
            PageSizeTextBoxKeyDown += PageSizeTextBox_KeyDown;
            ExecutePreviousPage += Execute_PreviousPage;
            ExecuteNextPage += Execute_NextPage;
            PropertyChanged += OnPropertyChanged;

            _DialogService = containerProvider.Resolve<IDialogService>();
            CurrentPage = 1;
            PageSize = IsPaginateOn ? DefaultPageSize : int.MaxValue;
            _ea.GetEvent<NavigationOptionEvent>().Subscribe(NavigationOptionMessageReceived);
        }
        private void NavigationOptionMessageReceived(bool message)
        {
            PaginationOption = message;
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
        public RelayCommand<DataGrid> ExecuteRefeshRequestedCommand { get; private set; }
        public event Action<DataGrid> ExecuteRefeshRequested = delegate { };

        void OnExecuteRefeshRequested(DataGrid parameter)
        {
            ExecuteRefeshRequested(parameter);
        }
        public void Execute_Refesh(DataGrid datagrid)
        {
            for (int i = 0; i < ResultDataView.Table.Columns.Count; ++i)
            {
                colDisplayIndex[datagrid.Columns[i].SortMemberPath] = datagrid.Columns[i].DisplayIndex;
                //colHeader[gridContainingRequeteResults.Columns[i].SortMemberPath] = (string)gridContainingRequeteResults.Columns[i].Header;
            }
            ExecuteRequest(null, null);
        }

        public RelayCommand<RoutedEventArgs> GridViewColumnHeaderClickedHandlerCommand { get; private set; }
        public event Action<RoutedEventArgs> GridViewColumnHeaderClickedHandler = delegate { };
        void OnGridViewColumnHeaderClickedHandlerRequested(RoutedEventArgs args)
        {
            GridViewColumnHeaderClickedHandler(args);
        }

        void GridViewColumnHeader_ClickedHandler(RoutedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            var headerClicked = GetTargetDataGridColumnHeader(e.OriginalSource);// as DataGridColumnHeader;
            if (headerClicked != null)
            {
                var p = new DialogParameters();
                p.Add("oldColumnName", (string)headerClicked.Column.Header);
                _DialogService.ShowDialog("InputColumnNameDlg", p, (IDialogResult obj) =>
                {

                    if (obj.Result == ButtonResult.OK)
                    {
                        headerClicked.Column.Header = obj.Parameters.GetValue<string>("newColumnName");
                        colHeader[headerClicked.Column.SortMemberPath] = (string)headerClicked.Column.Header;
                    }
                });
            }
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
            if(int.TryParse((args.Source as TextBox).Text, out size))
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

        private DataGridColumnHeader GetTargetDataGridColumnHeader(object originalSource)
        {
            var current = originalSource as DependencyObject;

            while (current != null)
            {
                var tabItem = current as DataGridColumnHeader;
                if (tabItem != null)
                {
                    return tabItem;
                }
                /*if (current is DataGridHeaderBorder dataGridHeaderBorder)
                {

                    var candidate = dataGridHeaderBorder.TemplatedParent as DataGridColumnHeader;
                    if (candidate != null)
                    {
                        return candidate;
                    }
                }
                */
                current = VisualTreeHelper.GetParent(current);
            }

            return null;
        }


        public void ExecuteRequest(object sender, RoutedEventArgs e)
        {
            LastExecuted = "Last Execution date : " + DateTime.UtcNow.ToLongDateString() + " " + DateTime.UtcNow.ToLongTimeString();
            IEnumerable<dynamic> queryResult = _containerProvider.Resolve<IRequetesExecutionService>().ExecuteRequete(Request);
            CurrentPage = 1;
            PageCount = 1;
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

        public void AutoGeneratedColumns(DataGrid grid)
        {

            if (Request.ColNames != null)
            {
                for (int i = 0; i < Request.ColNames.Length; ++i)
                {
                    //grid.Columns[i].Header = Request.ColNames[i];
                }
            }

            for (int i = 0; i < grid.Columns.Count; ++i)
            {
                if (colHeader.ContainsKey(grid.Columns[i].SortMemberPath))
                {
                    grid.Columns[i].Header = colHeader[grid.Columns[i].SortMemberPath];
                }
            }
            if (colDisplayIndex.Count == grid.Columns.Count)
            {
                for (int i = 0; i < grid.Columns.Count; ++i)
                {
                    if (colDisplayIndex.ContainsKey(grid.Columns[i].SortMemberPath))
                    {
                        grid.Columns[i].DisplayIndex = colDisplayIndex[grid.Columns[i].SortMemberPath];
                    }
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
    }
}