using Client.D_ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Client.D_Views
{
    /// <summary>
    /// Logique d'interaction pour ActionTabView.xaml
    /// </summary>
    public partial class ActionTabView : UserControl
    {
        public ActionTabView()
        {
            InitializeComponent();
        }
       private void TabItem_Drag(object sender, MouseEventArgs e)
       {
           var tabItem = GetTargetTabItem(e.OriginalSource);

           if (tabItem == null)
               return;

           if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
               DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
       }

       private TabItem GetTargetTabItem(object originalSource)
       {
           var current = originalSource as DependencyObject;

           while (current != null)
           {
               var tabItem = current as TabItem;
               if (tabItem != null)
               {
                   return tabItem;
               }

               current = VisualTreeHelper.GetParent(current);
           }

           return null;
       }

       private void TabItem_Drop(object sender, DragEventArgs e)
       {

           var tabItemTarget = GetTargetTabItem(e.OriginalSource);
            var actionTabViewModel = DataContext as ActionTabViewModel;
           
           if (tabItemTarget != null)
           {
               var tabItemSource = (TabItem)e.Data.GetData(typeof(TabItem));
               if (tabItemTarget != tabItemSource)
               {
                     int sourceIndex = actionTabs.Items.IndexOf(tabItemSource.Content);
                   int targetIndex = actionTabs.Items.IndexOf(tabItemTarget.Content);
                    //var src = actionTabViewModal.Tabs[sourceIndex];
                    //var target = actionTabViewModal.Tabs[targetIndex];
                    actionTabViewModel.TabItem_Drop(actionTabs, tabItemSource, sourceIndex, tabItemTarget, targetIndex);

                    
                   actionTabs.SelectedIndex = targetIndex;
                }
            }
       }
    }
}
