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
using Microsoft.Extensions.DependencyInjection;

namespace AdvanceNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //private readonly AccountStore accountStore;
        //private readonly NavigationStore navigationStore;
        //private readonly ModalNavigationStore modalNavigationStore;

        private readonly ServiceProvider _serviceProvider;

        public App() {

            //accountStore = new AccountStore();
            //navigationStore = new NavigationStore();
            //modalNavigationStore = new ModalNavigationStore();

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(CreateLoginNavigationService(s)));
            
            services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s)
                )
            );

            services.AddTransient<LoginViewModel>(CreateLoginViewModel);

            services.AddTransient<PeopleListingViewModel>(s => new PeopleListingViewModel( CreateAddPersonNavigationService(s) ));
            services.AddTransient<AddPersonViewModel>(s => new AddPersonViewModel());
            services.AddSingleton<AccountStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<CloseModalNavigationService>();
            services.AddSingleton<NavigationBarViewModel>(createNavigationBarViewModel);
            
             services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow() { 
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider =  services.BuildServiceProvider();

        }

       
        private LoginViewModel CreateLoginViewModel(IServiceProvider s)
        {
            ModalNavigationStore modalNavigationStore = s.GetRequiredService<ModalNavigationStore>();
            AccountStore _accountStore = s.GetRequiredService<AccountStore>();

            CompositeNavigationService navigationService = new CompositeNavigationService(
             s.GetRequiredService<CloseModalNavigationService>(),
              CreateAccountNavigationService(s)
              );

            return new LoginViewModel(
                 s.GetRequiredService<AccountStore>(),
                 navigationService
                 );
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            INavigationService initialNavigationService = _serviceProvider.GetService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            //MainWindow = new MainWindow() {
            //    DataContext = new MainViewModel(navigationStore, modalNavigationStore)
            //};
            //MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationBarViewModel createNavigationBarViewModel(IServiceProvider serviceProvider) 
        {
            return new NavigationBarViewModel(
                     serviceProvider.GetRequiredService<AccountStore>(),
                     CreateHomeNavigationService(serviceProvider),
                     CreateAccountNavigationService(serviceProvider),
                     CreateLoginNavigationService(serviceProvider),
                     CreatePeopleListingNavigationService(serviceProvider)
                     );
        }

        private INavigationService CreatePeopleListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<PeopleListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PeopleListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
               );
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
              serviceProvider.GetRequiredService<NavigationStore>(),
              () => serviceProvider.GetRequiredService<HomeViewModel>(),
              () => createNavigationBarViewModel(serviceProvider)
          );

        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>()
               );
        }


        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            ModalNavigationStore modalNavigationStore = serviceProvider.GetRequiredService<ModalNavigationStore>();
            return new ModalNavigationService<LoginViewModel>(
               modalNavigationStore, 
               () => serviceProvider.GetRequiredService<LoginViewModel>()
           );
        }

        private INavigationService CreateAddPersonNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddPersonViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddPersonViewModel>()
            );
        }




    }
}
