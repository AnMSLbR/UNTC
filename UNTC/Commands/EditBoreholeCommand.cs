using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;
using UNTC.Stores;

namespace UNTC.Commands
{
    internal class EditBoreholeCommand : BaseCommand
    {
        private readonly BoreholeStore _boreholeStore;
        private readonly Borehole _borehole;

        public EditBoreholeCommand(BoreholeStore boreholeStore, Borehole borehole)
        {
            _boreholeStore = boreholeStore;
            _borehole = borehole;
        }

        public override void Execute(object parameter)
        {
            var index = _boreholeStore.CurrentBoreholeIndex;
            _boreholeStore.BoreholeList[index].Title = _borehole.Title;
            _boreholeStore.BoreholeList[index].Depth = _borehole.Depth;
            _boreholeStore.BoreholeList[index].Density = _borehole.Density;
            _boreholeStore.CurrentBorehole = _borehole;
        }
    }
}
