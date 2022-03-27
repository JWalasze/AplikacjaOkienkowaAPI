using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace API
{
    internal class Data_city
    {
        public int ID { get; set; }
        public string city_name { get; set; }
        public string timezone { get; set; }
        public string country_code { get; set; }
        public int aqi { get; set; }
        public double co { get; set; }
        public double o3 { get; set; }
        public double so2 { get; set; }
        public double no2 { get; set; }
    }
}
