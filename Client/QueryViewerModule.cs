using Client.D_Views;
using Client.Module.D_Views;
using Client.Services.Api;
using Client.Services.Impl;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Client.Module
{
    public class QueryViewerModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public QueryViewerModule(IContainerProvider containerProvider)
        {
            //_regionManager = regionManager;
            _regionManager = containerProvider.Resolve<IRegionManager>();

            _regionManager.RegisterViewWithRegion("MenuContentRegion", typeof(MenuView));
            _regionManager.RegisterViewWithRegion("RequeteListContentRegion", typeof(RequetesList));
            _regionManager.RegisterViewWithRegion("TabsContentRegion", typeof(ActionTabView));

        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion MenuRegion = _regionManager.Regions["MenuContentRegion"];
             //regionManager.RegisterViewWithRegion("RightRegion", typeof(MessageList));
                        
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterSingleton<IConfigurationService>(() => ConfigurationService.GetInstance());//new ContainerControlledLifetimeManager());
            containerRegistry.RegisterSingleton<IRequetesExecutionService>(() => RequetesExecutionService.GetInstance());//new ContainerControlledLifetimeManager());
            //containerRegistry.RegisterForNavigation<ActionTabView>();
            containerRegistry.RegisterForNavigation<QueryView>(); //TabsContentRegion
            //containerRegistry.RegisterForNavigation<RequetesList>();
            containerRegistry.RegisterDialog<InputColumnNameDlg>();
        }
    }
}