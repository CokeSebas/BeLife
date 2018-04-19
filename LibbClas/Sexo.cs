using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibbClas
{
    public class Sexo
    {

        Conexion conec = new Conexion();
    
        //llena un arreglo con la infomración de la tabla que se le ingresa por parametros
        public string[] listSexo(){

            string[] listSex = conec.listSelec("sexo");

            return listSex;

        }
    }
}
