using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;
using Oracle.ManagedDataAccess;
namespace Negocio
{
    public class Conexion
    {

        private static DALC.Entities _entidades;

        public static Entities Entidades
        {
            get
            {
                if (_entidades == null)
                {

                    _entidades = new DALC.Entities();
                }
                return _entidades;
            }


        }
        public Conexion()
        {

        }



    }
}
