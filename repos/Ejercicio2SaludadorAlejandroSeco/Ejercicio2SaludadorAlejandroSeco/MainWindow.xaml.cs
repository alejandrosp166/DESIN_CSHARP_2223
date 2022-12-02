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
using System.Collections;

namespace Ejercicio2SaludadorAlejandroSeco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] contSaludos = new int[5];
        string[] nombres = new string[5];
        int indiceSaludoActual;
        int numeroAlmacenados = 0;

        public MainWindow()
        {
            InitializeComponent();
            instanciarArray();
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNombre.Text == "")
            {
                label1.Content = "El cuadro de texto está vacío";
            }
        }

        private void saludar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            if(nombre != "")
            {
                int numSaludos = yaSaludado(nombre);
                if (numSaludos > 0)
                {
                    MessageBox.Show("Hola " + nombre + " Te he saludado " + (numSaludos + 1) + " veces");
                    contSaludos[indiceSaludoActual]++;
                }
                else
                {

                    if (numeroAlmacenados < 5)
                    {
                        MessageBox.Show("Hola " + nombre + " esta es la primera vez que te saludo");
                        nombres[numeroAlmacenados] = nombre;
                        contSaludos[numeroAlmacenados] = 1;
                        numeroAlmacenados++;
                    }
                    else
                    {
                        MessageBox.Show("Lo siento ya no puedo saludar a nadie más reinicia el programa");
                    }
                }
            } else
            {
                MessageBox.Show("Introduce algo en el cuadro de texto");
            }
        }

        private int yaSaludado(string nombre)
        {
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    indiceSaludoActual = i;
                    return contSaludos[i];
                }
            }
            return 0;
        }

        private void listarSaludos_Click(object sender, RoutedEventArgs e)
        {
            string cadena = "";
            for (int i = 0; i < nombres.Length; i++)
            {
                if(nombres[i] != "")
                {
                    cadena += nombres[i] + "->" + contSaludos[i] + "\n";
                }
            }
            MessageBox.Show(cadena);
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            instanciarArray();
            contSaludos = new int[5];
            numeroAlmacenados = 0;
        }

        private void instanciarArray()
        {
            for (int i = 0; i < nombres.Length; i++)
            {
                nombres[i] = "";
            }
        }
    }
}
