using PM02RestApi.Controllers;
using PM02RestApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PM02RestApi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnget_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                List<Personas> listapersonas = new List<Personas>();


                listapersonas = await PersonasControllers.getpersonas();


                lstPersonas.ItemsSource = listapersonas;

            }
            else
            {
                await DisplayAlert("Conexion", "No se encuentra conectado a internet", "Ok");
            }
        }
    }
}
