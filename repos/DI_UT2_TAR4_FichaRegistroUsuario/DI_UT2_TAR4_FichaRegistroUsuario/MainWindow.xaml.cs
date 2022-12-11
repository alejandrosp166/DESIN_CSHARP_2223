using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DI_UT2_TAR4_FichaRegistroUsuario
{
    public partial class MainWindow : Window
    {
        List<Usuario> listaUsuarios;
        public MainWindow()
        {
            InitializeComponent();
            // Instanciamos la lista de usuarios
            listaUsuarios = new List<Usuario>();
        }

        private void btnInsertarUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Obtenemos el usuario escrito en el formulario
            Usuario u = obtenerUsuarioFormulario();
            // Si el método no devuelve null
            if (u != null)
            {
                // Introducimos al usuario dentro del array
                listaUsuarios.Add(u);
                // Avisamos al usuario de que los datos se han insertado con éxito
                MessageBox.Show("El usuario se ha introducido con éxito");
                // Limpiamos el formulario
                limpiarFormulario();
            }
        }

        private void btnBuscarFoto_Click(object sender, RoutedEventArgs e)
        {
            // Cambiamos la imagen del formulario
            imgUsuario.Source = obtenerImagenFormulario();
        }

        private void btnListarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            // Si la lista tiene elementos
            if (listaUsuarios.Count() > 0)
            {
                // Mostramos la nueva venatan
                VentanaListarUsuarios nuevaVentana = new VentanaListarUsuarios(listaUsuarios);
                nuevaVentana.Show();
            }
            else
            {
                // Mostramos un mensaje al usuario
                MessageBox.Show("La lista de usuarios está vacía");
            }
        }

        private void btnSalirApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private Usuario obtenerUsuarioFormulario()
        {
            // Guardamos el valor que hay dentro del usuario
            string user = txtNombre.Text;
            // Guardamos el valor que hay en contraseña
            string pass = txtPassword.Password;
            // Guardamos el valor de la fecha
            DateTime date = dateFechaNacimiento.DisplayDate;
            // Si los datos son válidos
            if (validarDatos(user, pass, date))
            {
                // Devolvemos un objeto usuario
                return new Usuario(user, pass, date, (BitmapImage)imgUsuario.Source);
            }
            else
            {
                // Devolvemos null
                return null;
            }
        }

        private BitmapImage obtenerImagenFormulario()
        {
            lblErrorImagen.Content = "";
            // Creamos el objeto fileDialog
            OpenFileDialog fileDialog = new OpenFileDialog();
            // Lo mostramos por pantalla
            fileDialog.ShowDialog();
            // Almacenamos la ruta el archivo que ha elegido el usuario
            string rutaArchivo = fileDialog.FileName;
            // Si el archivo elegido es una imagen con este formato
            if (rutaArchivo.EndsWith(".jpg") || rutaArchivo.EndsWith(".png") || rutaArchivo.EndsWith(".jpeg"))
            {
                // Creamos un mapa de bits en la imagen
                BitmapImage imgAvatar = new BitmapImage(new Uri(rutaArchivo));
                // Comprobamos si tiene un tamaño válido
                if ((imgAvatar.PixelHeight * imgAvatar.PixelWidth) <= 65536)
                {
                    // Devolvemos la imagen elegida por el usuario
                    return imgAvatar;
                }
                else
                {
                    // AVisamos al usuario de que el tamaño no es el correcto
                    lblErrorImagen.Content = "El archivo debe ser\n256x256 como máximo";
                    return null;
                }
            }
            else
            {
                // Mostramos un mensaje de error en el caso de que el archivo elegido no sea una imagen
                lblErrorImagen.Content = "El archivo elegido debe\nser una imagen\n(.jpg // .png // .jpeg)";
                return null;
            }
        }

        private bool validarDatos(string user, string pass, DateTime date)
        {
            // Limpiamos los mensajes de error
            limpiarMsgError();
            // Declaramos la variable que usaremos para validar el formulario
            bool validado = true;
            // Creamos un objeto regex para expresiones regulares
            Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$");
            // Si el usuario es cadena vacía
            if (string.IsNullOrEmpty(user))
            {
                // Mostramos mensaje de error en el label correspondiente
                lblErrorNombre.Content = "El campo Nombre no\npuede estar vacío";
                validado = false;
            }
            // Si la contraseña está vacía
            if (string.IsNullOrEmpty(pass))
            {
                // Mostramos mensaje de error en el label correspondiente
                lblErrorPass.Content = "El campo Contraseña\nno puede estar vacío";
                validado = false;
            }
            else
            {
                // Se valida la contraseña según los condicionantes
                if (!regex.IsMatch(pass))
                {
                    // Mostramos mensaje de error en el label
                    lblErrorPass.Content = "Mínimo 6 carácteres y máximo 12\ndebe contener una mayúscula\nuna minúscula y un número";
                    validado = false;
                }
            }

            // Se valida si el usuario es mayor de edad
            if (date.AddYears(18) > DateTime.Today)
            {
                // Mostramos mensaje de error en el label fecha
                lblErrorFecha.Content = "El usuario debe\ntener 18 años o más";
                validado = false;
            }
            return validado;
        }

        private void limpiarMsgError()
        {
            // Limpia los mensajes de error
            lblErrorFecha.Content = "";
            lblErrorNombre.Content = "";
            lblErrorPass.Content = "";
        }

        private void limpiarFormulario()
        {
            // Limpia el formulario y los mensajes de error
            txtNombre.Text = "";
            txtPassword.Password = "";
            imgUsuario.Source = null;
            dateFechaNacimiento.SelectedDate = DateTime.Today;
            limpiarMsgError();
        }
    }
}
