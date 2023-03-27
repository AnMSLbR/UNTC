using LiveCharts;
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
        private Borehole _borehole;
        public Borehole Borehole { get => _borehole; }
        public string Title { get => Borehole?.Title; }
        public string Depth { get => Borehole?.Depth.ToString(); }
        public string Density { get => Borehole?.Density.ToString(); }
        public Dictionary<double, double> PressureDependence { get => Borehole?.PressureDependence; }
        public bool IsBoreholeSelected { get => Borehole != null; }

        private BoreholeChart _chart;
        public SeriesCollection SeriesCollection { get => _chart.SeriesCollection; }

        public DataViewModel(BoreholeStore boreholeStore)
        {
            _boreholeStore = boreholeStore;
            _borehole = _boreholeStore.CurrentBorehole;
            _boreholeStore.CurrentBoreholeChanged += OnCurrentBoreholeChanged;

            _chart = new BoreholeChart();
            _chart.Build(_borehole);
        }

        private void OnCurrentBoreholeChanged(object sender, EventArgs e)
        {
            _borehole = _boreholeStore.CurrentBorehole;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Depth));
            OnPropertyChanged(nameof(Density));
            OnPropertyChanged(nameof(PressureDependence));
            OnPropertyChanged(nameof(IsBoreholeSelected));
            _chart.Build(_borehole);
            OnPropertyChanged(nameof(SeriesCollection));
        }

        public void UnsubscribeFromEvents()
        {
            _boreholeStore.CurrentBoreholeChanged -= OnCurrentBoreholeChanged;
        }
    }
}
