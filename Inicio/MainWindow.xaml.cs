using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Inicio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            InitializeComponent();
        }

        public void mnSalir(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Salir");
            App.Current.Shutdown();
        }

        public void mnAgregarCliente(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Agregar Cliente");
            //abrir ventana
            addCliente addCli = new addCliente();
            addCli.Owner = this;
            addCli.ShowDialog();
        }

        public void mnEditarCliente(object sender, RoutedEventArgs e)        {
            editarCliente edClie = new editarCliente();
            edClie.Owner = this;
            edClie.ShowDialog();
        }

        public void mnEliminarCliente(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Eliminar Cliente");
        }


        public void mnListCliente(object sender, RoutedEventArgs e)
        {
            ListarCliente listCli = new ListarCliente();
            listCli.Owner = this;
            listCli.ShowDialog();
        }

        public void mnAgregarContrato(object sender, RoutedEventArgs e){
            //MessageBox.Show("Agregar Contrato");

            addContrato addCont = new addContrato();
            addCont.Owner = this;
            addCont.ShowDialog();
        }

        public void mnEditarContrato(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Editar Contrato");
            /*BuscarContrato busCont = new BuscarContrato();
            busCont.Owner = this;
            busCont.ShowDialog();*/
            editarContrato editCont = new editarContrato();
            editCont.Owner = this;
            editCont.ShowDialog();
        }

        public void mnTerminarContrato(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Terminar Contrato");
        }

        public void mnEliminarContrato(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Eliminar Contrato");
        }

        public void mnListarContrato(object sender, RoutedEventArgs e)
        {
            ListadoContratos listCont = new ListadoContratos();
            listCont.Owner = this;
            listCont.ShowDialog();
        }

        /*public void ConectarBD(object sender, RoutedEventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=BeLife;Trusted_Connection=True;");
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
