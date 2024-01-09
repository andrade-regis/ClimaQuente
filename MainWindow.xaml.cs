using ClimaQuente.Auxiliar;
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

namespace ClimaQuente
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Iniciar();
        }

        private void Iniciar()
        {
            DadosDoApp.Retornar_Ip();
            DadosDoApp.Retornar_Localização();
            DadosDoApp.Retornar_Clima();
        }

        private void Preencher_Cards()
        {
            if (DadosDoApp.Clima != null)
            {
                StackPanel panel = new StackPanel()
                {
                    Orientation = Orientation.Vertical
                };

                for(int contador = 0; contador < DadosDoApp.Clima.List.Count(); contador++)
                {
                    string _Data = DateTime.Now.AddDays(contador).ToString("M");
                    string _TemperaturaAtual = DadosDoApp.Clima.List[contador].Temp.Day.ToString();
                    string _TemperaturaMínima = DadosDoApp.Clima.List[contador].Temp.Min.ToString();
                    string _TemperaturaMaxima = DadosDoApp.Clima.List[contador].Temp.Max.ToString();
                    string _Clima = DadosDoApp.Clima.List[contador].Weather[0].Id.ToString();

                    Componentes.Card Card = new Componentes.Card(_Data, _TemperaturaAtual, _TemperaturaMínima, _TemperaturaMaxima, _Clima);

                }
            }
            else
            {

            }
        }
    }
}
