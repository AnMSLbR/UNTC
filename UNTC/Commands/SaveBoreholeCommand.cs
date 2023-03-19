using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;
using UNTC.Services;
using UNTC.Stores;

namespace UNTC.Commands
{
    internal class SaveBoreholeCommand : BaseCommand
    {
        private readonly BoreholeStore _boreholeStore;
        private readonly Borehole _borehole;

        public SaveBoreholeCommand(BoreholeStore boreholeStore, Borehole borehole)
        {
            _boreholeStore = boreholeStore;
            _borehole = borehole;
        }

        public override void Execute(object parameter)
        {
            _boreholeStore.BoreholeList.Add(_borehole);
            _boreholeStore.CurrentBorehole = _borehole;
        }
    }
}
