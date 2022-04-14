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

        public NavigationBarViewModel navigationBarViewModel;

        public AccountViewModel(NavigationBarViewModel _navigationBarViewModel, AccountStore _accountStore, NavigationService<HomeViewModel> homeNavigationService) {

            accountStore = _accountStore;

            navigationBarViewModel = _navigationBarViewModel;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
      
    } 
}
