using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Threading;

namespace API
{
    internal class City : DbContext
    {
        public virtual DbSet<Data_city> Cities { get; set; }
        
        public virtual DbSet<Basic_cities> BasicCities { get; set; }

        public void addNewBasicCity(string city_name)
        {
            var cities = (from city in this.BasicCities select city).ToList<Basic_cities>();
            foreach (var c in cities)
            {
                if (c.CityName == city_name)
                {
                    return;
                }
            }
            this.BasicCities.Add(new Basic_cities { CityName = city_name});
            this.SaveChanges();
        }

        public void addNewRecord(JSON_localization API_data)
        {
            this.Cities.Add(new Data_city
            {
                city_name = API_data.city_name,
                country_code = API_data.city_name,
                timezone = API_data.timezone,
                aqi = API_data.data[0].aqi,
                co = API_data.data[0].co,
                o3 = API_data.data[0].o3,
                no2 = API_data.data[0].no2,
                so2 = API_data.data[0].so2,
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

        //Konsolowa - trzeba przerobić na okienkową
        public void showAllRecords()
        {
            var cities = (from city in this.Cities select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}, Data pomiaru: {4}", city.ID, city.city_name, city.aqi, city.timezone, city._date);
            }
            var b_cities = (from city in this.BasicCities select city).ToList<Basic_cities>();
            foreach (var city in b_cities)
            {
                Console.WriteLine("Nazwa basic miasta: {0}", city.CityName);
            }
        }

        //-||-
        public void showSelectedRecordsByCity(string city_name)
        {
            var cities = (from city in this.Cities where city.city_name == city_name select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}, Data pomiaru: {4}", city.ID, city.city_name, city.aqi, city.timezone, city._date);
            }
        }

        //-||-
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

        //-||-
        public void sortByAqi()
        {
            var cities = (from city in this.Cities orderby city.aqi select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                Console.WriteLine("ID: {0}, City: {1}, Aqi: {2}, Timezone: {3}", city.ID, city.city_name, city.aqi, city.timezone);
            }
        }

        public int getCityNumberOfMeasurements(string _city_name)
        {
            var cities = (from city in this.Cities where city.city_name == _city_name select city).ToList<Data_city>();
            return cities.Count();
        }

        public void makeEssentialMeasurements()
        {
            var cities = (from city in this.BasicCities select city).ToList<Basic_cities>();
            foreach (var city in cities)
            {
                Task<JSON_localization> API = HTTP.MakeRequest(city.CityName);
                this.addNewRecord(API.Result);
            }
        }
    }
}
