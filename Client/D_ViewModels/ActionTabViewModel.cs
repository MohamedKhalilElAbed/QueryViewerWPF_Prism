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
using Prism.Commands;

namespace Client.D_ViewModels
{
    public class ActionTabViewModel : BindableBase, INavigationAware
    {

        private int _ActiveTabItemIndex;
        public int ActiveTabItemIndex
        {
            get { return _ActiveTabItemIndex; }
            set { SetProperty(ref _ActiveTabItemIndex, value); }
        }

        private IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }
        public ActionTabViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }
        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("TabRegion", navigationPath);
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

        
    }
}


