using AdvanceNavigation.Stores;
using AdvanceNavigation.ViewModels;
using System;

namespace AdvanceNavigation.Commands
{
    public class NavigationService<TViewModel>
     where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigation_store;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore _navStore, Func<TViewModel> createViewModel)
        {
            _navigation_store = _navStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigation_store.CurrentViewModel = _createViewModel();
        }
    }
}
