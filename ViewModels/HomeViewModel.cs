using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdvanceNavigation.Stores;
using AdvanceNavigation.Commands;

namespace AdvanceNavigation.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application";
      
        public NavigationBarViewModel navigationBarViewModel { get;  }
        
        public ICommand NavigateloginCommand { get;  }

        public HomeViewModel(NavigationBarViewModel _navigationBarViewModel, NavigationService<LoginViewModel> loginNavService) {
            navigationBarViewModel = _navigationBarViewModel;
            NavigateloginCommand = new NavigateCommand<LoginViewModel>(loginNavService);
        }
    }
}
