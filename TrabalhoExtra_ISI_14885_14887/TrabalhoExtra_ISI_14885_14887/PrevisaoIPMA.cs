using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_3_
{
    public class PrevisaoDia
    {
        public string precipitaProb { get; set; }
        public string TMin { get; set; }
        public string tMax { get; set; }
        public string predWindDir { get; set; }
        public int idWeatherType { get; set; }
        public int classWindSpeed { get; set; }
        public string longitude { get; set; }
        public string forecastDate { get; set; }
        public int classPrecInt { get; set; }
        public string latitude { get; set; }
    }

    class PrevisaoIPMA
    {
        public string Owner { get; set; }
        public string Country { get; set; }
        public PrevisaoDia[] Data { get; set; }
        public int GlobalIdLocal { get; set; }
        public DateTime DataUpdate { get; set; }
        public string Local { get; set; }
    }
}
