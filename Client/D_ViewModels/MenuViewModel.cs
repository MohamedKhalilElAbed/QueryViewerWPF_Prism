using System;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Events;
using Client.Core.Events;

namespace Client.D_ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IEventAggregator _ea;
        public bool _IsPaginationOptionOn;
        public bool IsPaginationOptionOn
        {
            get { return _IsPaginationOptionOn; }
            set { SetProperty(ref _IsPaginationOptionOn, value); }
        }

        public MenuViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _ea = ea;
            PaginateMenuItemUncheckedCommand = new RelayCommand<string>(OnPaginateMenuItemUnCheckedRequested);
            PaginateMenuItemUnchecked += PaginateMenuItem_Unchecked;
            PaginateMenuItemCheckedCommand = new RelayCommand<string>(OnPaginateMenuItemCheckedRequested);
            PaginateMenuItemChecked += PaginateMenuItem_Checked;
            IsPaginationOptionOn = false;
            _ea.GetEvent<NouveauTabEvent>().Subscribe(NouveauTab);
        }

        private void NouveauTab()
        {
            if (IsPaginationOptionOn)
                PaginateMenuItem_Checked();
            else
                PaginateMenuItem_Unchecked();
        }

        public RelayCommand<string> PaginateMenuItemCheckedCommand { get; private set; }
        public event Action PaginateMenuItemChecked = delegate { };
        void OnPaginateMenuItemCheckedRequested(object parameter)
        {
            PaginateMenuItemChecked();
        }


        private void PaginateMenuItem_Checked()
        {
            _ea.GetEvent<NavigationOptionEvent>().Publish(true);
        }

        public RelayCommand<string> PaginateMenuItemUncheckedCommand { get; private set; }
        public event Action PaginateMenuItemUnchecked = delegate { };

        void OnPaginateMenuItemUnCheckedRequested(object parameter)
        {
            PaginateMenuItemUnchecked();
        }

        private void PaginateMenuItem_Unchecked()
        {
            _ea.GetEvent<NavigationOptionEvent>().Publish(false);
        }

    }
}