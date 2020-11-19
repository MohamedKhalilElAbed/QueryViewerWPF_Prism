using Prism.Regions;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace TabControlRegion
{
    public class TabitemDropAction : TriggerAction<StackPanel>
    {
        protected override void Invoke(object parameter)
        {
            var args = parameter as DragEventArgs;
            if (args == null)
                return;

            var tabItemTarget = FindParent<TabItem>(args.OriginalSource as DependencyObject);
            if (tabItemTarget == null)
                return;

            var tabControl = FindParent<TabControl>(tabItemTarget);
            if (tabControl == null)
                return;

            IRegion region = RegionManager.GetObservableRegion(tabControl).Value;
            if (region == null)
                return;
            if (tabItemTarget != null 
                && region.Views.Contains(tabItemTarget.Content))
            {
                var tabItemSource = (TabItem)args.Data.GetData(typeof(TabItem));
                var tabsList = region.Views.ToList();
                if (tabItemTarget != tabItemSource && region.Views.Contains(tabItemSource.Content))
                {
                    int sourceIndex = tabsList.IndexOf(tabItemSource.Content);
                    int targetIndex = tabsList.IndexOf(tabItemTarget.Content);
                    if (sourceIndex > targetIndex)
                    {
                        for (int i = 0; i < tabsList.Count; ++i)
                        {
                            region.Remove(tabsList[i]);
                        }
                        for (int i = 0; i < targetIndex; ++i)
                        {
                            region.Add(tabsList[i]);
                        }
                        region.Add(tabsList[sourceIndex]);
                        for (int i = targetIndex; i < sourceIndex; ++i)
                        {
                            region.Add(tabsList[i]);
                        }
                        for (int i = sourceIndex + 1; i < tabsList.Count; ++i)
                        {
                            region.Add(tabsList[i]);
                        }
                    }
                    else
                    {

                        for (int i = 0; i < tabsList.Count; ++i)
                        {
                            region.Remove(tabsList[i]);
                        }
                        for (int i = 0; i < sourceIndex; ++i)
                        {
                            region.Add(tabsList[i]);
                        }
                        for (int i = sourceIndex + 1; i < targetIndex + 1; ++i)
                        {
                            region.Add(tabsList[i]);
                        }
                        region.Add(tabsList[sourceIndex]);
                        for (int i = targetIndex + 1; i < tabsList.Count; ++i)
                        {
                            region.Add(tabsList[i]);
                        }
                    }
                    region.Activate(tabsList[sourceIndex]);
                }
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
