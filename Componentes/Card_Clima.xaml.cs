using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        private Card _card { get; set; }

        public Card_Clima(Card card)
        {
            InitializeComponent();

            _card = card;
        }

        private void Inserir_Valores()
        {
            label_Data.Text = Formatar_Data(_card.Data);
            label_Temperatura.Text = Formatar_Temperatura(_card.TemperaturaAtual);
            label_TemperaturaMin.Text = Formatar_Temperatura(_card.TemperaturaMínima);
            label_TemperaturaMax.Text = Formatar_Temperatura(_card.TemperaturaMáxima);            
            image_Clima.Source = Formatar_Clima(_card.Clima);
        }

        private string Formatar_Data(string Data)
        {
            string retorno = string.Empty;

            if (Data != string.Empty)
            {
                DateTime dataInicio = Convert.ToDateTime(Data);

                retorno = dataInicio.ToString("M");
            }
            else
            {
                retorno = "N/A";
            }

            return retorno;
        }

        private string Formatar_Temperatura(string Temperatura)
        {
            string retorno = string.Empty;

            if (Temperatura != string.Empty)
            {
                retorno = $"{Math.Round(double.Parse(Temperatura), 0)} ºC";
            }
            else
            {
                retorno = "N/A";
            }

            return retorno;
        }

        private BitmapImage Formatar_Clima(Clima clima)
        {
            BitmapImage retorno;
            string Caminho = "/ClimaQuente;component/Imagens/";

            switch (clima)
            {
                case Clima.Sol:
                    Caminho += "Clima_Sol.png";
                    break;
                case Clima.Chuva:
                    Caminho += "Clima_Chuva.png";
                    break;
                case Clima.Chuva_Forte:
                    Caminho += "Clima_ChuvaForte.png";
                    break;
                case Clima.Garoa:
                    Caminho += "Clima_Garoa.png";
                    break;
                case Clima.Neve:
                    Caminho += "Clima_Neve.png";
                    break;
                case Clima.Nublado:
                    Caminho += "Clima_Nublado.png";
                    break;
                case Clima.Sol_Nublado:
                    Caminho += "Clima_SolNublado.png";
                    break;
                case Clima.Sol_Nublado_Chva:
                    Caminho += "Clima_SolNubladoChuva.png";
                    break;
                case Clima.Trovoadas:
                    Caminho += "Clima_Trovoadas.png";
                    break;
                default:
                    Caminho += "Clima_SolNubladoChuva.png";
                    break;
            }

            retorno = new BitmapImage(new Uri(Caminho, UriKind.Relative));

            return retorno;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Inserir_Valores();
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
