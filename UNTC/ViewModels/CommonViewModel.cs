using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Models;
using UNTC.Stores;

namespace UNTC.ViewModels
{
    internal class CommonViewModel : BaseViewModel
    {
        public ObservableCollection<Borehole> Boreholes { get; set; }
        public NavigationViewModel NavigationViewModel { get; set; }

        public CommonViewModel(BoreholeStore boreholeStore, Func<NavigationViewModel> createNavigationViewModel)
        {
            Boreholes = boreholeStore.BoreholeList;
            NavigationViewModel = createNavigationViewModel();
        }
    }
}
