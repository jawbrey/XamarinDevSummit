using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SummitWeather.Models;

namespace SummitWeather.ViewModels
{

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            CurrentWeather = null;
            Locations = new ObservableCollection<SavedLocation>();
        }

        public WeatherModel CurrentWeather { get; set; }
        public ObservableCollection<SavedLocation> Locations { get; set; }
    }

}
