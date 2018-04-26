using LibbClas;
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
using System.Windows.Shapes;

namespace Inicio
{
    /// <summary>
    /// Lógica de interacción para editarCliente.xaml
    /// </summary>
    public partial class editarCliente : Window
    {

        public Conexion conec = new Conexion();
        public Cliente objCli = new Cliente();
        public Sexo objSex = new Sexo();
        public EstadoCivil objEC = new EstadoCivil();
        private List<Cliente> clientes= new List<Cliente>();

        public editarCliente()
        {
            InitializeComponent();
            limpiar();
            LlenarCombo();
        }

        public editarCliente(string nombre, string apellido, string rut, string sexo, string estado, string fecha)
        {
            InitializeComponent();
            LlenarCombo();
            txtNombCli.Text = nombre;
            txtRutCli.Text = rut;
            txtApCli.Text = apellido;

            if (sexo == "Masculino"){
                cbbSexo.SelectedIndex = 1;
            }else if (sexo == "Femenino"){
                cbbSexo.SelectedIndex = 2;
            }

            if (estado == "Soltero"){
                cbbEC.SelectedIndex = 1;
            }else if (estado == "Casado"){
                cbbEC.SelectedIndex = 2;
            }else if (estado == "Divorciado"){
                cbbEC.SelectedIndex = 3;
            }else if (estado == "Viudo"){
                cbbEC.SelectedIndex = 4;
            }

            dtpFechaNacCli.DisplayDate = Convert.ToDateTime(fecha);
            dtpFechaNacCli.SelectedDate = Convert.ToDateTime(fecha);
            //limpiar();
            activarOpciones();
            
        }

        public void limpiar(){
            txtApCli.Clear();
            txtNombCli.Clear();
            txtRutCli.Clear();
            dtpFechaNacCli.DisplayDate = DateTime.Today;
            cbbSexo.SelectedIndex = 0;
            cbbEC.SelectedIndex = 0;
        }

        public void LlenarCombo(){

            string[] listSex = objSex.listSexo();

            cbbSexo.SelectedIndex = 0;
            cbbSexo.Items.Add("Seleccione");
            for (int i = 0; i < listSex.Length; i++){
                cbbSexo.Items.Add(listSex[i]);
            }

            string[] listEC = objEC.listEstadoCivil();

            cbbEC.SelectedIndex = 0;
            cbbEC.Items.Add("Seleccione");
            for (int x = 0; x < listEC.Length; x++){
                cbbEC.Items.Add(listEC[x]);
            }

        }

        private void btnLimpiarCli_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void btnEditarCli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool edita = false;
                string nombre = txtNombCli.Text;
                string apellido = txtApCli.Text;
                string rut = txtRutCli.Text;
                DateTime fechaC = dtpFechaNacCli.SelectedDate.Value;
                string fecNac = fechaC.Year.ToString() + "-" + fechaC.Month.ToString() + "-" + fechaC.Day.ToString();
                string sexo = cbbSexo.SelectedIndex.ToString();
                string estadoCi = cbbEC.SelectedIndex.ToString();
                objCli.Rut = rut;
                objCli.Nombre = nombre;
                objCli.Apellido = apellido;
                objCli.FechaNacimiento = fecNac;
                objCli.EstadoCivil = estadoCi;
                objCli.Sexo = sexo;

                edita = objCli.editarCliente(rut);
                if (edita == true)
                {
                    MessageBox.Show("Cliente Editado", "Confirmacion!", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiar();
                    desactivarOpciones();
                }
                else
                {
                    MessageBox.Show("El RUT " + rut + " no ha sido ingresado", "Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnBuscarCli_Click(object sender, RoutedEventArgs e) {
            string rut = txtRutCli.Text;
            string[] datos;
            bool valida = objCli.validar("Cliente", rut);
            if (valida == false){
                datos = conec.getDatosCliente(rut);
                txtNombCli.Text = datos[0];
                txtApCli.Text = datos[1];
                dtpFechaNacCli.DisplayDate = Convert.ToDateTime(datos[2]);
                dtpFechaNacCli.SelectedDate = Convert.ToDateTime(datos[2]);
                cbbSexo.SelectedIndex = int.Parse(datos[3]);
                cbbEC.SelectedIndex = int.Parse(datos[4]);
                activarOpciones();
            }
            else{
                MessageBox.Show("El RUT " + rut + " no ha sido ingresado", "Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
       
        }

        private void btnEliminarCli_Click(object sender, RoutedEventArgs e)
        {
            bool elimina = false;
            string rut = txtRutCli.Text; 
            objCli.Rut = rut;

            if (objCli.clienteContrato(rut) == true){
                elimina = objCli.eliminarCliente(rut);
                MessageBox.Show("Cliente Eliminado", "Confirmacion!", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiar();
                desactivarOpciones();
            }else{
                MessageBox.Show("El cliente tiene un contrato en vigencia, no se puede eliminar", "Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        public void activarOpciones(){
            txtRutCli.IsEnabled = false;
            btnEditarCli.IsEnabled = true;
            btnEliminarCli.IsEnabled = true;
            cbbEC.IsEnabled = true;
            cbbSexo.IsEnabled = true;
            dtpFechaNacCli.IsEnabled = true;
            txtNombCli.IsEnabled = true;
            txtApCli.IsEnabled = true;
        }

        public void desactivarOpciones(){
            btnEditarCli.IsEnabled = false;
            btnEliminarCli.IsEnabled = false;
            cbbEC.IsEnabled = false;
            cbbSexo.IsEnabled = false;
            dtpFechaNacCli.IsEnabled = false;
            txtNombCli.IsEnabled = false;
            txtApCli.IsEnabled = false;
            txtRutCli.IsEnabled = true;
        }

        private void btnListarCli_Click(object sender, RoutedEventArgs e){
            
            ListarCliente listCli = new ListarCliente();

            //listCli.Owner = this;
            this.Hide();
            listCli.ShowDialog();
            this.Close();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
