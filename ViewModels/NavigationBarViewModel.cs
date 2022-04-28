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

        public ICommand LogoutCommand { get;  }

        public ICommand NavigatePeopleListingCommand { get;  }

        public bool isLoggedIn => store.IsLoggedIn;

        public NavigationBarViewModel(
            AccountStore _accountStore,
            INavigationService homeNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService,
            INavigationService peopleListingNavigationService
            )
        {
            store = _accountStore;
            
            LogoutCommand = new LogoutCommand(store);
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigatePeopleListingCommand = new NavigateCommand(peopleListingNavigationService);

            store.CurrentAccountChanged += OnCurrentAccountChanged;
        
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(isLoggedIn));
        }

        public override void Dispose() {

            store.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }


        



    }
}
