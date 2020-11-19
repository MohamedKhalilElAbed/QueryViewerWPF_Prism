using Client.Core.Events;
using Client.Module;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Client.GridAction
{
    public class DataGridColumnHeaderDoubleClickAction : TriggerAction<DataGrid>
    {
        private IDialogService _dialogService;
        private IEventAggregator _ea;
        public DataGridColumnHeaderDoubleClickAction()
        {

            _dialogService = QueryViewerModule.ContainerProvider.Resolve<IDialogService>();// _DialogService;
            _ea = QueryViewerModule.ContainerProvider.Resolve<IEventAggregator>();
        }
        protected override void Invoke(object parameter)
        {
            var args = parameter as MouseEventArgs;
            if (args == null)
                return;

            
            var headerClicked = FindParent<DataGridColumnHeader>(args.OriginalSource as DependencyObject);
            if (headerClicked == null)
                return;

            var tabControl = FindParent<TabControl>(headerClicked as DependencyObject);
            if (tabControl == null)
                return;
            if (headerClicked != null)
            {
                var p = new DialogParameters();
                p.Add("oldColumnName", (string)headerClicked.Column.Header);
                //var dialogService = 

                var grid = FindParent<Grid>(args.OriginalSource as DependencyObject);
                if (grid == null)
                    return;
                grid = FindParent<Grid>(grid as DependencyObject);
                if (grid == null)
                    return;
                IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
                if (region == null)
                    return;
                //object view = region.GetView("QueryView");
                _dialogService.ShowDialog("InputColumnNameDlg", p, (IDialogResult obj) =>
                {

                    if (obj.Result == ButtonResult.OK)
                    {
                        headerClicked.Column.Header = obj.Parameters.GetValue<string>("newColumnName");
                        _ea.GetEvent<ColumnRenameEvent>().Publish((grid.DataContext, headerClicked.Column.SortMemberPath, (string)headerClicked.Column.Header));
                    }
                });
            }
        }

        static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            var parent = parentObject as T;
            if (parent != null)
                return parent;

            return FindParent<T>(parentObject);
        }
    }
}
