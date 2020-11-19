using Prism.Mvvm;
using Prism.Regions;
using Client.DataModels.C_Models;
using Prism.Commands;
using Client.Core.Regions;

namespace Client.D_ViewModels
{
    public class ActionTabViewModel : BindableBase, INavigationAware, IRegionManagerAware
    {
        public IRegionManager RegionManager { get; set; }

        private int _ActiveTabItemIndex;
        public int ActiveTabItemIndex
        {
            get { return _ActiveTabItemIndex; }
            set { SetProperty(ref _ActiveTabItemIndex, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; set; }

        public ActionTabViewModel()
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }
        void Navigate(string navigationPath)
        {
            RegionManager.RequestNavigate("TabRegion", navigationPath);
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


