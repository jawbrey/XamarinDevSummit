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
using Xamarin.Essentials;
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

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await GetLocation();
        }


        protected async void GetWeather(object sender, EventArgs args)
        {
          
            if (!string.IsNullOrEmpty(ViewModel.Zip))
            {
                ViewModel.CurrentWeather = await _weatherService.GetTemp(ViewModel.Zip, apikey);

                var loc = new SavedLocation
                {
                    Name = ViewModel.CurrentWeather.Name,
                    Temp = ViewModel.CurrentWeather.Main.Temp,
                    Zip = ViewModel.Zip
                };

                if (ViewModel.Locations.Count(x => x.Zip == loc.Zip) <= 0)
                {
                    App.Database.SaveItem(loc);
                    ViewModel.Locations.Add(loc);
                }
            }

        }

        private async Task GetLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                    var placemark = placemarks?.FirstOrDefault();

                    if (placemark != null)
                    {
                        ViewModel.Zip = placemark.PostalCode;
                        GetWeather(null, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}


