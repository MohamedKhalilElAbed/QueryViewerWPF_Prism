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
            OpenRequeteCommand = new RelayCommand<Requete>(OnOpenRequete);
            OpenRequeteRequested += OpenRequest;
            OpenRequeteRequested += RequeteListeViewModel_OpenRequeteRequested;
            //LoadRequetList();
        }

        public void LoadRequetList()
        {
            Requetes = new ObservableCollection<Requete>(_configurationService.GetRequetes().Values);
        }
        public RelayCommand<Requete> OpenRequeteCommand { get; private set; }
        public event Action<Requete> OpenRequeteRequested = delegate { };
        void OnOpenRequete(Requete requete)
        {
            OpenRequeteRequested(requete);
        }

        private void RequeteListeViewModel_OpenRequeteRequested(Requete obj)
        {
            //_ActionTabViewModel.ActiveTabItemIndex = 0;
        }
      
        private void OpenRequest(Requete requete)
        {
            //_ActionTabViewModel.AddTab(requete, IsPaginationOptionOn);
            var p = new NavigationParameters();
            p.Add("requete", requete);
            var view = _containerProvider.Resolve<QueryView>();
            QueryViewModel qvm = view.DataContext as QueryViewModel;
            qvm.Request = requete;
            qvm.Title = requete.Name;
            qvm.PaginationOption = true;
            qvm.ExecuteRequest(null, null);
            IRegion region = _regionManager.Regions["tabcontrol"];
            region.Add(view);
            region.Activate(view);
            _ea.GetEvent<NouveauTabEvent>().Publish();
            //QueryViewModel qvm = conta new QueryViewModel(requete, false, _regionManager, )

            //_regionManager.RequestNavigate("ContentRegion", navigatePath);
            //(((ActionTabView)(_regionManager.Regions["TabsContentRegion"].ActiveViews.GetEnumerator().Current)).DataContext as ActionTabViewModel).AddTab(requete, false);
            //_regionManager.RequestNavigate("TabsContentRegion", "tabcontrol", p);
        }
    }
}
