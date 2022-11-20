using PM02RestApi.Controllers;
using PM02RestApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PM02RestApi.View
{
    public class CountryViewModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public List<Region> Regioneslist { get; set; }

        public CountryViewModel()
        {
            Regioneslist = GetRegiones().OrderBy(t => t.value).ToList();
        }

        private Region _selectedRegion { get; set; }
        public  Region SelectedRegion
        {
            get { return _selectedRegion; }
            set
            {
                if (_selectedRegion != value)
                {
                    _selectedRegion = value;
                    MyRegion = "Region Seleccionada: " + _selectedRegion.value;
                }
            }
        }

        private string _myRegion;
        public String MyRegion
        {
            get { return _myRegion; }
            set
            {
                if (_myRegion != value)
                {
                    _myRegion = value;
                    OnPropertyChanged();                }
            }
        }


        public List<Region> GetRegiones()
        {
            var region = new List<Region>()
            {
                new Region(){Key = 1, value = "Africa"},
                new Region(){Key = 2, value = "America"},
                new Region(){Key = 3, value = "Asia"},
                new Region(){Key = 4, value = "Europa"},
                new Region(){Key = 5, value = "Oceanía"}
            };

            return region;
        }

        public class Region
        {
            public int Key { get; set; }
            public string value { get; set; }
        }

    }



}
