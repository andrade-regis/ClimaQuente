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
            try
            {
                DadosDoApp.Retornar_Ip();
                DadosDoApp.Retornar_Localização();
                DadosDoApp.Retornar_Clima();

                Preencher_Endereço();

                Preencher_Cards();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ClimaQuente", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void Preencher_Endereço()
        {
            if(DadosDoApp.Clima != null)
            {
                string estado = DadosDoApp.Clima.City.Country;
                string cidade = DadosDoApp.Clima.City.Name;

                textBlock_Endereço.Text = $"{estado}, {cidade}";
            }
        }

        private void Preencher_Cards()
        {
            try
            {
                if (DadosDoApp.Clima != null && DadosDoApp.Clima.List.Count > 0)
                {
                    string ÚltimaData = string.Empty;

                    StackPanel panel = new StackPanel()
                    {
                        Orientation = Orientation.Vertical
                    };

                    for (int contador = 0; contador < DadosDoApp.Clima.List.Count(); contador++)
                    {
                        Componentes.Card Card = null;
                        Componentes.Card_Clima card_Clima;

                        string _Data = DadosDoApp.Clima.List[contador].DtTxt;
                        string _TemperaturaAtual = DadosDoApp.Clima.List[contador].Main.Temp.ToString();
                        string _TemperaturaMínima = DadosDoApp.Clima.List[contador].Main.TempMin.ToString();
                        string _TemperaturaMaxima = DadosDoApp.Clima.List[contador].Main.TempMax.ToString();
                        string _Clima = DadosDoApp.Clima.List[contador].Weather[0].Id.ToString();

                        card_Clima = new Componentes.Card_Clima(Card = new Componentes.Card(_Data, _TemperaturaAtual, _TemperaturaMínima, _TemperaturaMaxima, _Clima));

                        //A API de Clima, retorna várias previsões do mesmo dia com diferença de horário
                        //Para evitar que mais de um card contenha o mesmo dia, filtramos pela primeira data a ser informada.
                        if (ÚltimaData != card_Clima.label_Data.Text)
                        {
                            ÚltimaData = card_Clima.label_Data.Text;

                            panel.Children.Add(card_Clima);
                        }
                    }

                    scrollViewer_CardsTempo.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    scrollViewer_CardsTempo.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                    scrollViewer_CardsTempo.Content = panel;
                }
                else
                {
                    MessageBox.Show("Não existem dados de clima a serem exibidos!\n App será fechado.", "ClimaQuente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }
    }
}
