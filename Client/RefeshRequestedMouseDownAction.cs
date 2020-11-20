using Client.Core.Events;
using Client.D_ViewModels;
using Client.Module;
using Prism.Events;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using Prism.Ioc;
using System.Windows.Media.Imaging;

namespace Client.GridAction
{
    public class RefeshRequestedMouseDownAction : TriggerAction<Image>
    {
        private IEventAggregator _ea;
        public RefeshRequestedMouseDownAction()
        {
            _ea = QueryViewerModule.ContainerProvider.Resolve<IEventAggregator>();
        }
        protected override void Invoke(object parameter)
        {
            var args = parameter as RoutedEventArgs;
            if (args == null)
                return;

            RotateImage(args);

            var grid = FindParent<Grid>(args.OriginalSource as DependencyObject);
            if (grid == null)
                return;
            DataGrid datagrid = FindChild<DataGrid>(grid as DependencyObject);
            if (datagrid == null)
                return;
            var queryViewModel = grid.DataContext as QueryViewModel;

            for (int i = 0; i < datagrid.Columns.Count; ++i)
            {
                queryViewModel.colDisplayIndex[datagrid.Columns[i].SortMemberPath] = datagrid.Columns[i].DisplayIndex;
            }
            _ea.GetEvent<RefreshEvent>().Publish((datagrid.DataContext));
        }

        private static void RotateImage(RoutedEventArgs args)
        {
            Image im = args.OriginalSource as Image;
            var Original = (BitmapImage)im.Source;
            var Rotated = new BitmapImage();
            Rotated.BeginInit();
            Rotated.UriSource = Original.UriSource;
            Rotated.Rotation = Rotation.Rotate270;
            Rotated.EndInit();
            //im.Source = Rotated;// = Rotated;
        }

        static T FindChild<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            Stack<DependencyObject> toVisit = new Stack<DependencyObject>();
            toVisit.Push(dependencyObject);
            while(toVisit.Count > 0)
            {
                DependencyObject current = toVisit.Pop();
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); ++i)
                {
                    DependencyObject currentChild = VisualTreeHelper.GetChild(current, i);
                    var currentChildAsT = currentChild as T;
                    if (currentChildAsT != null)
                        return currentChildAsT;
                    else
                        toVisit.Push(currentChild);
                }
            }
            return null;
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
