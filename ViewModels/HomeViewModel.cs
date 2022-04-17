using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdvanceNavigation.Stores;
using AdvanceNavigation.Commands;
using AdvanceNavigation.Services;

namespace AdvanceNavigation.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application";
        
        public ICommand NavigateloginCommand { get;  }

        public HomeViewModel( INavigationService loginNavService) {
            NavigateloginCommand = new NavigateCommand(loginNavService);
        }
    }
}
