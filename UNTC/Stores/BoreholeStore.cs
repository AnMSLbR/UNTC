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
                new Borehole{ Title="Скважина 1", Depth=355, Density=0.89, 
                    PressureAtStep = new double[] { 0, 53, 78, 107, 155, 189, 217, 256, 312},
                    DepthAtStep = new double[] { 0, 22, 48, 101, 157, 197, 236, 286 ,355} },
                new Borehole{ Title="Скважина 2", Depth=241, Density=0.85, 
                    PressureAtStep = new double[] { 0, 48, 66, 120, 148, 191, 222, 273, 305},
                    DepthAtStep = new double[] { 0, 17, 53, 97, 155, 202, 222, 236 , 241 } },
                new Borehole{ Title="Скважина 3", Depth=472, Density=0.91, 
                    PressureAtStep = new double[] { 0, 22, 45, 68, 108, 167, 203, 266, 289},
                    DepthAtStep = new double[] { 0, 33, 57, 101, 157, 256, 302, 387 , 472 } },
            };
        }
        protected void OnPropertyChanged()
        {
            CurrentBoreholeChanged?.Invoke(this, new EventArgs());
        }
    }
}
