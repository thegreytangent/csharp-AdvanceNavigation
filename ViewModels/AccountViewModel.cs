using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdvanceNavigation.Commands;
using AdvanceNavigation.Models;
using AdvanceNavigation.Stores;
using AdvanceNavigation.Services;
using System.Diagnostics;

namespace AdvanceNavigation.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore accountStore;
        public string Username => accountStore.CurrentAccount?.Username;
        public string Email => accountStore.CurrentAccount?.Email;


        public ICommand NavigateHomeCommand { get;  }

      

        public AccountViewModel(AccountStore _accountStore, INavigationService homeNavigationService) {

            accountStore = _accountStore;

           NavigateHomeCommand = new NavigateCommand(homeNavigationService);

            accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged() {
            OnPropertyChanged( nameof(Email) );
            OnPropertyChanged( nameof(Username) );
        }
        ~AccountViewModel()
        {
            Debug.WriteLine("--------- Destructor ----------");
        }

        public override void Dispose() {
            Debug.WriteLine("--------- dispose ----------");
            accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;
            base.Dispose();
        }


    } 
}
