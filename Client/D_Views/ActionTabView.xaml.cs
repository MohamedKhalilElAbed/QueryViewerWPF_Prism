using Client.D_ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
    }
}
