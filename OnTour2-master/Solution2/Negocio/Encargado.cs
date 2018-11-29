using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio
{
    public class Encargado
    {
        public decimal encargado_id { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
        public decimal agente_id { get; set; }
        public string username { get; set; }
        public decimal rol_id { get; set; }
        public decimal curso_id { get; set; }

        public Encargado()
        {
                
        }

        public Encargado(decimal encargado_id, string nombre, string ap_paterno, string ap_materno, string email, string password, string telefono, decimal agente_id, string username, decimal rol_id, decimal curso_id)
        {
            this.encargado_id = encargado_id;
            this.nombre = nombre;
            this.ap_paterno = ap_paterno;
            this.ap_materno = ap_materno;
            this.email = email;
            this.password = password;
            this.telefono = telefono;
            this.agente_id = agente_id;
            this.username = username;
            this.rol_id = rol_id;
            this.curso_id = curso_id;
        }

        public void InsertarEncargado(decimal encargado_id, string nombre, string ap_paterno, string ap_materno, 
            string email, string password, string telefono, decimal agente_id, string username, decimal rol_id, decimal curso_id) {

            Conexion.Entidades.InsertarEncargado(encargado_id, nombre, ap_paterno, ap_materno, email,
                password, telefono, agente_id, username,rol_id,curso_id);
            Conexion.Entidades.SaveChanges();


        }
    }
}
