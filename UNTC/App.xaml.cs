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
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly BoreholeStore _boreholeStore;
        private readonly NavigationViewModel _navigationViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _boreholeStore = new BoreholeStore();
            _navigationViewModel = new NavigationViewModel(CreateDataNavigationService(), CreateAddNavigationService());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<DataViewModel> dataNavigationService = CreateDataNavigationService();
            dataNavigationService.Navigate();
            new MainWindow() { DataContext = new MainViewModel(_navigationStore, _navigationViewModel) }.Show();
            base.OnStartup(e);
        }

        private NavigationService<DataViewModel> CreateDataNavigationService()
        {
            return new NavigationService<DataViewModel>(_navigationStore, () => new DataViewModel(_boreholeStore));
        }

        private NavigationService<AddViewModel> CreateAddNavigationService()
        {
            return new NavigationService<AddViewModel>(_navigationStore, () => new AddViewModel(_navigationViewModel, _boreholeStore, CreateDataNavigationService()));
        }
    }
}
