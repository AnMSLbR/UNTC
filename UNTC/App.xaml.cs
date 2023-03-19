using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UNTC.Services;
using UNTC.Stores;
using UNTC.ViewModels;

namespace UNTC
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<BoreholeStore>();
            services.AddSingleton<INavigationService>(s => CreateDataNavigationService(s));
            
            services.AddSingleton<NavigationViewModel>(CreateNavigationViewModel);

            services.AddTransient<DataViewModel>();
            services.AddTransient<AddViewModel>(s => new AddViewModel(s.GetRequiredService<BoreholeStore>(), CreateDataNavigationService(s)));
            services.AddTransient<CommonViewModel>(s => new CommonViewModel(s.GetRequiredService<BoreholeStore>(), () => s.GetRequiredService<NavigationViewModel>()));

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            
            base.OnStartup(e);
        }

        private INavigationService CreateDataNavigationService(IServiceProvider serviceProvider)
        {
            var boreholeStore = serviceProvider.GetService<BoreholeStore>();
            return new LayoutNavigationService<DataViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<DataViewModel>(),
                () => serviceProvider.GetRequiredService<CommonViewModel>());
        }

        private INavigationService CreateAddNavigationService(IServiceProvider serviceProvider)
        {
            var boreholeStore = serviceProvider.GetService<BoreholeStore>();
            return new LayoutNavigationService<AddViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AddViewModel>(),
                () => serviceProvider.GetRequiredService<CommonViewModel>());
        }
        private NavigationViewModel CreateNavigationViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationViewModel(CreateDataNavigationService(serviceProvider), CreateAddNavigationService(serviceProvider));
        }
    }
}
