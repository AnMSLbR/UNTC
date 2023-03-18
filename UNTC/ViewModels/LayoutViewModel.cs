using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNTC.ViewModels
{
    internal class LayoutViewModel : BaseViewModel
    {
        public BaseViewModel CommonViewModel { get; }
        public BaseViewModel BoreholeViewModel { get; }
        public LayoutViewModel(BaseViewModel commonViewModel, BaseViewModel boreholeViewModel)
        {
            CommonViewModel = commonViewModel;
            BoreholeViewModel = boreholeViewModel;
        }
    }
}
