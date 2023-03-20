using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UNTC.Commands;
using UNTC.Models;
using UNTC.Services;
using UNTC.Stores;

namespace UNTC.ViewModels
{
    internal class DataViewModel : BaseViewModel
    {
        private BoreholeStore _boreholeStore;
        public string Title { get => Borehole?.Title; }
        public string Depth { get => Borehole?.Depth.ToString(); }
        public string Density { get => Borehole?.Density.ToString(); }
        public Borehole Borehole { get => _boreholeStore.CurrentBorehole; }

        public DataViewModel(BoreholeStore boreholeStore)
        {
            _boreholeStore = boreholeStore;        
            _boreholeStore.CurrentBoreholeChanged += OnCurrentBoreholeChanged;
        }

        private void OnCurrentBoreholeChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Depth));
            OnPropertyChanged(nameof(Density));
        }

        public void UnsubscribeFromEvents()
        {
            _boreholeStore.CurrentBoreholeChanged -= OnCurrentBoreholeChanged;
        }
    }
}
