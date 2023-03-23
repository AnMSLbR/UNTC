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

        private BoreholeChart _chart;
        public SeriesCollection SeriesCollection { get => _chart.SeriesCollection; }
        public string[] Labels { get => _chart.Labels; }
        public Func<double, string> YFormatter { get => _chart.YFormatter; }


        public DataViewModel(BoreholeStore boreholeStore)
        {
            _boreholeStore = boreholeStore;
            _borehole = _boreholeStore.CurrentBorehole;
            _boreholeStore.CurrentBoreholeChanged += OnCurrentBoreholeChanged;
            _chart = new BoreholeChart(_borehole, 10);
        }



        private void OnCurrentBoreholeChanged(object sender, EventArgs e)
        {
            _borehole = _boreholeStore.CurrentBorehole;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Depth));
            OnPropertyChanged(nameof(Density));
            _chart.Build(_borehole, 10);
            OnPropertyChanged(nameof(SeriesCollection));
            OnPropertyChanged(nameof(Labels));
            OnPropertyChanged(nameof(YFormatter));
        }

        public void UnsubscribeFromEvents()
        {
            _boreholeStore.CurrentBoreholeChanged -= OnCurrentBoreholeChanged;
        }
    }
}
