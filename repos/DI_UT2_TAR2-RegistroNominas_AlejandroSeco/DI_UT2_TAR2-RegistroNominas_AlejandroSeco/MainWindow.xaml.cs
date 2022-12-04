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

namespace DI_UT2_TAR2_RegistroNominas_AlejandroSeco
{
    public partial class MainWindow : Window
    {
        Puesto puesto;
        int aniosExperiencia;

        public MainWindow()
        {
            InitializeComponent();
            llenarCmbHijos();
        }

        private void calcularNomina_Click(object sender, RoutedEventArgs e)
        {
            Trabajador t = obtenerTrabajadorForm();
            if(t != null)
            {
                MessageBox.Show("El sueldo del trabajador es -> " + t.sueldo + "\n");
            }
        }

        private Trabajador obtenerTrabajadorForm()
        {
            double sueldo = 0;
            switch (puesto)
            {
                case Puesto.OBRERO:
                    sueldo = 800;
                    break;
                case Puesto.ADMINISTRATIVO:
                    sueldo = 900;
                    break;
                case Puesto.TECNICO:
                    sueldo = 1000;
                    break;
                case Puesto.PROFESIONAL:
                    sueldo = 1200;
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;
            }

            bool afiliacionSindical = false;

            if ((bool)checkAfiliado.IsChecked)
            {
                sueldo += 50;
                afiliacionSindical = true;
            }

            switch (aniosExperiencia)
            {
                case 0:
                    break;
                case 1:
                    sueldo += 100;
                    break;
                case 2:
                    sueldo += 200;
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;
            }

            int numHijos = Convert.ToInt32(cmbHijos.SelectedItem);

            sueldo += numHijos * 100;

            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string edad = txtEdad.Text;
            string dni = txtDni.Text;

            if (!(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido1) || string.IsNullOrEmpty(apellido2) || string.IsNullOrEmpty(edad) || string.IsNullOrEmpty(dni)))
            {
                return new Trabajador(nombre, apellido1, apellido2, Convert.ToInt32(edad), numHijos, dni, afiliacionSindical, aniosExperiencia, puesto, sueldo);
            } else
            {
                MessageBox.Show("Por favor rellene los campos");
                return null;
            }
        }

        private void radioObrero_Checked(object sender, RoutedEventArgs e)
        {
            puesto = Puesto.OBRERO;
        }

        private void radioAdministrativo_Checked(object sender, RoutedEventArgs e)
        {
            puesto = Puesto.ADMINISTRATIVO;
        }

        private void radioProfesional_Checked(object sender, RoutedEventArgs e)
        {
            puesto = Puesto.PROFESIONAL;
        }

        private void radioTecnico_Checked(object sender, RoutedEventArgs e)
        {
            puesto = Puesto.TECNICO;
        }

        private void radioMenos5_Checked(object sender, RoutedEventArgs e)
        {
            aniosExperiencia = 0;
        }

        private void radioEntre5y10_Checked(object sender, RoutedEventArgs e)
        {
            aniosExperiencia = 1;
        }

        private void radioMas10_Checked(object sender, RoutedEventArgs e)
        {
            aniosExperiencia = 2;
        }

        private void llenarCmbHijos()
        {
            List<int> numHijos = new List<int>();
            for (int i = 0; i <= 20; i++)
            {
                numHijos.Add(i);
            }
            cmbHijos.ItemsSource = numHijos;
            cmbHijos.SelectedItem = 0;
        }
    }
}
