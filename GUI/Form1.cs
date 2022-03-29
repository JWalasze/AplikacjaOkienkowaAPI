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

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city_name = textBox1.Text;
            Task<JSON_localization> task = HTTP.MakeRequest("Paris");
            string str = string.Empty;
            str += $"Kraj: {task.Result.country_code}, ";
            str += $"nazwa miasta: {task.Result.city_name}" + Environment.NewLine;
            str += $"Data pobrania: {DateTime.Now}" + Environment.NewLine;
            str += $"Aqi (air quality index): {task.Result.data[0].aqi}" + Environment.NewLine;
            str += $"Poziom zanieczyszczenia powietrza: " + aqiLevel(task.Result.data[0].aqi) + Environment.NewLine;
            str += $"Zawartość CO: {task.Result.data[0].co} ug/m3" + Environment.NewLine;
            str += $"Zawartość O3: {task.Result.data[0].o3} ug/m3" + Environment.NewLine;
            str += $"Zawartość SO2: {task.Result.data[0].so2} ug/m3" + Environment.NewLine;
            str += $"Zawartość NO2: {task.Result.data[0].no2} ug/m3" + Environment.NewLine;
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

        //private 
    }
}
