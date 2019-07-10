using System;
using System.ComponentModel;
using SQLite;

namespace SummitWeather.Models
{
    public class SavedLocation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Zip { get; set; }
        public string Name { get; set; }
        public double Temp { get; set; }
    }
}
