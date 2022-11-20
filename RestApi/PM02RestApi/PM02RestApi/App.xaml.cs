using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02RestApi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            MainPage = new NavigationPage(new CountriesPage());
            //MainPage = new CountriesPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
