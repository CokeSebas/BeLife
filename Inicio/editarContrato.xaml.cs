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
    /// Lógica de interacción para editarContrato.xaml
    /// </summary>
    public partial class editarContrato : Window
    {

        public Conexion conec = new Conexion();
        public Contrato objCont = new Contrato();

        public editarContrato()
        {
            InitializeComponent();
            listCombo();
        }

        public void listCombo(){


            /*string[] listaContrato = conec.getListCont();
            cbbListaContrato.SelectedIndex = 0;
            cbbListaContrato.Items.Add("Seleccione");
            for (int i = 0; i < listaContrato.Length; i++)
            {
                cbbListaContrato.Items.Add(listaContrato[i]);
            }*/

            string[] listRutC = conec.listRutContrato();
            cbbRutCli.SelectedIndex = 0;
            cbbRutCli.Items.Add("Seleccione");
            for (int z = 0; z < listRutC.Length; z++){
                cbbRutCli.Items.Add(listRutC[z]);
            }

            string[] listPlan = conec.listPlan();
            cbbPlan.SelectedIndex = 0;
            cbbPlan.Items.Add("Seleccione");
            for (int x = 0; x < listPlan.Length; x++)
            {
                cbbPlan.Items.Add(listPlan[x]);
            }

            cbbSalud.SelectedIndex = 0;
            cbbSalud.Items.Add("Seleccione");
            cbbSalud.Items.Add("No");
            cbbSalud.Items.Add("Si");
        }

        private void btnGuardarCont_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarCont_Click(object sender, RoutedEventArgs e)
        {
            string rut = cbbRutCli.SelectedItem.ToString();
            string numero = cbbListaContrato.SelectedItem.ToString();
            string[] datos;
           
            datos = conec.getDatosContrato(numero, rut);
            if (datos[0]== "VID01"){
                cbbPlan.SelectedIndex = 1;
            }else if (datos[0] == "VID02"){
                cbbPlan.SelectedIndex = 2;
            }else if (datos[0] == "VID03"){
                cbbPlan.SelectedIndex = 3;
            }else if (datos[0] == "VID04"){
                cbbPlan.SelectedIndex = 4;
            }else if (datos[0] == "VID05"){
                cbbPlan.SelectedIndex = 5;
            }

            dtpFechaInicio.DisplayDate = Convert.ToDateTime(datos[1]);
            if (datos[4] == "true"){
                cbbSalud.SelectedIndex = 1;
            }else{
                cbbSalud.SelectedIndex = 2;
            }
            
            txtPrimaAnu.Text = datos[5];
            txtPrimaMen.Text = datos[6];
        }

        private void cbbRutCli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbListaContrato.Items.Clear();
            string[] listCont = conec.listContratos(cbbRutCli.SelectedValue.ToString());
            cbbListaContrato.SelectedIndex = 0;
            //cbbRutCli.Items.Add("Seleccione");
            for (int i = 0; i < listCont.Length; i++)
            {
                cbbListaContrato.Items.Add(listCont[i]);
            }
        }

        private void cbbListaContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            limpiar();
        }

        public void limpiar(){
            txtPrimaMen.Text = "";
            txtPrimaAnu.Text = "";
            cbbPlan.SelectedIndex = 0;
            cbbSalud.SelectedIndex = 0;
        }

        private void btnListarCon_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos listCont = new ListadoContratos();
            listCont.Owner = this;
            listCont.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }
    }
}
