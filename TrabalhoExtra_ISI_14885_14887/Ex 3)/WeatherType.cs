using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_3_
{
    public class WeatherType
    {

        public string Owner { get; set; }
        public string Country { get; set; }
        public TiposTempo[] Data { get; set; }

    }

    public class TiposTempo
    {
        public string descIdWeatherTypeEN { get; set; }
        public string descIdWeatherTypePT { get; set; }
        public int idWeatherType { get; set; }
        
    }
}
