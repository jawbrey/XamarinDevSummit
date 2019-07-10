using System;
using System.Collections.Generic;
using SummitWeather.Models;
using Xamarin.Forms;

namespace SummitWeather
{
    public partial class WeatherDetail : ContentPage
    {
        public WeatherDetail(SavedLocation data)
        {
            InitializeComponent();

            this.BindingContext = data;
        }
    }
}
