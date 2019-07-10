using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using SummitWeather.Interfaces;
using SummitWeather.Models;
using SummitWeather.ViewModels;
using Xamarin.Forms;

namespace SummitWeather
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IWeatherService _weatherService;
        MainViewModel ViewModel;

        private static string apikey = "e63ae9a5453e4cec0d82c6c75131139e";

        public MainPage()
        {
            InitializeComponent();

            _weatherService = RestService.For<IWeatherService>("http://api.openweathermap.org");

            this.BindingContext = ViewModel = new MainViewModel();

        }

        protected async void GetWeather(object sender, EventArgs args)
        {
            var search = (SearchBar)sender;

            if (!string.IsNullOrEmpty(search.Text))
            {
                ViewModel.CurrentWeather = await _weatherService.GetTemp(search.Text, apikey);

                ViewModel.Locations.Add(new SavedLocation { Name = ViewModel.CurrentWeather.Name });
            }

        }
    }
}
