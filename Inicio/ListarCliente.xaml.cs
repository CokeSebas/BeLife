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

        public ListarCliente()
        {
            InitializeComponent();
            LlenarCombo();

            dataGridUsuarios.ItemsSource = conec.ListarClientes();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = conec.consultar2("contrato");
            /*dtLisCli.Columns.Add("Nomnre");
            dtLisCli.Columns.Add("nombre", "Nombre");
            dtLisCli.Columns.Add("apellido", "Apellido");
            dtLisCli.Columns.Add("direccion", "Direccion");
            dtLisCli.Columns.Add("email", "Email");
            dtLisCli.Columns.Add("telefono", "Telefono");
            */
            //dtLisCli.ItemsSource =;
            DataTable dt = new DataTable();
            dt = conec.consultar2("contrato");
            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                //dtLisCli.Columns.Add(dr["numero"]);

                /*dtLisCli.Columns.Add("nombre", "Nombre");
                dtLisCli.Columns.Add("apellido", "Apellido");
                dtLisCli.Columns.Add("direccion", "Direccion");
                dtLisCli.Columns.Add("email", "Email");
                dtLisCli.Columns.Add("telefono", "Telefono");*/
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
