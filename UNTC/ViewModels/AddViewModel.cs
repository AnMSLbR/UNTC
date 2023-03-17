﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UNTC.Commands;
using UNTC.Models;
using UNTC.Services;
using UNTC.Stores;

namespace UNTC.ViewModels
{
    internal class AddViewModel : BaseViewModel
    {
        private Borehole _borehole;
        public NavigationViewModel NavigationViewModel { get; }
        public ICommand NavigateDataCommand { get; }
        public string Title 
        {
            get => _borehole.Title;
            set 
            { 
                _borehole.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public double Depth
        {
            get => _borehole.Depth;
            set
            {
                _borehole.Depth = value;
                OnPropertyChanged(nameof(Depth));
            }
        }
        public double Density
        {
            get => _borehole.Density;
            set
            {
                _borehole.Density = value;
                OnPropertyChanged(nameof(Density));
            }
        }


        public AddViewModel(NavigationViewModel navigationViewModel, BoreholeStore boreholeStore, NavigationService<DataViewModel> dataNavigationService)
        {
            NavigationViewModel = navigationViewModel;
            _borehole = new Borehole();
            boreholeStore.CurrentBorehole = _borehole;
            //NavigateDataCommand = new NavigateCommand<DataViewModel>(dataNavigationService);
        }

    }
}