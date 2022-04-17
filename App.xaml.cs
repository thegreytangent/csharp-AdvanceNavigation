using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AdvanceNavigation.ViewModels;
using AdvanceNavigation.Stores;
using AdvanceNavigation.Commands;
using AdvanceNavigation.Services;

namespace AdvanceNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly AccountStore accountStore;
        private readonly NavigationStore navigationStore;
        private readonly ModalNavigationStore modalNavigationStore;
        
        public App() {
            accountStore = new AccountStore();
            navigationStore = new NavigationStore();
            modalNavigationStore = new ModalNavigationStore();
        }



        protected override void OnStartup(StartupEventArgs e)
        {

            INavigationService homeNavService = this.CreateHomeNavigationService();
            homeNavService.Navigate();

            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(navigationStore, modalNavigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private NavigationBarViewModel createNavigationBarViewModel() 
        {
            return new NavigationBarViewModel(
                     accountStore,
                     CreateHomeNavigationService(),
                     CreateAccountNavigationService(),
                     CreateLoginNavigationService()
                     );
        }

        private INavigationService CreateHomeNavigationService()
        {
           return new LayoutNavigationService<HomeViewModel>(
               navigationStore, 
               () => new HomeViewModel(CreateLoginNavigationService()),
               createNavigationBarViewModel
           );
        }

        private INavigationService CreateAccountNavigationService()
        {
            return new LayoutNavigationService<AccountViewModel>(
                navigationStore,
                () => new AccountViewModel(this.accountStore, CreateHomeNavigationService()),
                createNavigationBarViewModel
               );
        }


        private INavigationService CreateLoginNavigationService()
        {

            CompositeNavigationService composite = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                CreateAccountNavigationService()
                );
            
            return new ModalNavigationService<LoginViewModel>(
               modalNavigationStore, 
               () => new LoginViewModel(this.accountStore, composite)
           );
        }

        

    }
}
