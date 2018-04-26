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
    /// Lógica de interacción para ListadoContratos.xaml
    /// </summary>
    public partial class ListadoContratos : Window
    {
        Conexion conec = new Conexion();

        private List<Contrato> contratos = new List<Contrato>();

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

        public ListadoContratos()
        {
            InitializeComponent();
            listCombo();

            contratos = conec.ListarContratos();
            dgtContratos.ItemsSource = contratos;
            Largo = contratos.Count();
        }

        public void listCombo()
        {
            string[] listRut = conec.listRut();

            string[] listPlan = conec.listPlan();

            string[] numeroCon = conec.getListCont();
            cbbContrato.SelectedIndex = 0;
            cbbContrato.Items.Add("Seleccione");
            for (int i = 0; i < numeroCon.Length; i++)
            {
                cbbContrato.Items.Add(numeroCon[i]);
            }

            string[] polizas = conec.getlistPoliza();
            cbbPoliza.SelectedIndex = 0;
            cbbPoliza.Items.Add("Seleccione");
            for (int z = 0; z < polizas.Length; z++)
            {
                cbbPoliza.Items.Add(polizas[z]);
            }

        }

        private void dgtContratos_SelectionChanged(object sender, SelectionChangedEventArgs e){
            int index = (dgtContratos.SelectedIndex) + 1;
            int largoDG = dgtContratos.Items.Count;

            if (index > Largo)
            {
                MessageBox.Show("No se puede mostrar datos de una fila vacia", "Advertencia!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try{
                    Contrato objCont = dgtContratos.SelectedItem as Contrato;
                    string num = objCont.NumeroContrato;
                    string rut = objCont.RutCliente;
                    string plan = objCont.CodigoPlan;
                    string salud = objCont.DeclaracionSalud;
                    string primaAn = objCont.PrimaAnual;
                    string primaMe = objCont.PrimaMensual;
                    string obs = objCont.Observaciones;
                    string fecIni = objCont.FechaInicioVigencia;

                    editarContrato edCont = new editarContrato(num, rut, plan, salud, primaAn, primaMe, obs);
                    this.Hide();
                    edCont.Owner = this;
                    edCont.Show();
                }catch (Exception error){
                    MessageBox.Show(error.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;
            string filtro = "RutCliente = '" + rut + "';";
            dgtContratos.ItemsSource = null;

            contratos = conec.filtroContratos(filtro);

            dgtContratos.ItemsSource = contratos;
            Largo = contratos.Count();
        }

        private void cbbContrato_SelectionChanged(object sender, SelectionChangedEventArgs e){
            dgtContratos.ItemsSource = null;
            string numeroC = cbbContrato.SelectedItem.ToString();
            string filtro = " Numero = '" + numeroC + "';";

            contratos = conec.filtroContratos(filtro);
            dgtContratos.ItemsSource = contratos;
            Largo = contratos.Count();
        }

        private void cbbPoliza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgtContratos.ItemsSource = null;
            string poliza = cbbPoliza.SelectedItem.ToString();
            string filtro = "CodigoPlan = (SELECT idPlan FROM [Plan] WHERE PolizaActual = '" + poliza + "')";

            contratos = conec.filtroContratos(filtro);
            dgtContratos.ItemsSource = contratos;
            Largo = contratos.Count();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /*private void cbbPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgtContratos.ItemsSource = null;
            string plan = cbbPlan.SelectedItem.ToString();
            string filtro = "CodigoPlan = (SELECT idPlan FROM [Plan] WHERE Nombre = '"+plan+"')";

            contratos = conec.filtroContratos(filtro);
            dgtContratos.ItemsSource = contratos;
            Largo = contratos.Count();
        }*/
    }
}
