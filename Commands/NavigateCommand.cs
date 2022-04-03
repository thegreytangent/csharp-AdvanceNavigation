using AdvanceNavigation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceNavigation.ViewModels;


namespace AdvanceNavigation.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase

        where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigation_service;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigation_service = navigationService;
        }

        public override void Execute(object parameter)
        {
          _navigation_service.Navigate();
        }
    }
}
