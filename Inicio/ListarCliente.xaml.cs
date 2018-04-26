using LibbClas;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Inicio
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class ListarCliente : Window
    {
        public Conexion conec = new Conexion();
        public Cliente objCli = new Cliente();
        public Sexo objSex = new Sexo();
        public EstadoCivil objEC = new EstadoCivil();

        private List<Cliente> clientes = new List<Cliente>();

        private int _largo = 0;

        public int Largo
        {
            get
            {
                return _largo;
            }

            set
            {
                _largo = value;
            }
        }

        public ListarCliente()
        {
            InitializeComponent();
            LlenarCombo();
            
            clientes = conec.ListarClientes();
            dataGridUsuarios.ItemsSource = clientes;
            Largo = clientes.Count();
            //dataGridUsuarios.Items.RemoveAt(dataGridUsuarios.Items.Count - 1);
            //dataGridUsuarios.Items.RemoveAt(0);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridUsuarios.ItemsSource = null;
            string sexo = cbbSexo.SelectedIndex.ToString();
            string filtro = "idSexo = " + sexo;

            clientes = conec.filtroClientes(filtro);
            
            dataGridUsuarios.ItemsSource = clientes;
            Largo = clientes.Count();
        }

        public void LlenarCombo()
        {

            string[] listSex = objSex.listSexo();

            cbbSexo.SelectedIndex = 0;
            cbbSexo.Items.Add("Seleccione");
            for (int i = 0; i < listSex.Length; i++)
            {
                cbbSexo.Items.Add(listSex[i]);
            }

            string[] listEC = objEC.listEstadoCivil();

            cbbEC.SelectedIndex = 0;
            cbbEC.Items.Add("Seleccione");
            for (int x = 0; x < listEC.Length; x++)
            {
                cbbEC.Items.Add(listEC[x]);
            }

        }

        public bool validar(string tabla, string rut)
        {
            string condicion = "RutCliente = '" + rut + "'";
            return conec.validar(tabla, condicion);
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            string rut = txtRut.Text;
            string filtro = "RutCliente = '" + rut+"';";
            dataGridUsuarios.ItemsSource = null;

            clientes = conec.filtroClientes(filtro);

            dataGridUsuarios.ItemsSource = clientes;
            Largo = clientes.Count();
        }


        private void dataGridUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e){
            int index = (dataGridUsuarios.SelectedIndex)+1 ;
            int largoDG = dataGridUsuarios.Items.Count;
            
            if (index >Largo){
                MessageBox.Show("No se puede mostrar datos de una fila vacia", "Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else{
                Cliente objCli = dataGridUsuarios.SelectedItem as Cliente;
                string nom = objCli.Nombre;
                string ap = objCli.Apellido;
                string rut = objCli.Rut;
                string sexo = objCli.Sexo;
                string estC = objCli.EstadoCivil;
                string fecN = objCli.FechaNacimiento;
                editarCliente edCli = new editarCliente(nom, ap, rut, sexo, estC, fecN);
                this.Hide();
                edCli.Owner = this;
                edCli.Show();
            }
        }

        private void cbbEC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGridUsuarios.ItemsSource = null;
            string estadoC = cbbEC.SelectedIndex.ToString();
            string filtro = "idEstadoCivil = " + estadoC;

            clientes = conec.filtroClientes(filtro);
            dataGridUsuarios.ItemsSource = clientes;
            Largo = clientes.Count();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
