using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceNavigation.Stores;

namespace AdvanceNavigation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore; 
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        public bool IsOpen => _modalNavigationStore.IsOpen;

        public MainViewModel( NavigationStore _navStore, ModalNavigationStore modalNavigationStore ) {
            _modalNavigationStore = modalNavigationStore;
            _navigationStore = _navStore;
            _navigationStore.CurrentViewModelChanged += OncurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentViewModalModelChanged;
        }

     

        private void OncurrentViewModelChanged() {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentViewModalModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsOpen));

            
        }
    }
}
