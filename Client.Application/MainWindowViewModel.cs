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
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        static IConfigurationService _configurationServiceInstance;
        
        public MainWindowViewModel( IConfigurationService configurationService, IContainerProvider containerProvider)
        {
            _configurationServiceInstance = configurationService;
         }
    }

}
