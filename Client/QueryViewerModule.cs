using Client.Core;
using Client.D_Views;
using Client.Module.D_Views;
using Client.Services.Api;
using Client.Services.Impl;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Client.Module
{
    public class QueryViewerModule : IModule
    {
       
        private readonly IRegionManager _regionManager;
        public static IContainerProvider ContainerProvider;
        public QueryViewerModule(IContainerProvider containerProvider)
        {
            Helpers.RegionManager = containerProvider.Resolve<IRegionManager>();
            Helpers.ContainerProvider = containerProvider;
            ContainerProvider = Helpers.ContainerProvider;
            _regionManager = Helpers.RegionManager;
            _regionManager.RegisterViewWithRegion("MenuContentRegion", typeof(MenuView));
            _regionManager.RegisterViewWithRegion("RequeteListContentRegion", typeof(RequetesList));
            _regionManager.RegisterViewWithRegion("TabsContentRegion", typeof(ActionTabView));

        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //IRegion MenuRegion = _regionManager.Regions["MenuContentRegion"];        
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterSingleton<IConfigurationService>(() => ConfigurationService.GetInstance());
            containerRegistry.RegisterSingleton<IRequetesExecutionService>(() => RequetesExecutionService.GetInstance());
            containerRegistry.RegisterForNavigation<QueryView>("QueryView"); //TabsContentRegion
            containerRegistry.RegisterDialog<InputColumnNameDlg>();
        }
    }
}