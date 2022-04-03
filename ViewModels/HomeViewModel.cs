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
        AccountStore accountStore;


        public ICommand NavigateAccountCommand { get;  }

        public HomeViewModel(AccountStore _accountStore, NavigationStore _navStore) {
            accountStore = _accountStore;

            NavigateAccountCommand = new NavigateCommand<LoginViewModel>(new NavigationService<LoginViewModel>(
                    _navStore,()=> new LoginViewModel(accountStore, _navStore))
            );
        }
    }
}
