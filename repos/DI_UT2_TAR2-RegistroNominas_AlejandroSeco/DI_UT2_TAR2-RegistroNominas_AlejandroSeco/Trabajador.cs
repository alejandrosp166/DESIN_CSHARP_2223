using System;
using System.Collections.Generic;
using System.Text;

namespace DI_UT2_TAR2_RegistroNominas_AlejandroSeco
{
    public class Trabajador
    {
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int edad { get; set; }
        public int numeroHijos { get; set; }
        public string dni { get; set; }
        public bool afiliacionSindical { get; set; }
        public int aniosExperiencia { get; set; }
        public Puesto puesto { get; set; }
        public double sueldo { get; set; }

        public Trabajador(string nombre, string apellido1, string apellido2, int edad, int numeroHijos, string dni, bool afiliacionSindical, int aniosExperiencia, Puesto puesto, double sueldo)
        {
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.edad = edad;
            this.numeroHijos = numeroHijos;
            this.dni = dni;
            this.afiliacionSindical = afiliacionSindical;
            this.aniosExperiencia = aniosExperiencia;
            this.puesto = puesto;
            this.sueldo = sueldo;
        }

        public bool Equals(Trabajador t)
        {
            // Comprueba si dos trabajadores son iguales (comparando el dni)
            if(t != null)
            {
                if (dni.Equals(t.dni))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            // Formatea la salida del trabajador
            return "Nombre -> " + nombre + " sueldo -> " + sueldo.ToString();
        }
    }

    public enum Puesto
    {
        OBRERO,
        ADMINISTRATIVO,
        TECNICO,
        PROFESIONAL
    }
}
