//using Client.F_Common;
using Interactivity;
using System;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Commands;

namespace Client.D_ViewModels
{
    public class InputColumnNameDlgViewModel : BindableBase, IDialogAware
    {
        private string _OldColName;
        private IRegionManager _regionManager;

        public string OldColName 
        {
            get { return _OldColName; }
            set { SetProperty(ref _OldColName, value); }
        }
        private string _NewColumnName;
        public string NewColumnName
        {
            get { return _NewColumnName; }
            set { SetProperty(ref _NewColumnName, value); }
        }
        public bool DialogResult { get; set; }
        public InputColumnNameDlgViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            //OldColName = oldColumnName;
            CloseCommand = new DelegateCommand(OnDialogClosed);
            OKCommand = new DelegateCommand(OnOKPressedRequested);
            OKPressed += OKButton_Click;
            CancelCommand = new DelegateCommand(OnDialogCanceled);

            //OKPressed += () => Close();
            //CancelPressed += () => Close();
            //CancelPressed += CancelButton_Click;
        }

        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand OKCommand { get; set; }

        public event Action OKPressed = delegate { };
        void OnOKPressedRequested()
        {
            OKPressed();
        }

        public DelegateCommand CancelCommand { get; private set; }

        public string Title => "Column Rename :";

        public event Action CancelPressed = delegate { };
        public event Action<IDialogResult> RequestClose;

        void OnCancelPressedRequested(object parameter)
        {
            CancelPressed();
        }

        
        private void OKButton_Click()
        {
            var parameters = new DialogParameters();
            if (NewColumnName != null && NewColumnName != "")
            {

                parameters.Add("newColumnName", NewColumnName);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameters));
            }
            //DialogResult = NewColumnName != null && NewColumnName != "";
        }
        public bool CanCloseDialog()
        {
            return true;// NewColumnName != null && NewColumnName != "";
        }

        public void OnDialogClosed()
        {
            var parameters = new DialogParameters();
            /*
            if (NewColumnName != null && NewColumnName != "") {

                parameters.Add("newColumnName", NewColumnName);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameters));
            }
            else
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel, new DialogParameters()));
            }
            */
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel, new DialogParameters()));


        }

        public void OnDialogCanceled()
        {
            //var parameters = new DialogParameters();
            //parameters.Add("newColumnName", NewColumnName);
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel, new DialogParameters()));
        }
        

        public void OnDialogOpened(IDialogParameters parameters)
        {
           OldColName = parameters.GetValue<string>("oldColumnName");
           //RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameters));
        }
    }
}