using Plugin.Geolocator.Abstractions;
using PM02RestApi.Controllers;
using PM02RestApi.Models;
using PM02RestApi.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PM02RestApi.View.CountryViewModel;

namespace PM02RestApi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountriesPage : ContentPage
    {
        public string region;

        public CountriesPage()
        {
            InitializeComponent();
            BindingContext = new CountryViewModel();

        }



        private async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {

                 var current = Connectivity.NetworkAccess;
           
            if (current == NetworkAccess.Internet)
            {
                var picker = (Picker)sender;
                int selectedIndex = picker.SelectedIndex;

                if (selectedIndex == 0)
                {
                    List<Countries.Example> listapersonas = new List<Countries.Example>();
                    listapersonas = await CountriesControllers.getpaisesafrica();
                    lstPersonas.ItemsSource = listapersonas;
                   

                }
                else if (selectedIndex == 1)
                {
                    List<Countries.Example> listapersonas = new List<Countries.Example>();
                    listapersonas = await CountriesControllers.getpaisesamerica();
                    lstPersonas.ItemsSource = listapersonas;
                 

                }
                else if (selectedIndex == 2)
                {
                    List<Countries.Example> listapersonas = new List<Countries.Example>();
                    listapersonas = await CountriesControllers.getpaisesasia();
                    lstPersonas.ItemsSource = listapersonas;
                   

                }
                else if(selectedIndex == 3)
                {
                    List<Countries.Example> listapersonas = new List<Countries.Example>();
                    listapersonas = await CountriesControllers.getpaiseseuropa();
                    lstPersonas.ItemsSource = listapersonas;
                 
                }
                else if (selectedIndex == 4)
                {
                    List<Countries.Example> listapersonas = new List<Countries.Example>();
                    listapersonas = await CountriesControllers.getpaisesoceania();
                    lstPersonas.ItemsSource = listapersonas;
              
                }

            }
            else
            {
                await DisplayAlert("Conexion", "No se encuentra conectado a internet", "Ok");

            }
        }

        private async void lstPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var valores = e.SelectedItem as Countries.Example;
            String nombrepais = valores.name.common;
            String capitalpais = valores.capital[0];
            Double Latvar = valores.latlng[0];
            Double Longvar = valores.latlng[1];
            //await DisplayAlert("Error", "Pais: "+nombrepais, "OK");
            //await DisplayAlert("Error", "Lat: "+Latvar.ToString()+" Log: "+Longvar.ToString(), "OK");
            LatLongcs.dataubic classdata = new LatLongcs.dataubic
            {
                lat = Latvar,
                lng = Longvar,
                namep = nombrepais,
                capitalp = capitalpais,
            };
            var page = new MapsPage();
            page.BindingContext = classdata;
            //await Navigation.PushAsync(page);
            await Navigation.PushAsync(new NavigationPage(page));


           

        }
    }
}