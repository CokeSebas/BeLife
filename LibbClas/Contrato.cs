using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibbClas
{
    public class Contrato{

        Conexion objConec = new Conexion();

        private string _numeroContrato;
        private string _fechaCreacion;
        private string _rutCliente;
        private string _codigoPlan;
        private string _fechaInicioVigencia;
        private string _fechaFinVigencia;
        private string _vigente;
        private string _declaracionSalud;
        private string _primaAnual;
        private string _primaMensual;
        private string _observaciones;

        public string NumeroContrato
        {
            get
            {
                return _numeroContrato;
            }

            set
            {
                _numeroContrato = value;
            }
        }

        public string FechaCreacion
        {
            get{
                return _fechaCreacion;
            }

            set{
                _fechaCreacion = value;
            }
        }

        public string RutCliente
        {
            get
            {
                return _rutCliente;
            }

            set
            {
                if (value.Length == 10)
                {
                    _rutCliente = value;
                }
                else
                {
                    throw new Exception("Largo rut 10");
                }
            }
        }

        public string CodigoPlan
        {
            get
            {
                return _codigoPlan;
            }

            set
            {
                if (value != "Seleccione")
                {
                    _codigoPlan = value;
                }
                else
                {
                    throw new Exception("Debe seleccionar un Plan");
                }
            }
        }

        public string FechaInicioVigencia
        {
            get
            {
                return _fechaInicioVigencia;
            }

            set
            {
                if (value != ""){
                    DateTime fecha_iniv = Convert.ToDateTime(value);
                    int result = DateTime.Compare(fecha_iniv, DateTime.Today);
                    int mes = fecha_iniv.Month -DateTime.Today.Month;
                    //if (result >= 0){
                        if (mes < 1){
                            _fechaInicioVigencia = value;
                        }else{
                            throw new Exception("Mes de inicio de vigencia no puede ser superior a un mes");
                        }
                    /*}else{
                        throw new Exception("Inicio Vigencia no puede ser menor a la Fecha Actual");
                    }*/
                }else{
                    throw new Exception("Fecha de nacimiento no puede ser vacia");
                }
                //_fechaInicioVigencia = value;
            }
        }

        public string FechaFinVigencia
        {
            get
            {
                return _fechaFinVigencia;
            }

            set
            {
                _fechaFinVigencia = value;
            }
        }

        public string Vigente
        {
            get
            {
                return _vigente;
            }

            set
            {
                _vigente = value;
            }
        }

        public string DeclaracionSalud
        {
            get
            {
                return _declaracionSalud;
            }

            set
            {
                if (value != "")
                {
                    _declaracionSalud = value;
                }
                else
                {
                    throw new Exception("Debe seleccionar si Declara Salud");
                }
            }
        }

        public string PrimaAnual
        {
            get
            {
                return _primaAnual;
            }

            set
            {
                _primaAnual = value;
            }
        }

        public string PrimaMensual
        {
            get
            {
                return _primaMensual;
            }

            set
            {
                _primaMensual = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return _observaciones;
            }

            set
            {
                _observaciones = value;
            }
        }

        public bool agregarContrato(){

            string sql = "INSERT INTO Contrato VALUES ('"+NumeroContrato+ "', GETDATE(), '" + RutCliente+ "',(SELECT idPlan FROM [Plan] WHERE Nombre = '" + CodigoPlan + "'), convert(date, '" + FechaInicioVigencia+ "'), convert(date, '" + FechaFinVigencia + "'), " + Vigente+", "+DeclaracionSalud+","+PrimaAnual.Replace(",",".")+","+PrimaMensual.Replace(",", ".") + ",'"+Observaciones+"');";

            bool guarda = objConec.insertar(sql);

            if (guarda == true){
                //return true;
                return guarda;
            }else{
                return guarda;
            }
        }

        public bool editarContrato(){
            string campos =  "CodigoPlan = (SELECT idPlan FROM [Plan] WHERE Nombre = '"+CodigoPlan+"'),  DeclaracionSalud = "+DeclaracionSalud+", PrimaAnual = "+PrimaAnual.Replace(",", ".") + ", PrimaMensual = "+PrimaMensual.Replace(",", ".") + ", Observaciones = '"+Observaciones+"' ";
            string condicion = " Numero = '" + NumeroContrato + "';";
            bool edita = objConec.actualizar("Contrato", campos, condicion);
            if (edita == true){
                return edita;
            }else{
                return edita;
            }
        }

        public bool terminarContrato()
        {
            string campos = "Vigente = "+Vigente+", FechaFinVigencia = GETDATE()";
            string condicion = " Numero = '" + NumeroContrato + "';";
            bool edita = objConec.actualizar("Contrato", campos, condicion);
            if (edita == true)
            {
                return edita;
            }
            else
            {
                return edita;
            }
        }
    }
}
