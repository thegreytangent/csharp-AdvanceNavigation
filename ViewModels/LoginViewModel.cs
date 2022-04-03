using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdvanceNavigation.Commands;
using AdvanceNavigation.Stores;
using AdvanceNavigation.Services;
using AdvanceNavigation.Models;

namespace AdvanceNavigation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        NavigationStore nav_store;

       public  ICommand LoginCommand { get;  }

        public LoginViewModel(AccountStore _accountStore, NavigationStore _navStore)
        {
            ParameterNavigationService<Account, AccountViewModel> navigationService = new ParameterNavigationService<Account, AccountViewModel>(
                _navStore,
                (_param) => new AccountViewModel(_accountStore, _navStore));

            LoginCommand = new LoginCommand(this, _accountStore, navigationService);
        }
    }


}
