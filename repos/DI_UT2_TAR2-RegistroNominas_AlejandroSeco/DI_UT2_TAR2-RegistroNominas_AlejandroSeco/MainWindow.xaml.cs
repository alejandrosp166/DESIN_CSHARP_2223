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
        // Creamos el atributo puesto
        Puesto puesto;
        // Creamos el atributo años de experiencia
        int aniosExperiencia;
        // Creamos la lista que guardará a los trabajadores
        List<Trabajador> listaTrabajadores;

        public MainWindow()
        {
            InitializeComponent();
            // Introducimos los datos dentro del combobox
            llenarCmbHijos();
            // Instanciamos la lista
            listaTrabajadores = new List<Trabajador>();
        }
        // Calcula la nómina del trabajador
        private void calcularNomina_Click(object sender, RoutedEventArgs e)
        {
            // Obtenemos el los datos del trabajador en forma de objeto Trabajador con los datos que 
            // hay ahora escritos en el formulario
            Trabajador t = obtenerTrabajadorForm();
            if (t != null)
            {
                // Si lo que devuelve no es null se muestra la nómina
                MessageBox.Show("El sueldo del trabajador es -> " + t.sueldo + "\n");
            }
        }
        // Introduce el trabajador dentro la lista
        private void registrarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            // Obtenemos el los datos del trabajador en forma de objeto Trabajador con los datos que 
            // hay ahora escritos en el formulario
            Trabajador t = obtenerTrabajadorForm();
            if (t != null)
            {
                // Limpiamos el formulario
                limpiarFormulario();
                // Obtenemos el trabajador que está repetido
                Trabajador repetido = trabajadorRepetido(t);
              
                if (!t.Equals(repetido))
                {
                    // Si no está repetido añadimos el trabajador a la lista
                    MessageBox.Show("Trabajador añadido con éxito");
                    listaTrabajadores.Add(t);
                }
                else
                {
                    // Si está repetido preguntamos si quiere cargar los datos del trabajador con el mismo DNI en la lista
                    if(MessageBox.Show("El trabajador está repetido\n¿Quieres cargarlo en el formulario?", "Atención", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        // Cargamos los datos del trabajador
                        cargarTrabajadorForm(repetido);
                    }
                }
            }
        }
        // Abrir ventana nueva con la lista de los trabajadores ordenadas de mayor a menor
        private void listarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            if(listaTrabajadores.Count > 0)
            {
                // Si la lista tiene algún dato creamos la nueva ventana y la mostramos
                ListarTrabajadores ventanaNueva = new ListarTrabajadores(listaTrabajadores);
                ventanaNueva.Show();
            } else
            {
                // Si no hay datos en la lista mostramos un mensaje de aviso
                MessageBox.Show("No hay trabajadores que mostar");
            }
        }
        // Limpiar el formulario
        private void limpiarForm_Click(object sender, RoutedEventArgs e)
        {
            limpiarFormulario();
        }
        // Salir de la apliación
        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
        // Carga los datos del trabajador en el form
        private void cargarTrabajadorForm(Trabajador t)
        {
            // Marcamos el radio button de puesto dependiendo de los datos de t
            switch (t.puesto)
            {
                case Puesto.ADMINISTRATIVO:
                    radioAdministrativo.IsChecked = true;
                    break;
                case Puesto.TECNICO:
                    radioTecnico.IsChecked = true;
                    break;
                case Puesto.PROFESIONAL:
                    radioProfesional.IsChecked = true;
                    break;
            }
            // Marcamos la casilla dependiendo de los datos de t
            if(t.afiliacionSindical)
            {
                checkAfiliado.IsChecked = true;
            }
            // Marcamos el radio button de años de experiencia dependiendo de los datos de t
            switch (aniosExperiencia)
            {
                case 1:
                    radioEntre5y10.IsChecked = true;
                    break;
                case 2:
                    radioMas10.IsChecked = true;
                    break;
            }
            // Cargamos los datos del trabajador en el textbox y el comboBox
            txtNombre.Text = t.nombre;
            txtApellido1.Text = t.apellido1;
            txtApellido2.Text = t.apellido2;
            txtDni.Text = t.dni;
            txtEdad.Text = t.edad.ToString();
            cmbHijos.SelectedItem = t.numeroHijos;
        }
        // Este método devuelve un objeto trabajador teniendo en cuenta los datos que hay en ese momento escritos en el form
        // Tambíen se aprovecha para calcular su sueldo
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
            }

            int numHijos = Convert.ToInt32(cmbHijos.SelectedItem);

            sueldo += numHijos * 100;

            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string edad = txtEdad.Text;
            string dni = txtDni.Text;


            if (validarFormulario(nombre, apellido1, apellido2, edad, dni))
            {
                // Si los datos son válidos devolvemos el trabajador
                return new Trabajador(nombre, apellido1, apellido2, Convert.ToInt32(edad), numHijos, dni, afiliacionSindical, aniosExperiencia, puesto, sueldo);
            }
            return null;
        }
        // Este método valida los datos que el usuario introduce en el formulario
        private bool validarFormulario(string nombre, string apellido1, string apellido2, string edad, string dni)
        {
            if (!(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido1) || string.IsNullOrEmpty(apellido2) || string.IsNullOrEmpty(edad) || string.IsNullOrEmpty(dni)))
            {
                if (int.TryParse(edad, out int n))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("El campo edad debe ser un número entero");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben tener información válida");
                return false;
            }
        }
        // Este método devuelve el trabajador que está repetido
        private Trabajador trabajadorRepetido(Trabajador trabajadorComprobar)
        {
            foreach (Trabajador t in listaTrabajadores)
            {
                if (t.Equals(trabajadorComprobar))
                {
                    return t;
                }
            }
            return null;
        }
        // Este método se encarga de limpiar el formulario
        private void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtDni.Text = "";
            txtEdad.Text = "";
            cmbHijos.SelectedItem = 0;
            checkAfiliado.IsChecked = false;
            radioMenos5.IsChecked = true;
            radioObrero.IsChecked = true;
        }
        // Este método llena el comboBox de número de hijos con números del 1 al 20
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
    }
}
