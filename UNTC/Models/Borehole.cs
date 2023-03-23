using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNTC.Models
{
    internal class Borehole : INotifyPropertyChanged
    {
        private string _title;
        private double _depth;
        private double _density;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public double Depth
        {
            get => _depth;
            set
            {
                _depth = value;
                OnPropertyChanged(nameof(Depth));
            }
        }
        public double Density
        {
            get => _density;
            set
            {
                _density = value;
                OnPropertyChanged(nameof(Density));
            }
        }

        public double[] Pressure { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
