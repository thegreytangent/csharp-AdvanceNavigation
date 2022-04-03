using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AdvanceNavigation.ViewModels;
using AdvanceNavigation.Stores;

namespace AdvanceNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        NavigationStore _navStore = new NavigationStore();

        
        protected override void OnStartup(StartupEventArgs e)
        {
            AccountStore accountStore = new AccountStore() ;

            //first view/model to show
            _navStore.CurrentViewModel = new LoginViewModel(accountStore, _navStore); 

            MainWindow = new MainWindow() {
                DataContext = new MainViewModel(_navStore)
        };
            MainWindow.Show();
            base.OnStartup(e);
        }


    }
}
