using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using static PM02RestApi.Models.Countries;
using System.Diagnostics;

namespace PM02RestApi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            double Latitud = Convert.ToDouble(txtLat.Text);
            double Longitud = Convert.ToDouble(txtLng.Text);
            String NombreP = txtNamep.Text;
            String CapitalP = txtCapitalp.Text;
            Pin pin = new Pin
            {
                Label = NombreP,
                Address = CapitalP,
                Type = PinType.Place,
                Position = new Position(Latitud, Longitud)
            };


            Maps.Pins.Add(pin);


            //var location = await Geolocation.GetLocationAsync();

            //if (location == null)
            //{
            //    location = await Geolocation.GetLastKnownLocationAsync();
            //}

            Maps.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitud, Longitud), Distance.FromMiles(1)));

            var localizacion = CrossGeolocator.Current;

            if (localizacion != null)
            {
                localizacion.PositionChanged += Locatilazion_PositionChanged;

                if (!localizacion.IsListening)
                {
                    Debug.WriteLine("StarListeningAsync");
                    await localizacion.StartListeningAsync(TimeSpan.FromSeconds(10), 100);

                }

                var posicion = await localizacion.GetPositionAsync();
                var mapac = new Position(Latitud, Longitud);
                Maps.MoveToRegion(MapSpan.FromCenterAndRadius(mapac, Distance.FromMiles(1)));

            }

            else
            {
                await localizacion.GetLastKnownLocationAsync();
                var posicion = await localizacion.GetPositionAsync();
                var mapac = new Position(Latitud, Longitud);


                Maps.MoveToRegion(new MapSpan(mapac, 2, 2));

            }
        }



        private void Locatilazion_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {

            double Latitud = Convert.ToDouble(txtLat.Text);
            double Longitud = Convert.ToDouble(txtLng.Text);
            var mapac = new Position(Latitud, Longitud);
            Maps.MoveToRegion(new MapSpan(mapac, 2, 2));

        }







    }
}