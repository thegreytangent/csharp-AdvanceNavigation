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
        private readonly AccountStore accountStore;
        private readonly LoginViewModel viewModel;
        private readonly INavigationService navigationService;
        
        public LoginCommand(
            LoginViewModel _viewModel,
            AccountStore _accountStore,
            INavigationService _navigationService
            )
        {

            viewModel = _viewModel;
            accountStore = _accountStore;
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
            this.accountStore.CurrentAccount = account;

            navigationService.Navigate();
        
        }
    }
}
