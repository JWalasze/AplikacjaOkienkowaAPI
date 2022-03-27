using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace API
{
    internal static class HTTP
    {
        static HttpClient client = new HttpClient();
        static public JSON_localization API_data;

        public static async void MakeRequest(string city_name, string optional_country = "")
        {
            string call = "https://api.weatherbit.io/v2.0/current/airquality?city=" + city_name + "&country=" + optional_country + "&key=039e380a5d124b1985909a1375c64c4d";
            string response = await client.GetStringAsync(call);
            API_data = JsonConvert.DeserializeObject<JSON_localization>(response);
        }

        public static void ShowData()
        {
            Console.WriteLine(API_data.country_code);
            Console.WriteLine(API_data.city_name);
            Console.WriteLine(API_data.timezone);
            Console.WriteLine(API_data.data[0].aqi);
            Console.WriteLine(API_data.data[0].pollen_level_weed);
        }
    }
}
