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
    /// Lógica de interacción para addContrato.xaml
    /// </summary>
    public partial class addContrato : Window
    {
        public Conexion conec = new Conexion();
        public Contrato objCont = new Contrato();

        public addContrato()
        {
            InitializeComponent();
            listCombo();
        }

        public void listCombo(){
            string[] listRut = conec.listRut();

            string[] listPlan = conec.listPlan();
            cbbPlan.SelectedIndex = 0;
            cbbPlan.Items.Add("Seleccione");
            for (int x = 0; x < listPlan.Length; x++){
                cbbPlan.Items.Add(listPlan[x]);
            }

            cbbSalud.SelectedIndex = 0;
            cbbSalud.Items.Add("Seleccione");
            cbbSalud.Items.Add("No");
            cbbSalud.Items.Add("Si");
        }

        private void txtNroCont_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        public void limpiar()
        {
            txtPrimaMen.Clear();
            txtPrimaAnu.Clear();
            cbbSalud.SelectedIndex = 0;
            dtpFechaInicio.DisplayDate = DateTime.Today;
            cbbPlan.SelectedIndex = 0;
            txtObsv.Clear();
        }

        private void btnGuardarCont_Click(object sender, RoutedEventArgs e)
        {
            bool guarda = false;
            string rutCliente = txtRutCont.Text;

            DateTime localDate = DateTime.Now;
            string mes = "", dia = "", minu = "", seg = "";
            string anio = localDate.Year.ToString();
            mes = localDate.Month.ToString();
            dia = localDate.Day.ToString();
            string hora = localDate.Hour.ToString();
            minu = localDate.Minute.ToString();
            seg = localDate.Second.ToString();

            if (mes.Length == 1){
                mes = "0" + mes;
            }
            if (dia.Length == 1){
                dia = "0" + dia;
            }
            if (minu.Length == 1){
                minu = "0" + minu;
            }
            if (seg.Length == 1){
                seg = "0" + seg;
            }
            string numero = anio + mes + dia + hora + minu + seg;
            string plan = cbbPlan.SelectedValue.ToString();
            DateTime fechaIniVig = dtpFechaInicio.SelectedDate.Value;
            string fechaVigencia = fechaIniVig.Year.ToString() + "-" + fechaIniVig.Month.ToString() + "-" + fechaIniVig.Day.ToString();
            string salud = cbbSalud.SelectedValue.ToString();
            
            if (salud == "Si"){
                salud = "1";
            }else{
                salud = "0";
            }
            string primaAnu = txtPrimaAnu.Text;
            string primaMen = txtPrimaMen.Text;
            string observacion = txtObsv.Text;

            objCont.RutCliente = rutCliente;
            objCont.NumeroContrato = numero;
            objCont.CodigoPlan = plan;
            objCont.FechaInicioVigencia = fechaVigencia;
            objCont.DeclaracionSalud = salud;
            objCont.PrimaAnual = int.Parse(primaAnu);
            objCont.PrimaMensual = int.Parse(primaMen);
            objCont.Vigente = "1";
            objCont.Observaciones = observacion;

            guarda = objCont.agregarContrato();
            if (guarda == true)
            {
                MessageBox.Show("Contrato Ingresado");
                limpiar();
            }
            else
            {
                MessageBox.Show("Contrato Ya Ingresado");
            }
        }
    }
}
