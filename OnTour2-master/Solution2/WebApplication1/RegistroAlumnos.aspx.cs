using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using DALC;

namespace WebApplication1
{

    public partial class RegistroAlumnos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                cargarColegios();

            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //id de apoderado
            String id = Session["id"].ToString();
            decimal idApo = Decimal.Parse(id);

            ALUMNO al = new ALUMNO();


            var a = (from p in Conexion.Entidades.ALUMNO select p.ALUMNO_ID).Max();
            decimal idAlumno = a + 1;
            string nombre = tbxNombre.Text.ToUpper();
            string apellidoP = tbxApellidoP.Text.ToUpper();
            string apellidoM = tbxApellidoM.Text.ToUpper();
            string rut = tbxRut.Text.ToUpper();
            string nombreCur = ddlCursos.SelectedItem.ToString();


            DateTime fecha_nac = DateTime.Parse(tbxFecha.Text);



            //sacar id por el nombre del curso
            var i = (from c in Conexion.Entidades.CURSO
                     where c.NOMBRE_CURSO == nombreCur
                     select c.ID_CURSO).First();



            //HACER ASIGNACION DE DEUDA JUNTO CON LA CREACION DEL ALUMNO
            //OBTENER CANTIDAD DE CONTRATOS HECHOS POR EL ENCARGADO DE UN CURSO
            var en = (from x in Conexion.Entidades.ENCARGADO
                      where x.CURSO_ID_CURSO == i
                      select x.CONTRATO).Count();


            var enId = (from x in Conexion.Entidades.ENCARGADO
                        where x.CURSO_ID_CURSO == i
                        select x.ENCARGADO_ID).First();


        



            var deuda = (from c in Conexion.Entidades.CONTRATO
                         where c.ENCARGADO_ENCARGADO_ID == enId
                         select c.TOTAL).FirstOrDefault();

            switch (en)
            {
                case 0:

                    al.CURSO_ID_CURSO = i;
                    al.ALUMNO_ID = idAlumno;
                    al.AP_PATERNO = apellidoP;
                    al.AP_MATERNO = apellidoM;
                    al.NOMBRE = nombre;
                    al.RUT = rut;
                    al.FECH_NAC = fecha_nac;
                    al.APODERADO_APODERADO_ID = idApo;
                    al.DEUDA = 0;
                    Conexion.Entidades.ALUMNO.Add(al);
                    Conexion.Entidades.SaveChanges();
                    Estado.Text = "Alumno Agregado";
                    Response.AddHeader("REFRESH", "3;URL=ApoderadoTemp.aspx");
                    break;

                case 1:

                    al.CURSO_ID_CURSO = i;
                    al.ALUMNO_ID = idAlumno;
                    al.AP_PATERNO = apellidoP;
                    al.AP_MATERNO = apellidoM;
                    al.NOMBRE = nombre;
                    al.RUT = rut;
                    al.FECH_NAC = fecha_nac;
                    al.APODERADO_APODERADO_ID = idApo;
                    al.DEUDA = deuda;
                    Conexion.Entidades.ALUMNO.Add(al);
                    Conexion.Entidades.SaveChanges();
                    Estado.Text = "Alumno Agregado";
                    Response.AddHeader("REFRESH", "3;URL=ApoderadoTemp.aspx");

                    break;
                default:
                    break;
            }
















        }

        public void cargarColegios()
        {


            var col = (from x in Conexion.Entidades.COLEGIO
                       select x.NOMBRE_COLEGIO);

            DdlColegio.DataSource = col.ToList();
            DdlColegio.DataBind();
            DdlColegio.Items.Insert(0, "SELECIONE");


        }

        protected void DdlColegio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreColegio = DdlColegio.SelectedValue;


            var colId = (from x in Conexion.Entidades.COLEGIO
                         where x.NOMBRE_COLEGIO == nombreColegio
                         select x.COLEGIO_ID).First();



            var cur = (from y in Conexion.Entidades.CURSO
                       where y.COLEGIO_COLEGIO_ID == colId
                       select y.NOMBRE_CURSO);


            ddlCursos.DataSource = cur.ToList();
            ddlCursos.DataBind();
            ddlCursos.Items.Insert(0, "SELECIONE");
        }
    }
}