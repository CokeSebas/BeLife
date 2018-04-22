using LibbClas;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para addCliente.xaml
    /// </summary>
    public partial class addCliente : Window
    {
        public Conexion conec = new Conexion();
        public Cliente objCli = new Cliente();
        public Sexo objSex = new Sexo();
        public EstadoCivil objEC = new EstadoCivil();

        public addCliente()
        {
            InitializeComponent();
            limpiar();
            LlenarCombo();

        }

        private void btnLimpiarCli_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void btnGuardarCli_Click(object sender, RoutedEventArgs e){
            try{
                bool guarda = false;
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

                guarda = objCli.guardarCliente();
                if (guarda == true)
                {
                    MessageBox.Show("Cliente guardado");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Rut ya esta ingresado en la Base de Datos");
                    txtRutCli.Clear();
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
            
        }

        public void limpiar()
        {
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
    }
}
