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
        private Borehole _borehole;

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
            _borehole = boreholeStore.CurrentBorehole;
            Title = _borehole?.Title;
            Depth = _borehole?.Depth.ToString();
            Density = _borehole?.Density.ToString();
        }
    }
}
