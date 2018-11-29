using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio
{
    public class Apoderado
    {
        public decimal id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string password { get; set; }
        public decimal rolId { get; set; }



        public Apoderado()
        {

        }

        public Apoderado(decimal id, string username, string email, string ap_paterno, string ap_materno, string nombre, string telefono, string celular, string password, decimal rolId)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.ap_paterno = ap_paterno;
            this.ap_materno = ap_materno;
            this.nombre = nombre;
            this.telefono = telefono;
            this.celular = celular;
            this.password = password;
            this.rolId = rolId;


        }

        //agregar
        public void InsertarApoderado(decimal id, string username, string email, string ap_paterno, string ap_materno, 
                                        string nombre, string telefono, string celular, string password, decimal rolId)
        {
            Conexion.Entidades.InsertarApoderado(id, username, email, ap_paterno,
                      ap_materno, nombre, telefono, celular, password, rolId);
            Conexion.Entidades.SaveChanges();


        }

    }
}
