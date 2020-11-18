//using Client.F_Common;
using Interactivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

using Prism.Mvvm;
using Prism.Regions;
using Client.DataModels.C_Models;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Linq;

namespace Client.D_ViewModels
{
    public class ActionTabViewModel : BindableBase, INavigationAware
    {
        public int SelectedIndex { get; set; }
        public ObservableCollection<Requete> Requetes { get; set; }

        public ObservableCollection<QueryViewModel> Tabs { get; set; }

        public ActionTabViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CloseTabCommand = new RelayCommand<MouseEventArgs>(OnCloseTabRequested);
            CloseTab += ActionTabViewModel_CloseTab;
            Tabs = new ObservableCollection<QueryViewModel>();
        }

        private void ActionTabViewModel_CloseTab(MouseEventArgs obj)
        {
            TabItem tab = GetTargetTabItem(obj.OriginalSource);
            //_regionManager.Regions["tabcontrol"].Deactivate(tab.Content);
            _regionManager.Regions["tabcontrol"].Remove(tab.Content);
        }

        internal void AddTab(Requete requete, bool paginationOption)
        {
            //Tabs.Insert(0, new QueryViewModel(requete, paginationOption));
            ActiveTabItemIndex = 0;
        }

        private IRegionManager _regionManager;

        public RelayCommand<MouseEventArgs> CloseTabCommand { get; private set; }

        public event Action<MouseEventArgs> CloseTab = delegate { };
        void OnCloseTabRequested(MouseEventArgs parameter)
        {
            CloseTab(parameter);
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
        public void ActivatePagination()
        {
            QueryViewModel._PaginationOption = true;
            for (int i = 0; i < Tabs.Count; ++i)
            {
                Tabs[i].ActivatePagination();
            }
        }

        internal void TabItem_Drop(TabControl actionTabs, TabItem tabItemSourcetab, int sourceIndex, TabItem tabItemTargettab, int targetIndex)
        {
            IRegion region = _regionManager.Regions["tabcontrol"]; //TabsContentRegion
            var viewList = region.Views.ToList();
            var tabItemSource = viewList[sourceIndex];
            var tabItemTarget = viewList[targetIndex];
            if (sourceIndex > targetIndex)
            {
                for (int i = 0; i < viewList.Count; ++i)
                {
                    region.Remove(viewList[i]);
                }
                for (int i = 0; i < targetIndex; ++i)
                {
                    region.Add(viewList[i]);
                }
                region.Add(tabItemSource);
                for (int i = targetIndex + 1; i < sourceIndex; ++i)
                {
                    region.Add(viewList[i]);
                }
                region.Add(tabItemTarget);
                for (int i = sourceIndex + 1; i < viewList.Count; ++i)
                {
                    region.Add(viewList[i]);
                }
            }
            else
            {

                for (int i = 0; i < viewList.Count; ++i)
                {
                    region.Remove(viewList[i]);
                }
                for (int i = 0; i < sourceIndex; ++i)
                {
                    region.Add(viewList[i]);
                }
                region.Add(tabItemTarget);
                for (int i = sourceIndex + 1; i < targetIndex; ++i)
                {
                    region.Add(viewList[i]);
                }
                region.Add(tabItemSource);
                for (int i = targetIndex + 1; i < viewList.Count; ++i)
                {
                    region.Add(viewList[i]);
                }
            }
        }

        public void DeActivatePagination()
        {

            QueryViewModel._PaginationOption = false;
            for (int i = 0; i < Tabs.Count; ++i)
            {
                Tabs[i].DeActivatePagination();
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("requete"))
            {
                Requete requete = navigationContext.Parameters.GetValue<Requete>("requete");
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private int _ActiveTabItemIndex;
        public int ActiveTabItemIndex
        {
            get { return _ActiveTabItemIndex; }
            set { SetProperty(ref _ActiveTabItemIndex, value); }
        }
    }
}


