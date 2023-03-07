using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;

namespace UNTC.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Borehole> Boreholes { get; set; }
        public MainViewModel()
        {
            Boreholes = new ObservableCollection<Borehole>
            {
                new Borehole{ Title="Скважина 1", Depth=355, Density=0.89},
                new Borehole{ Title="Скважина 2", Depth=241, Density=0.85},
                new Borehole{ Title="Скважина 3", Depth=472, Density=0.91},
            };
        }
    }
}
