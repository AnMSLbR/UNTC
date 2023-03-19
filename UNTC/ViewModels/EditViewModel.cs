﻿using System;
using System.Collections.Generic;
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
    internal class EditViewModel : BaseViewModel
    {
        private Borehole _borehole;
        public ICommand NavigateDataCommand { get; }
        public ICommand SaveBoreholeCommand { get; }
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

        public EditViewModel(BoreholeStore boreholeStore, INavigationService dataNavigationService)
        {
            _borehole = new Borehole();
            NavigateDataCommand = new NavigateCommand(dataNavigationService);
            SaveBoreholeCommand = new SaveBoreholeCommand(boreholeStore, _borehole);
        }
    }
}
