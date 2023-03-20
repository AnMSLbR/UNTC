using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;

namespace UNTC.Stores
{
    internal class BoreholeStore
    {
        private Borehole _currentBorehole;

        public event EventHandler CurrentBoreholeChanged;

        public BindingList<Borehole> BoreholeList { get; set; }

        public Borehole CurrentBorehole 
        { 
            get => _currentBorehole; 
            set 
            { 
                _currentBorehole = value;
                OnPropertyChanged();
            }
        }

        public int CurrentBoreholeIndex { get; set; }

        public BoreholeStore()
        {
            BoreholeList = new BindingList<Borehole>
            {
                new Borehole{ Title="Скважина 1", Depth=355, Density=0.89},
                new Borehole{ Title="Скважина 2", Depth=241, Density=0.85},
                new Borehole{ Title="Скважина 3", Depth=472, Density=0.91},
            };
        }
        protected void OnPropertyChanged()
        {
            CurrentBoreholeChanged?.Invoke(this, new EventArgs());
        }
    }
}
