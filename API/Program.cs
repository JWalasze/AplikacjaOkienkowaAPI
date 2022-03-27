using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new City();
            List<string> city_list = new List<string>();
            city_list.Add("Wrocław");
            city_list.Add("Paris");
            city_list.Add("Los Angeles");
            city_list.Add("New York");
            city_list.Add("Wuhan");
            city_list.Add("Rzym");
            city_list.Add("Ankara");
            city_list.Add("Lahore");
            city_list.Add("Ateny");
            city_list.Add("Dhaka");

            HTTP.MakeRequest("Berlin");
            Console.ReadLine();
            HTTP.ShowData();
            context.addNewRecord();
            context.showAllRecords();
            Console.ReadLine();
            context.removeSelectedCityRecords("Berlin");
            Console.ReadLine();
            context.showAllRecords();
            Console.ReadLine();
            context.showSelectedRecordsByAqi(100, ">");
            Console.ReadLine();
            /*foreach (var item in city_list)
            {
                HTTP.MakeRequest(item);
                Console.ReadLine();
                HTTP.ShowData();
                context.addNewRecord();
                Console.ReadLine();
            }*/

            context.showAllRecords();
            Console.ReadLine();
            context.showSelectedRecordsByCity("Wuhan");
            Console.ReadLine();
            context.sortByAqi();
            Console.ReadLine();
        }
    }
}
