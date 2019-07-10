using System;
using System.ComponentModel;

namespace SummitWeather.Models
{
    public class SavedLocation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Zip { get; set; }
        public string Name { get; set; }
        public double Temp { get; set; }
    }
}
