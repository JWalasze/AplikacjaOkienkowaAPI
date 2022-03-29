using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new City();

            /*foreach (var item in city_list)
            {
                Task<JSON_localization> API = HTTP.MakeRequest(item);
                //Console.ReadLine();
                Console.WriteLine(item);
                context.addNewRecord(API.Result);
                //Console.ReadLine();
            }*/
            Task<JSON_localization> API = HTTP.MakeRequest("Lahore");
            Console.WriteLine(API.Result.city_name);
            Console.WriteLine(API.Result.data[0].co);
            Console.WriteLine(API.Result.data[0].aqi);
            Console.ReadLine();
            /*for (int i = 76; i < 89; i++)
            {
                context.removeRecord(i);
            }*/
            /*foreach (string city in city_list)
            {
                context.addNewBasicCity(city);
            }*/

            //context.makeEssentialMeasurements();
            Console.WriteLine(context.getAllRecords());
            Console.ReadLine();
            var cities = context.BasicCities.ToList();
            foreach (var c in cities)
            {
                Console.WriteLine(context.getCityNumberOfMeasurements(c.CityName));
            }
            Console.ReadLine();
            
        }
    }
}
