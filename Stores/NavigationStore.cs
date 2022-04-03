using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceNavigation.ViewModels;

namespace AdvanceNavigation.Stores
{
    public class NavigationStore
    {

        public event Action CurrentViewModelChanged;

        private ViewModelBase _viewModel;

        public ViewModelBase CurrentViewModel {
            get => _viewModel;
            set {
                _viewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
