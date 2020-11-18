using Client.Core.Regions;
using Client.D_ViewModels;
using Client.D_Views;
using Client.Module.D_Views;
using Client.Services.Api;
using Client.Services.Impl;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            PrismBootstrapper bootstrapper = new MyBootStrapper();
            bootstrapper.Run();
        }
        public class MyBootStrapper : PrismBootstrapper
        {
            protected override DependencyObject CreateShell()
            {
                return Container.Resolve<MainWindow>();
            }
            protected override void InitializeShell(DependencyObject shell)
            {
                base.InitializeShell(shell);
                //System.Windows.Application.Current.MainWindow.Show();
            }
            protected override void RegisterTypes(IContainerRegistry containerRegistry)
            {

                containerRegistry.RegisterSingleton<IConfigurationService>(() => ConfigurationService.GetInstance());//new ContainerControlledLifetimeManager());
                containerRegistry.RegisterSingleton<IRequetesExecutionService>(() => RequetesExecutionService.GetInstance());//new ContainerControlledLifetimeManager());
                containerRegistry.RegisterDialog<InputColumnNameDlg, InputColumnNameDlgViewModel>();//(() => Container.Resolve <InputColumnNameDlgViewModel>());
                
            }
            protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
            {
                moduleCatalog.AddModule<Client.Module.QueryViewerModule>();
            }
            protected override void ConfigureViewModelLocator()
            {
                
                base.ConfigureViewModelLocator();
                ViewModelLocationProvider.Register<MainWindow>(()=> Container.Resolve<MainWindowViewModel>());
                ViewModelLocationProvider.Register<ActionTabView>(() => Container.Resolve <ActionTabViewModel>());
                ViewModelLocationProvider.Register<QueryView>(() => Container.Resolve <QueryViewModel>());
                ViewModelLocationProvider.Register<RequetesList>(()=> Container.Resolve <RequetesListViewModel>());
                ViewModelLocationProvider.Register<MenuView>(() => Container.Resolve<MenuViewModel>());

                //ViewModelLocationProvider.Register(typeof(MenuView).ToString(), typeof(MainWindowViewModel));

            }
            protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
            {
                base.ConfigureRegionAdapterMappings(regionAdapterMappings);
                regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            }

        }
    } 
}
