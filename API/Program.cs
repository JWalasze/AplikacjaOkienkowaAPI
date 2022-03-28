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
            List<string> city_list = new List<string>();
            city_list.Add("Wrocław");
            city_list.Add("Paryż");
            city_list.Add("Los Angeles");
            city_list.Add("New York");
            city_list.Add("Wuhan");
            city_list.Add("Rzym");
            city_list.Add("Ankara");
            city_list.Add("Lahore");
            city_list.Add("Ateny");
            city_list.Add("Dhaka");
            city_list.Add("Beijing");
            city_list.Add("Londyn");
            city_list.Add("Warszawa");
            HTTP.MakeRequest("Beijing");
            Console.ReadLine();
            Console.WriteLine(HTTP.API_data.data[0].aqi.ToString());
            Console.ReadLine();

            foreach (var item in city_list)
            {
                HTTP.MakeRequest(item);
                Console.ReadLine();
                HTTP.ShowData();
                context.addNewRecord();
                Console.ReadLine();
            }

            context.showAllRecords();
            Console.ReadLine();
            
        }
    }
}
