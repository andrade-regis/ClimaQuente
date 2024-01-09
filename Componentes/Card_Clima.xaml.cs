using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClimaQuente.Componentes
{
    /// <summary>
    /// Interação lógica para Card_Clima.xam
    /// </summary>
    public partial class Card_Clima : UserControl
    {
        public Card_Clima(Card card)
        {
            InitializeComponent();


        }

        private void Inserir_Valores()
        {

        }

    }

    public enum Clima
    {
        Chuva,
        Chuva_Forte,
        Garoa,
        Neve,
        Nublado,
        Sol,
        Sol_Nublado,
        Sol_Nublado_Chva,
        Trovoadas
    }

    public class Card
    {
        public string Data { get; set; }

        public string TemperaturaAtual { get; set; }

        public string TemperaturaMínima { get; set; }

        public string TemperaturaMáxima { get; set; }

        public Clima Clima { get; set; }

        public Card(string data, string temperaturaAtual, string temperaturaMínima, string temperaturaMáxima, string clima)
        {
            Data = data;
            TemperaturaAtual = temperaturaAtual;
            TemperaturaMínima = temperaturaMínima;
            TemperaturaMáxima = temperaturaMáxima;
            Clima = Retornar_Clima(int.Parse(clima));
        }

        private Clima Retornar_Clima(int idClima)
        {
            Clima retorno = new Clima();

            if(idClima >= 200 && idClima < 300)
            {
                retorno = Clima.Trovoadas;
            }
            else if(idClima >= 300 && idClima < 400)
            {
                retorno = Clima.Garoa;
            }
            else if (idClima >= 500 && idClima < 600)
            {
                retorno = Clima.Chuva;
            }
            else if (idClima >= 600 && idClima < 700)
            {
                retorno = Clima.Neve;
            }
            else if (idClima >= 700 && idClima < 800)
            {
                retorno = Clima.Sol_Nublado_Chva;
            }
            else if (idClima == 800)
            {
                retorno = Clima.Sol;
            }
            else if (idClima >= 801 && idClima < 900)
            {
                retorno = Clima.Nublado;
            }
            else
            {
                retorno = Clima.Sol;
            }

            return retorno;
        }
    }
}
