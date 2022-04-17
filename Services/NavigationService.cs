using System;
using AdvanceNavigation.ViewModels;
using AdvanceNavigation.Stores;

namespace AdvanceNavigation.Services
{
    public class INavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {

        private readonly NavigationStore _navStore;
        private readonly Func<TViewModel> _createViewModel;

        public INavigationService(NavigationStore navStore, Func <TViewModel> createViewModel)
        {
            _navStore = navStore;
            _createViewModel = createViewModel;
        }
        
        
        public void Navigate()
        {
            _navStore.CurrentViewModel = _createViewModel();
        }
    }
}
