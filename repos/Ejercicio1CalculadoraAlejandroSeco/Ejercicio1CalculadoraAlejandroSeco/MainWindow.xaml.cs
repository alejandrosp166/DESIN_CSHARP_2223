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

namespace Ejercicio1CalculadoraAlejandroSeco
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)radioSuma.IsChecked)
                {
                    textSol.Text = sumar(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));
                }
                else if ((bool)radioResta.IsChecked)
                {
                    textSol.Text = restar(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));
                }
                else if ((bool)radioMulti.IsChecked)
                {
                    textSol.Text = multiplicar(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));
                }
                else if ((bool)radioDividir.IsChecked)
                {
                    textSol.Text = dividir(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));
                }
            }
            catch (Exception)
            {
                textSol.Text = "Debes introducir un número válido";
            }
        }

        private string multiplicar(int n1, int n2)
        {
            int mul = n1 * n2;
            return Convert.ToString(mul);
        }

        private string restar(int n1, int n2)
        {
            int res = n1 - n2;
            return Convert.ToString(res);
        }

        private string sumar(int n1, int n2)
        {
            int suma = n1 + n2;
            return Convert.ToString(suma);
        }

        private string dividir(int n1, int n2)
        {
            if (n2 != 0)
            {
                int division = n1 / n2;
                return Convert.ToString(division);
            }
            else
            {
                return "No puedes dividir por 0";
            }
        }

        private void limpiar_click(object sender, RoutedEventArgs e)
        {
            n1.Text = "";
            n2.Text = "";
            textSol.Text = "";
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void n1_TextChanged(object sender, TextChangedEventArgs e)
        {
            habilitarCalcular();
        }

        private void n2_TextChanged(object sender, TextChangedEventArgs e)
        {
            habilitarCalcular();
        }

        private void estaPulsadoAlgunBoton_Checked(object sender, RoutedEventArgs e)
        {
            habilitarCalcular();
        }

        private void habilitarCalcular()
        {
            if (((bool)radioSuma.IsChecked || (bool)radioResta.IsChecked || (bool)radioMulti.IsChecked || (bool)radioDividir.IsChecked) && n1.Text != "" && n2.Text != "")
            {
                calcular.IsEnabled = true;
            }
            else
            {
                calcular.IsEnabled = false;
            }
        }
    }
}
