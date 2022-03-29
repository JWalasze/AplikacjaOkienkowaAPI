using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace API
{
    public static class HTTP
    {
        static HttpClient client = new HttpClient();
       
        public static async Task<JSON_localization> MakeRequest(string city_name, string optional_country = "")
        {
            string call = "https://api.weatherbit.io/v2.0/current/airquality?city=" + city_name + "&country=" + optional_country + "&key=039e380a5d124b1985909a1375c64c4d";
            string response = await client.GetStringAsync(call);
            JSON_localization API_data = JsonConvert.DeserializeObject<JSON_localization>(response);
            return API_data;
        }
    }
}
