using Client.App.D_Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.App
{
    /// <summary>
    /// Logique d'interaction pour App1.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
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
                return Container.Resolve<D_Views.ShellWindow>();
            }
            protected override void InitializeShell(DependencyObject shell)
            {
                base.InitializeShell(shell);
                Application.Current.MainWindow.Show();
            }
            protected override void RegisterTypes(IContainerRegistry containerRegistry)
            {

            }
            protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
            {
                moduleCatalog.AddModule<Client.Module.QueryViewerModule>();
            }

        }

    }
}
