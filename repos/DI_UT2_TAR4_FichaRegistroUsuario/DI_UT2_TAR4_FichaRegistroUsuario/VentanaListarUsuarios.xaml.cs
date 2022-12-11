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

namespace DI_UT2_TAR4_FichaRegistroUsuario
{
    // ALEJANDRO SECO PINEDA 2ºDAM
    public partial class VentanaListarUsuarios : Window
    {
        public VentanaListarUsuarios(List<Usuario> l)
        {
            InitializeComponent();
            cargarUsuariosLista(l);
        }

        private void cargarUsuariosLista(List<Usuario> listaUsuarios)
        {
            // Ordenamos la lista de mayor a menor
            listaUsuarios = listaUsuarios.OrderBy(x => x.fechaNacimiento).ToList();
            // Linkeamos la lista con la lista que contiene a los usuarios
            listBoxUsers.ItemsSource = listaUsuarios;
        }
    }
}
