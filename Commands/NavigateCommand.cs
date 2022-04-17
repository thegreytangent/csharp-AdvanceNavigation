using AdvanceNavigation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceNavigation.ViewModels;
using AdvanceNavigation.Services;


namespace AdvanceNavigation.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigation_service;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigation_service = navigationService;
        }

        public override void Execute(object parameter)
        {
          _navigation_service.Navigate();
        }
    }
}
