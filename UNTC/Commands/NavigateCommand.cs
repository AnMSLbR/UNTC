using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Services;
using UNTC.Stores;
using UNTC.ViewModels;

namespace UNTC.Commands
{
    internal class NavigateCommand<TViewModel> : BaseCommand
        where TViewModel : BaseViewModel
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
