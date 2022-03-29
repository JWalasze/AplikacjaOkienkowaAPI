using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class JSON_data
    {
        public int mold_level { get; set; }
        public int aqi { get; set; }
        public double pm10 { get; set; }
        public double co { get; set; }
        public double o3 { get; set; }
        public string predominant_pollen_type { get; set; }
        public double so2 { get; set; }
        public int pollen_level_tree { get; set; }
        public int pollen_level_weed { get; set; }
        public double no2 { get; set; }
        public double pm25 { get; set; }
        public int pollen_level_grass { get; set; }
    }
}
