using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;
using UNTC.Stores;

namespace UNTC.ViewModels
{
    internal class CommonViewModel : BaseViewModel
    {
        private BoreholeStore _boreholeStore;

        public ObservableCollection<Borehole> Boreholes { get; set; }
        public Borehole SelectedBorehole
        {
            get => _boreholeStore.CurrentBorehole;
            set
            {
                _boreholeStore.CurrentBorehole = value;
                OnPropertyChanged(nameof(SelectedBorehole));
            }
        }
        public NavigationViewModel NavigationViewModel { get; set; }

        public CommonViewModel(BoreholeStore boreholeStore, Func<NavigationViewModel> createNavigationViewModel)
        {
            _boreholeStore = boreholeStore;
            Boreholes = boreholeStore.BoreholeList;
            SelectedBorehole = boreholeStore.CurrentBorehole;
            NavigationViewModel = createNavigationViewModel();
        }
    }
}
