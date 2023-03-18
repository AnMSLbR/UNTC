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
        private readonly NavigationStore _navigationStore;
        private readonly BoreholeStore _boreholeStore;

        public App()
        {
            _navigationStore = new NavigationStore();
            _boreholeStore = new BoreholeStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService dataNavigationService = CreateDataNavigationService();
            dataNavigationService.Navigate();
            new MainWindow() { DataContext = new MainViewModel(_navigationStore) }.Show();
            base.OnStartup(e);
        }

        private INavigationService CreateDataNavigationService()
        {
            return new LayoutNavigationService<DataViewModel>(
                _navigationStore, () => new DataViewModel(_boreholeStore), () => new CommonViewModel(_boreholeStore, CreateNevigationViewModel));
        }

        private INavigationService CreateAddNavigationService()
        {
            return new LayoutNavigationService<AddViewModel>(
                _navigationStore, () => new AddViewModel(_boreholeStore, CreateDataNavigationService()), () => new CommonViewModel(_boreholeStore, CreateNevigationViewModel));
        }
        private NavigationViewModel CreateNevigationViewModel()
        {
            return new NavigationViewModel(CreateDataNavigationService(), CreateAddNavigationService());
        }
    }
}
