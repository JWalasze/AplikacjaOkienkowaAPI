using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
//using System.Windows.Controls;

//using System.Web.UI.DataVisualization.Charting;

namespace GUI
{
    public partial class Form1 : Form
    {
        City context;

        public Form1()
        {
            InitializeComponent();
            context = new City();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string city_name = textBox1.Text;
            string optional_country = textBox2.Text;
            string call = "https://api.weatherbit.io/v2.0/current/airquality?city=" + city_name + "&country=" + optional_country + "&key=039e380a5d124b1985909a1375c64c4d";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(call);
            JSON_localization API_data = JsonConvert.DeserializeObject<JSON_localization>(response);

            string str = string.Empty;
            str += $"Kraj: {API_data.country_code}, ";
            str += $"nazwa miasta: {API_data.city_name}" + Environment.NewLine;
            str += $"Data pobrania: {DateTime.Now}" + Environment.NewLine;
            str += $"Aqi (air quality index): {API_data.data[0].aqi}" + Environment.NewLine;
            str += $"Poziom zanieczyszczenia powietrza: " + aqiLevel(API_data.data[0].aqi) + Environment.NewLine;
            str += $"Zawartość CO: {API_data.data[0].co} ug/m3" + Environment.NewLine;
            str += $"Zawartość O3: {API_data.data[0].o3} ug/m3" + Environment.NewLine;
            str += $"Zawartość SO2: {API_data.data[0].so2} ug/m3" + Environment.NewLine;
            str += $"Zawartość NO2: {API_data.data[0].no2} ug/m3" + Environment.NewLine;
            richTextBox1.Text = str;
        }

        private string aqiLevel(int aqi)
        {
            if (aqi > 0 && aqi <= 50)
            {
                return "Bardzo dobry";
            }

            else if (aqi > 50 && aqi <= 100)
            {
                return "Dobry";
            }

            else if (aqi > 100 && aqi <= 150)
            {
                return "Umiarkowany";
            }

            else if (aqi > 150 && aqi <= 200)
            {
                return "Dostateczny";
            }

            else if (aqi > 200 && aqi <= 300)
            {
                return "Zły";
            }

            else if (aqi > 300 && aqi <= 400)
            {
                return "Bardzo zły";
            }

            else if (aqi > 400)
            {
                return "Dramatyczny...";
            }
            else
            {
                return "Niepoprawne aqi!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string city_name = "Ankara";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button2.BackColor = Color.DarkGoldenrod;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string city_name = "Ateny";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button3.BackColor = Color.DarkGoldenrod;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string city_name = "Beijing";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button4.BackColor = Color.DarkGoldenrod;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string city_name = "Lahore";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button5.BackColor = Color.DarkGoldenrod;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string city_name = "Londyn";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button6.BackColor = Color.DarkGoldenrod;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string city_name = "Los Angeles";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button7.BackColor = Color.DarkGoldenrod;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string city_name = "New York";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button8.BackColor = Color.DarkGoldenrod;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string city_name = "Paryż";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button9.BackColor = Color.DarkGoldenrod;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string city_name = "Rzym";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button10.BackColor = Color.DarkGoldenrod;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string city_name = "Warszawa";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button11.BackColor = Color.DarkGoldenrod;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string city_name = "Wrocław";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button12.BackColor = Color.DarkGoldenrod;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string city_name = "Wuhan";
            richTextBox2.Text = context.getSelectedRecordsByCity(city_name);
            button13.BackColor = Color.DarkGoldenrod;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            context.makeEssentialMeasurements();
        }

    }
}
