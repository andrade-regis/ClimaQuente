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

namespace ClimaQuente.Auxiliar
{
    public static class DadosDoApp
    {
        private static string Ip { get; set; }

        private static Localização Localização { get; set; }

        public static Clima Clima { get; set; }

        private static string KeyLocalização = "";
        private static string KeyClima = "";

        public static async void Retornar_Ip()
        {
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://api.ipify.org");

            if (response.IsSuccessStatusCode)
            {
                Ip = await response.Content.ReadAsStringAsync();
            }
        }

        public static async void Retornar_Localização()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string URL = $"https://api.ip2location.io/?key={KeyLocalização}&ip={Ip}&format=json";

                    // Faz a chamada GET à API
                    HttpResponseMessage response = await client.GetAsync(URL);

                    // Verifica se a requisição foi bem sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Lê o conteúdo da resposta como uma string
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        // Converte a string JSON para um objeto ou estrutura de dados
                        Localização = JsonConvert.DeserializeObject<Localização>(jsonContent);
                    }
                    else
                    {
                        Localização = null;
                        MessageBox.Show("Não foi possivel obter localização", "ClimaQuente",MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (HttpRequestException e)
                {
                        MessageBox.Show(e.Message, "ClimaQuente",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static async void Retornar_Clima()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string URL = $"api.openweathermap.org/data/2.5/forecast/daily?lat={Localização.Latitude}&lon={Localização.Longitude}&cnt={7}&appid={KeyClima}";

                    // Faz a chamada GET à API
                    HttpResponseMessage response = await client.GetAsync(URL);

                    // Verifica se a requisição foi bem sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Lê o conteúdo da resposta como uma string
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        // Converte a string JSON para um objeto ou estrutura de dados
                        Clima = JsonConvert.DeserializeObject<Clima>(jsonContent);
                    }
                    else
                    {
                        Clima = null;
                        MessageBox.Show("Não foi possivel obter clima", "ClimaQuente", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message, "ClimaQuente", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
