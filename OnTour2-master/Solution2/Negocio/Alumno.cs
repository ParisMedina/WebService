using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;
namespace Negocio
{
    public class Alumno
    {
        public decimal id { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string nombre { get; set; }
        public string rut { get; set; }
        public DateTime fecha_nac { get; set; }
        public decimal apoderado_id { get; set; }
        public decimal curso_id { get; set; }

        public Alumno()
        {

        }

        public Alumno(decimal id, string ap_paterno, string ap_materno, string nombre, string rut, DateTime fecha_nac, decimal apoderado_id, decimal curso_id)
        {
            this.id = id;
            this.ap_paterno = ap_paterno;
            this.ap_materno = ap_materno;
            this.nombre = nombre;
            this.rut = rut;
            this.fecha_nac = fecha_nac;
            this.apoderado_id = apoderado_id;
            this.curso_id = curso_id;
        }

        public void InsertarAlumno(decimal id, string ap_paterno, string ap_materno, string nombre, string rut, DateTime fecha_nac, decimal apoderado_id, decimal curso_id) {

            Conexion.Entidades.AgregarAlumno(id, ap_paterno, ap_materno, nombre, rut, fecha_nac, apoderado_id, curso_id);
            Conexion.Entidades.SaveChanges();



        }
    }
}
