using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNTC.Stores;
using UNTC.ViewModels;

namespace UNTC.Services
{
    internal class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<CommonViewModel> _createNavigationViewModel;
        private readonly Func<TViewModel> _createViewModel;

        public LayoutNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel, Func<CommonViewModel> createNavigationViewModel)
        {
            _navigationStore = navigationStore;
            _createNavigationViewModel = createNavigationViewModel;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            UnreferenceDataViewModel();
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationViewModel(), _createViewModel());
        }

        private void UnreferenceDataViewModel()
        {
            if (_navigationStore.CurrentViewModel != null && _navigationStore.CurrentViewModel is LayoutViewModel)
            {
                LayoutViewModel currentViewModel = _navigationStore.CurrentViewModel as LayoutViewModel;
                if (currentViewModel.BoreholeViewModel is DataViewModel)
                {
                    (currentViewModel.BoreholeViewModel as DataViewModel).UnsubscribeFromEvents();
                }
            }
        }
    }
}
