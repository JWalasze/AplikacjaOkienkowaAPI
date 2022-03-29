using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;

namespace API
{
    public class City : DbContext
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
            this.BasicCities.Add(new Basic_cities {CityName = city_name});
            this.SaveChanges();
        }

        public void addNewRecord(JSON_localization API_data)
        {
            this.Cities.Add(new Data_city
            {
                city_name = API_data.city_name,
                country_code = API_data.country_code,
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

        public string getAllRecords()
        {
            string str = String.Empty;
            var cities = (from city in this.Cities select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                str += $"ID: {city.ID}, City: {city.city_name}, Aqi: {city.aqi}, Timezone: {city.timezone}, Data pomiaru: {city._date}";
                str += Environment.NewLine;
            }
            return str;
        }

        public string getAllBasicCities()
        {
            string str = String.Empty;
            var b_cities = (from city in this.BasicCities select city).ToList<Basic_cities>();
            foreach (var city in b_cities)
            {
                str += $"Nazwa 'basic' miasta: {city.CityName}";
                str += Environment.NewLine;
            }
            return str;
        }

        public string getSelectedRecordsByCity(string city_name)
        {
            string str = String.Empty;
            var cities = (from city in this.Cities where city.city_name == city_name select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                str += $"ID: {city.ID}, City: {city.city_name}, Aqi: {city.aqi}, Timezone: {city.timezone}, Data pomiaru: {city._date}";
                str += Environment.NewLine;
            }
            return str;
        }

        public string getSelectedRecordsByAqi(int aqi, string mark)
        {
            string str = String.Empty;
            if (mark == ">")
            {
                var cities = (from city in this.Cities where city.aqi > aqi orderby city.aqi select city).ToList<Data_city>();
                foreach (var city in cities)
                {
                    str += $"ID: {city.ID}, City: {city.city_name}, Aqi: {city.aqi}, Timezone: {city.timezone}, Data pomiaru: {city._date}";
                    str += Environment.NewLine;
                }
                return str;
            }
            else if (mark == "<")
            {
                var cities = (from city in this.Cities where city.aqi < aqi orderby city.aqi select city).ToList<Data_city>(); foreach (var city in cities)
                {
                    str += $"ID: {city.ID}, City: {city.city_name}, Aqi: {city.aqi}, Timezone: {city.timezone}, Data pomiaru: {city._date}";
                    str += Environment.NewLine;
                }
                return str;
            }
            else if (mark == "=" || mark == "==")
            {
                var cities = (from city in this.Cities where city.aqi == aqi orderby city.aqi select city).ToList<Data_city>(); foreach (var city in cities)
                {
                    str += $"ID: {city.ID}, City: {city.city_name}, Aqi: {city.aqi}, Timezone: {city.timezone}, Data pomiaru: {city._date}";
                    str += Environment.NewLine;
                }
                return str;
            }
            else
            {
                throw new Exception("Niepoprawnie wybrany znak!");
            }
        }

        public string getSortByAqi()
        {
            string str = String.Empty;
            var cities = (from city in this.Cities orderby city.aqi select city).ToList<Data_city>();
            foreach (var city in cities)
            {
                str += $"ID: {city.ID}, City: {city.city_name}, Aqi: {city.aqi}, Timezone: {city.timezone}, Data pomiaru: {city._date}";
                str += Environment.NewLine;
            }
            return str;
        }

        public int getCityNumberOfMeasurements(string _city_name)
        {
            var cities = (from city in this.Cities where city.city_name == _city_name select city).ToList<Data_city>();
            return cities.Count();
        }

        public async void makeEssentialMeasurements()
        {
            var cities = (from city in this.BasicCities select city).ToList<Basic_cities>();
            foreach (var city in cities)
            {
                var city_2_remove = this.Cities.First(x => x.city_name == city.CityName);
                this.removeRecord(city_2_remove.ID);
                string call = "https://api.weatherbit.io/v2.0/current/airquality?city=" + city.CityName + "&country=&key=039e380a5d124b1985909a1375c64c4d";
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(call);
                JSON_localization API_data = JsonConvert.DeserializeObject<JSON_localization>(response);
                this.addNewRecord(API_data);
            }
        }
    }
}
