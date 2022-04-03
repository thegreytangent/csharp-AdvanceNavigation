using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceNavigation.Stores;
using AdvanceNavigation.ViewModels;


namespace AdvanceNavigation.Services
{
    public class ParameterNavigationService<TParameter, TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navStore = navStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter _param) 
        {
            _navStore.CurrentViewModel = _createViewModel(_param);
        }



    }
} 
