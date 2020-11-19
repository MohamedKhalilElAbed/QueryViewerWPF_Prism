//using Client.F_Common;
using Interactivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Mvvm;
using Prism.Regions;
using Client.DataModels.C_Models;
using Client.Services.Api;
using Client.D_Views;
using Prism.Ioc;
using Prism.Events;
using Client.Core.Events;
using Prism.Commands;

namespace Client.D_ViewModels
{
    public class RequetesListViewModel : BindableBase
    {
        private IConfigurationService _configurationService;
        private IRegionManager _regionManager;
        private IContainerProvider _containerProvider;
        private IEventAggregator _ea;
        private ObservableCollection<Requete> _requetes;
        public ObservableCollection<Requete> Requetes
        {
            get { return _requetes; }
            set { SetProperty(ref _requetes, value); }
        }
        public RequetesListViewModel(IConfigurationService configurationService, IRegionManager regionManager, IContainerProvider containerProvider, IEventAggregator ea)

        {
            _configurationService = configurationService;
            _regionManager = regionManager;
            _containerProvider = containerProvider;
            _ea = ea;
            NavigateCommand = new DelegateCommand<Requete>(Navigate);
            //LoadRequetList();
        }
        void Navigate(Requete requete)
        {
            NavigationParameters p = new NavigationParameters();
            p.Add("requete", requete);
            _regionManager.RequestNavigate("tabcontrol", "QueryView", p);
        }

        public void LoadRequetList()
        {
            Requetes = new ObservableCollection<Requete>(_configurationService.GetRequetes().Values);
        }
        public DelegateCommand<Requete> NavigateCommand { get; set; }
    }
}
