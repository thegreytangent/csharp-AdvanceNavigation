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
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel( NavigationStore _navStore ) {
            _navigationStore = _navStore;
            _navigationStore.CurrentViewModelChanged += OncurrentViewModelChanged;
        }

        private void OncurrentViewModelChanged() {
            OnPropertyChanged( nameof(CurrentViewModel) );
        }
    }
}
