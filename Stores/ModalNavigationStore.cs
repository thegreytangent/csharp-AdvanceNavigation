using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceNavigation.ViewModels;

namespace AdvanceNavigation.Stores
{
    public class ModalNavigationStore
    {
        public event Action CurrentViewModelChanged;

        private ViewModelBase _viewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel?.Dispose();
                _viewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public bool IsOpen => CurrentViewModel != null;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public void Close() {
            CurrentViewModel = null;
        }

    }
}
