using System;
using System.Collections.Generic;
using System.Text;

namespace DI_UT2_TAR4_FichaRegistroUsuario
{
    class Usuario
    {
        public string nombre { get; set; }
        public string password { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Usuario(string nombre, string password, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.password = password;
            this.fechaNacimiento = fechaNacimiento;
        }
    }
}
