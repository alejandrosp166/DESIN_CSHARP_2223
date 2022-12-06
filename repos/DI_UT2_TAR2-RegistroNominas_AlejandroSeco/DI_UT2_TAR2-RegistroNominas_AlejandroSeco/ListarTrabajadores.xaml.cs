using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DI_UT2_TAR2_RegistroNominas_AlejandroSeco
{
    public partial class ListarTrabajadores : Window
    {
        public ListarTrabajadores(List<Trabajador> l)
        {
            InitializeComponent();
            // Cargamos la lista en el textbox
            cargarTrabajadoresLista(l);
        }

        private void cargarTrabajadoresLista(List<Trabajador> listaTrabajadores)
        {
            // Ordenamos la lista de mayor a menor por el sueldo
            listaTrabajadores = listaTrabajadores.OrderByDescending(x => x.sueldo).ToList();
            // Los vamos añadiendo a la lista
            foreach(Trabajador t in listaTrabajadores)
            {
                txtLista.Text += t.ToString() + "\n";
            }
        }
    }
}
