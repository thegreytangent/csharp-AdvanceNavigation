using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdvanceNavigation.Commands;
using AdvanceNavigation.Services;
using AdvanceNavigation.Stores;

namespace AdvanceNavigation.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore store;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }

        public bool isLoggedIn => store.isLoggedIn;

        public NavigationBarViewModel(
            AccountStore _accountStore,
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<AccountViewModel> accountNavigationService,
            NavigationService<LoginViewModel> loginNavigationService
            ) {
            store = _accountStore;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }


        



    }
}
