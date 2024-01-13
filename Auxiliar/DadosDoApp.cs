using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Media.Animation;
using System.Windows;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace ClimaQuente.Auxiliar
{
    public static class DadosDoApp
    {
        private static string Ip { get; set; }

        private static Localização Localização { get; set; }

        public static Clima Clima { get; set; }

        private static string KeyLocalização = "YourKey";
        private static string KeyClima = "YourKey";

        public static async void Retornar_Ip()
        {
            Ip = string.Empty;

            try
            {
                using HttpClient client = new HttpClient();

                HttpResponseMessage response = client.GetAsync("https://api.ipify.org").GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    Ip = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Erro IP\n" + e.Message);
            }
        }

        public static async void Retornar_Localização()
        {
            Localização = null;

            try
            {
                using HttpClient client = new HttpClient();

                string URL = $"https://api.ip2location.io/?key={KeyLocalização}&ip={Ip}&format=json";

                HttpResponseMessage response = client.GetAsync(URL).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    Localização = JsonConvert.DeserializeObject<Localização>(jsonContent);
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Erro Localização\n" + e.Message);
            }
        }

        public static async void Retornar_Clima()
        {
            Clima = null;

            try
            {
                HttpClient client = new HttpClient();

                string URL = $"https://api.openweathermap.org/data/2.5/forecast?lat={Localização.Latitude.ToString().Replace(',', '.')}&lon={Localização.Longitude.ToString().Replace(',', '.')}&appid={KeyClima}&units=metric";
                HttpResponseMessage response = client.GetAsync(URL).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    Clima = JsonConvert.DeserializeObject<Clima>(jsonContent);
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Erro Clima\n" + e.Message);
            }
        }
    }
}
