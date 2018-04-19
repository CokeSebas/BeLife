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
        private int _primaAnual;
        private int _primaMensual;
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
            get
            {
                return _fechaCreacion;
            }

            set
            {
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
                _rutCliente = value;
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
                _codigoPlan = value;
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
                _fechaInicioVigencia = value;
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
                _declaracionSalud = value;
            }
        }

        public int PrimaAnual
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

        public int PrimaMensual
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

            string sql = "INSERT INTO Contrato VALUES ('"+NumeroContrato+ "', GETDATE(), '" + RutCliente+ "',(SELECT idPlan FROM [Plan] WHERE Nombre = '" + CodigoPlan + "'), convert(date, '" + FechaInicioVigencia+"'), '', "+Vigente+", "+DeclaracionSalud+","+PrimaAnual+","+PrimaMensual+",'"+Observaciones+"');";

            bool guarda = objConec.insertar(sql);

            if (guarda == true){
                //return true;
                return guarda;
            }else{
                return guarda;
            }
        }

        public bool editarContrato(){
            //if (validar("Cliente", rutB) == true){
                string campos =  "CodigoPlan = (SELECT idPlan FROM [Plan] WHERE Nombre = '"+CodigoPlan+"'), FechaInicioVigencia = convert(DATE, '"+FechaFinVigencia+"'), FechaFinVigencia = CONVERT(date, '"+FechaFinVigencia+"'),Vigente = , DeclaracionSalud = "+DeclaracionSalud+", PrimaAnual = "+PrimaAnual+", PrimaMensual = "+PrimaMensual;
                string condicion = " Numero = '" + NumeroContrato + "';";
                bool edita = objConec.actualizar("Contrato", campos, condicion);
                if (edita == true){
                    return edita;
                }else{
                    return edita;
                }
            /*}else{
                return false;
            }*/
        }
    }
}
