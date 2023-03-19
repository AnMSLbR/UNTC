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
        private string _title;
        private string _depth;
        private string _density;
        private BoreholeStore _boreholeStore;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Depth
        {
            get => _depth;
            set
            {
                _depth = value;
                OnPropertyChanged(nameof(Depth));
            }
        }
        public string Density
        {
            get => _density;
            set
            {
                _density = value;
                OnPropertyChanged(nameof(Density));
            }
        }
        public DataViewModel(BoreholeStore boreholeStore)
        {
            _boreholeStore = boreholeStore;        
            _boreholeStore.CurrentBoreholeChanged += OnCurrentBoreholeChanged;
            SetProperties();
        }

        private void OnCurrentBoreholeChanged(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            Title = _boreholeStore.CurrentBorehole?.Title;
            Depth = _boreholeStore.CurrentBorehole?.Depth.ToString();
            Density = _boreholeStore.CurrentBorehole?.Density.ToString();
        }
    }
}
