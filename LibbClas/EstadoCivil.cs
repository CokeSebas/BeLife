using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibbClas
{
    public class EstadoCivil
    {
        Conexion conec = new Conexion();

        //llena un arreglo con la infomración de la tabla que se le ingresa por parametros
        public string[] listEstadoCivil(){
            string[] listEC = conec.listSelec("EstadoCivil");

            return listEC;

        }
    }
}
