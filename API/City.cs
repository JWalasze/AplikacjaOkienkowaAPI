using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;

namespace API
{
    internal class City : DbContext
    {
        public virtual DbSet<Data_city> Cities { get; set; }
        
        public void addNewRecord()
        {
            this.Cities.Add(new Data_city
            {
                city_name = HTTP.API_data.city_name,
                country_code = HTTP.API_data.city_name,
                timezone = HTTP.API_data.timezone,
                aqi = HTTP.API_data.data[0].aqi,
                co = HTTP.API_data.data[0].co,
                o3 = HTTP.API_data.data[0].o3,
                no2 = HTTP.API_data.data[0].no2,
                so2 = HTTP.API_data.data[0].so2,
                _date = DateTime.Now,
                
            });
            this.SaveChanges();
        }

        public void removeRecord(int ID_value)
        {
            var city = this.Cities.First(x => x.ID == ID_value);
            this.Cities.Remove(city);
            this.SaveChanges();
        }

        public void removeSelectedCityRecords(string city_name)
        {
            var cities = (from city in this.Cities where city.city_name == city_name select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                this.Cities.Remove(city);
            }
            this.SaveChanges();
        }

        public void showAllRecords()
        {
            var cities = (from city in this.Cities select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}", city.ID, city.city_name, city.aqi, city.timezone);
            }
        }

        public void showSelectedRecordsByCity(string city_name)
        {
            var cities = (from city in this.Cities where city.city_name == city_name select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}", city.ID, city.city_name, city.aqi, city.timezone);
            }
        }

        public void showSelectedRecordsByAqi(int aqi, string mark)
        {
            if (mark == ">")
            {
                var cities = (from city in this.Cities where city.aqi > aqi orderby city.aqi select city).ToList<Data_city>();
                foreach (var city in cities)
                {
                    Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}", city.ID, city.city_name, city.aqi, city.timezone);
                }
            }
            else if (mark == "<")
            {
                var cities = (from city in this.Cities where city.aqi < aqi orderby city.aqi select city).ToList<Data_city>(); foreach (var city in cities)
                {
                    Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}", city.ID, city.city_name, city.aqi, city.timezone);
                }
            }
            else if (mark == "=" || mark == "==")
            {
                var cities = (from city in this.Cities where city.aqi == aqi orderby city.aqi select city).ToList<Data_city>(); foreach (var city in cities)
                {
                    Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}", city.ID, city.city_name, city.aqi, city.timezone);
                }
            }
            else
            {
                throw new Exception("Niepoprawnie wybrany znak!");
            }
        }

        public void sortByAqi()
        {
            var cities = (from city in this.Cities orderby city.aqi select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}", city.ID, city.city_name, city.aqi, city.timezone);
            }
        }
    }
}
