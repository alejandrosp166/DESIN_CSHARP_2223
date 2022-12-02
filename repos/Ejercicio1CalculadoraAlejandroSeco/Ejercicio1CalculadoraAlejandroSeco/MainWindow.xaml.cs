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
                switch (0)
                {
                    case 0:
                        labelRes.Content = sumar(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));
                        break;
                    case 1:
                        labelRes.Content = restar(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));

                        break;
                    case 2:
                        labelRes.Content = multiplicar(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));

                        break;
                    case 3:
                        labelRes.Content = dividir(Convert.ToInt32(n1.Text), Convert.ToInt32(n2.Text));
                        break;
                }
            }
            catch
            {

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
    }
}
