using Client.Core.Events;
using Client.DataModels.C_Models;
using Client.F_Common;
using Prism.Events;
using Prism.Regions;
using System.ComponentModel;
using System.Windows;

namespace TabControlRegion.Core
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        protected IEventAggregator _ea;
        public Requete Request { get; set; }
        public virtual void ExecuteRequest(object sender, RoutedEventArgs e) 
        { 

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Request = navigationContext.Parameters["requete"] as Requete;
            Title = Request.Name;
            ExecuteRequest(null, null);
            _ea.GetEvent<NouveauTabEvent>().Publish();
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
