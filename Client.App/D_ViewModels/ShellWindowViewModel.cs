using Client.D_Views;
//using Client.F_Common;
using Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
//using Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Ioc;
using Client.Services.Api;

namespace Client.D_ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        static IConfigurationService _configurationServiceInstance;


        private RequetesListViewModel _RequeteListeViewModel;

        public RequetesListViewModel RequeteListeViewModel
        {
            get { return _RequeteListeViewModel; }
            set { SetProperty(ref _RequeteListeViewModel, value); }
        }

        private ActionTabViewModel _ActionTabViewModel;
        public ActionTabViewModel ActionTabViewModel
        {
            get { return _ActionTabViewModel; }
            set { SetProperty(ref _ActionTabViewModel, value); }
        }

        public bool _IsPaginationOptionOn;
        public bool IsPaginationOptionOn
        {
            get { return _IsPaginationOptionOn; }
            set { SetProperty(ref _IsPaginationOptionOn, value); }
        }

       
        
        public ShellWindowViewModel( IConfigurationService configurationService, IContainerProvider containerProvider)
        {
            _configurationServiceInstance = configurationService;
            
            _ActionTabViewModel = containerProvider.Resolve<ActionTabViewModel>();
            _RequeteListeViewModel = containerProvider.Resolve<RequetesListViewModel>();
            IsPaginationOptionOn = false;
            PaginateMenuItemUncheckedCommand = new RelayCommand<string>(OnPaginateMenuItemUnCheckedRequested);
            PaginateMenuItemUnchecked += PaginateMenuItem_Unchecked;
            PaginateMenuItemCheckedCommand = new RelayCommand<string>(OnPaginateMenuItemCheckedRequested);
            PaginateMenuItemChecked += PaginateMenuItem_Checked;
        }

       


        public RelayCommand<string> PaginateMenuItemCheckedCommand { get; private set; }
        public event Action PaginateMenuItemChecked = delegate { };
        void OnPaginateMenuItemCheckedRequested(object parameter)
        {
            PaginateMenuItemChecked();
        }


        private void PaginateMenuItem_Checked()
        {
            _ActionTabViewModel.ActivatePagination();
        }

        public RelayCommand<string> PaginateMenuItemUncheckedCommand { get; private set; }
        public event Action PaginateMenuItemUnchecked = delegate { };

        void OnPaginateMenuItemUnCheckedRequested(object parameter)
        {
            PaginateMenuItemUnchecked();
        }

        private void PaginateMenuItem_Unchecked()
        {
            _ActionTabViewModel.DeActivatePagination();
        }
       
    }

}

/*
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
           if (tabItemTarget != null)
           {
               var tabItemSource = (TabItem)e.Data.GetData(typeof(TabItem));
               if (tabItemTarget != tabItemSource)
               {
                   int sourceIndex = actionTabViewModal.Tabs.IndexOf((QueryView)tabItemSource.DataContext);
                   int targetIndex = actionTabViewModal.Tabs.IndexOf((QueryView)tabItemTarget.DataContext);
                   var src = actionTabViewModal.Tabs[sourceIndex];
                   var target = actionTabViewModal.Tabs[targetIndex];

                   if (sourceIndex > targetIndex)
                   {
                       actionTabViewModal.Tabs.Insert(targetIndex, src);
                       actionTabViewModal.Tabs.RemoveAt(sourceIndex + 1);
                   }
                   else
                   {
                       if (targetIndex == actionTabViewModal.Tabs.Count - 1)
                       {
                           actionTabViewModal.Tabs.Add(src);
                       }
                       else
                       {
                           actionTabViewModal.Tabs.Insert(targetIndex + 1, src);
                       }
                       actionTabViewModal.Tabs.RemoveAt(sourceIndex);
                   }
                   actionTabs.SelectedIndex = targetIndex;
               }
           }
       }
       */
