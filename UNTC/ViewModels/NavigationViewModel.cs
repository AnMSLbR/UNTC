using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UNTC.Commands;
using UNTC.Services;

namespace UNTC.ViewModels
{
    internal class NavigationViewModel : BaseViewModel
    {
        public ICommand NavigateDataCommand { get; }
        public ICommand NavigateAddCommand { get; }

        public NavigationViewModel(INavigationService dataNavigationService, INavigationService addNavigationService)
        {
            NavigateDataCommand = new NavigateCommand(dataNavigationService);
            NavigateAddCommand = new NavigateCommand(addNavigationService);
        }

    }
}
