using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AdvanceNavigation.ViewModels;
using AdvanceNavigation.Stores;
using AdvanceNavigation.Models;
using AdvanceNavigation.Services;

namespace AdvanceNavigation.Commands
{
    public class LoginCommand : CommandBase
    {

        private readonly LoginViewModel viewModel;
        private readonly AccountStore accountStore;
        private readonly ParameterNavigationService<Account, AccountViewModel> navigationService;

        public LoginCommand(
            LoginViewModel _viewModel,
            AccountStore _accountStore,
            ParameterNavigationService<Account, AccountViewModel> _navigationService
            )
        {

            accountStore = _accountStore;
            viewModel = _viewModel;
            navigationService = _navigationService;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show($"login in {viewModel.Username}" +
                $" and email {viewModel.Username}");

            Account account = new Account()
            {
                Email = $"{viewModel.Username}@test.com",
                Username = viewModel.Username
            };
            accountStore.CurrentAccount = account;
            navigationService.Navigate(account);
        
        }
    }
}
