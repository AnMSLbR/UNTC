using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UNTC.Commands;
using UNTC.Models;
using UNTC.Stores;

namespace UNTC.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ObservableCollection<Borehole> Boreholes { get; set; }
        public NavigationViewModel NavigationViewModel { get; }
        public ICommand NavigateAddCommand { get; }
        public ICommand NavigateDataCommand { get; }
        public MainViewModel(NavigationStore navigationStore, NavigationViewModel navigationViewModel)
        {
            _navigationStore = navigationStore;
            NavigationViewModel = navigationViewModel;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            Boreholes = new ObservableCollection<Borehole>
            {
                new Borehole{ Title="Скважина 1", Depth=355, Density=0.89},
                new Borehole{ Title="Скважина 2", Depth=241, Density=0.85},
                new Borehole{ Title="Скважина 3", Depth=472, Density=0.91},
            };
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
