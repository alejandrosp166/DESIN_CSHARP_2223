using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace DI_UT2_TAR4_FichaRegistroUsuario
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string password { get; set; }
        public DateTime fechaNacimiento { get; set; }
        // Esta propiedad guarda la imagen de avatar del usuario, la inicializamos por defecto a la imagen de avatar predeterminada
        public BitmapImage avatarUsuario { get; set; } = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp3.1\\", "\\res\\avatar.png")));
        public Usuario(string nombre, string password, DateTime fechaNacimiento, BitmapImage avatarUsuario)
        {
            this.nombre = nombre;
            this.password = password;
            this.fechaNacimiento = fechaNacimiento;
            // Si el avatar de usuario no es null
            if(avatarUsuario != null)
            {
                // Guardamos la foto elegida por el usuario, si no se queda la imagen por defecto
                this.avatarUsuario = avatarUsuario;
            }
        }
    }
}
