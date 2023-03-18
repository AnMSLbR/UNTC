using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;

namespace UNTC.Stores
{
    internal class BoreholeStore
    {
        private Borehole _currentBorehole;
        public ObservableCollection<Borehole> BoreholeList { get; set; }

        public Borehole CurrentBorehole 
        { 
            get => _currentBorehole; 
            set 
            { 
                _currentBorehole = value; 
            }
        }

        public BoreholeStore()
        {
            BoreholeList = new ObservableCollection<Borehole>
            {
                new Borehole{ Title="Скважина 1", Depth=355, Density=0.89},
                new Borehole{ Title="Скважина 2", Depth=241, Density=0.85},
                new Borehole{ Title="Скважина 3", Depth=472, Density=0.91},
            };
        }
    }
}
