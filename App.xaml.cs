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

namespace AdvanceNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly AccountStore accountStore;
        private readonly NavigationStore navigationStore;
        private NavigationBarViewModel navigationBarViewModel;


        public App() {
            this.navigationStore = new NavigationStore();
            this.accountStore = new AccountStore();
            this.navigationBarViewModel = new NavigationBarViewModel(
                accountStore,
                CreateHomeNavigationService(),
                CreateAccountNavigationService(),
                CreateLoginNavigationService()
                );
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            NavigationService<HomeViewModel> navService = this.CreateHomeNavigationService();
            navService.Navigate();

            //first view/model to show
            this.navigationStore.CurrentViewModel = new HomeViewModel(
                this.navigationBarViewModel, CreateLoginNavigationService()
             ); 

            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(this.navigationStore)
        };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
           return new NavigationService<HomeViewModel>(this.navigationStore, () => 
           new HomeViewModel( this.navigationBarViewModel, CreateLoginNavigationService() )
           );
        }


        private NavigationService<LoginViewModel> CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(this.navigationStore, () =>
           new LoginViewModel(this.accountStore, CreateAccountNavigationService())
           );
        }

        private NavigationService<AccountViewModel> CreateAccountNavigationService()
        {
            return new NavigationService<AccountViewModel>(this.navigationStore, () =>
          new AccountViewModel(this.navigationBarViewModel, this.accountStore, CreateHomeNavigationService())
          );
        }

    }
}
