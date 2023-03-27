using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UNTC.Commands;
using UNTC.Models;
using UNTC.Stores;

namespace UNTC.ViewModels
{
    internal class CommonViewModel : BaseViewModel
    {
        private BoreholeStore _boreholeStore;

        public BindingList<Borehole> Boreholes { get; set; }
        public ICommand DeleteBoreholeCommand { get; }
        public Borehole SelectedBorehole
        {
            get => _boreholeStore.CurrentBorehole;
            set
            {
                _boreholeStore.CurrentBorehole = value;
                OnPropertyChanged(nameof(SelectedBorehole));
            }
        }
        public int SelectedBoreholeIndex
        {
            get => _boreholeStore.CurrentBoreholeIndex;
            set
            {
                _boreholeStore.CurrentBoreholeIndex = value;
                OnPropertyChanged(nameof(SelectedBoreholeIndex));
            }
        }

        public NavigationViewModel NavigationViewModel { get; set; }

        public CommonViewModel(BoreholeStore boreholeStore, Func<NavigationViewModel> createNavigationViewModel)
        {
            _boreholeStore = boreholeStore;
            _boreholeStore.CurrentBoreholeChanged += OnCurrentBoreholeChanged;
            Boreholes = boreholeStore.BoreholeList;
            SelectedBorehole = boreholeStore.CurrentBorehole;
            SelectedBoreholeIndex = boreholeStore.CurrentBoreholeIndex;
            NavigationViewModel = createNavigationViewModel();
            DeleteBoreholeCommand = new DeleteBoreholeCommand(_boreholeStore, SelectedBorehole);
        }

        private void OnCurrentBoreholeChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(SelectedBorehole));
        }
    }
}
