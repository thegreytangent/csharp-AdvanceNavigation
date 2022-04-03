using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdvanceNavigation.Commands;
using AdvanceNavigation.Models;
using AdvanceNavigation.Stores;

namespace AdvanceNavigation.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore accountStore;

        public string Username => accountStore.CurrentAccount.Username;
        public string Email => accountStore.CurrentAccount.Email;


        public ICommand NavigateHomeCommand { get;  }

        public AccountViewModel(AccountStore _accountStore, NavigationStore _navStore) {

            accountStore = _accountStore;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(
                    _navStore, () => new HomeViewModel(accountStore, _navStore))
                );
        }
      
    } 
}
