using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;
using UNTC.Stores;

namespace UNTC.Commands
{
    internal class DeleteBoreholeCommand : BaseCommand
    {
        private readonly BoreholeStore _boreholeStore;
        private readonly Borehole _borehole;

        public DeleteBoreholeCommand(BoreholeStore boreholeStore, Borehole borehole)
        {
            _boreholeStore = boreholeStore;
            _borehole = borehole;
        }

        public override void Execute(object parameter)
        {
            var index = _boreholeStore.CurrentBoreholeIndex;
            _boreholeStore.BoreholeList.RemoveAt(index);
            _boreholeStore.CurrentBorehole = null;
        }
    }
}
