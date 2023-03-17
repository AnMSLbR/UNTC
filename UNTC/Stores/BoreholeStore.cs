using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;

namespace UNTC.Stores
{
    internal class BoreholeStore
    {
        private Borehole _currentBorehole;

        public Borehole CurrentBorehole 
        { 
            get => _currentBorehole; 
            set 
            { 
                _currentBorehole = value; 
            }
        }
    }
}
