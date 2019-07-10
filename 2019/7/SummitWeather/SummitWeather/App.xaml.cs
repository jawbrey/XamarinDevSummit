using System;
using System.IO;
using SummitWeather.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SummitWeather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        static LocationDB database;

        public static LocationDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new LocationDB(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Location.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
