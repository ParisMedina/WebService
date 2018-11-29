using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALC;
using Negocio;
using System.Net;
using System.Net.Mail;

namespace WebApplication1
{
    public partial class RealizarPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                CargarAlumnos();

            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

            String id = Session["id"].ToString();
            decimal apoderado_id = Convert.ToDecimal(id);//apoderado_id

            DateTime fecha = System.DateTime.Today; //fecha
            int monto = Int32.Parse(tbxMonto.Text); //monto

            string nombreAlumno = DdAlumno.SelectedValue;
            var al = (from i in Conexion.Entidades.ALUMNO
                       where i.NOMBRE == nombreAlumno
                       select i );
            foreach (var p in al) {
                p.DEUDA = p.DEUDA - monto;
            }



            var cur = (from i in Conexion.Entidades.ALUMNO
                       where i.NOMBRE == nombreAlumno
                       select i.CURSO_ID_CURSO).First();

            var en = (from j in Conexion.Entidades.ENCARGADO    //encargadoId 
                      where j.CURSO_ID_CURSO == cur
                      select j.ENCARGADO_ID).First();

            var con = (from x in Conexion.Entidades.CONTRATO
                       where x.ENCARGADO_ENCARGADO_ID == en
                       select x.CONTRATO_ID).First(); //contrato id

       
            string descripcion = tbxDescripcion.Text; //descriocion

            var pagId = (from p in Conexion.Entidades.PAGO select p.PAGO_ID).Max();
            decimal pago_id = pagId + 1;  //pago id


            PAGO pago = new PAGO();

            pago.PAGO_ID = pago_id;
            pago.FECHA_PAGO = fecha;
            pago.MONTO_PAGO = monto;
            pago.CONTRATO_CONTRATO_ID = con;
            pago.APODERADO_APODERADO_ID = apoderado_id;
            pago.ENCARGADO_ENCARGADO_ID = en;
            pago.DESCRIPCION = descripcion;



            Conexion.Entidades.PAGO.Add(pago);




            Conexion.Entidades.SaveChanges();

            //CREAR CORREO
            MailMessage msj = new MailMessage();
            //obtener correo
            var correo = (from x in Conexion.Entidades.APODERADO
                          where apoderado_id == x.APODERADO_ID
                          select x.EMAIL).First();
            msj.To.Add(new MailAddress(correo));
            msj.From = new MailAddress("Agencia.OnTour.Estudiantes@gmail.com");


            msj.Subject = "Pago realizado ";
            msj.Body = "Se ha realizado un pago con un monto de $" + monto;
            msj.IsBodyHtml = false;
            msj.Priority = MailPriority.Normal;
            //definir smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("agenciaontour.estudiantes@gmail.com", "portafolio123");
            smtp.Send(msj);



            Response.AddHeader("REFRESH", "3;URL=ApoderadoTemp.aspx");
        }

        public void CargarAlumnos() {

            String id = Session["id"].ToString();
            int idApo = Int32.Parse(id);




            var alum = (from a in Conexion.Entidades.ALUMNO
                        where a.APODERADO_APODERADO_ID == idApo
                        select a.NOMBRE 
                        );


            DdAlumno.DataSource = alum.ToList();
            DdAlumno.DataBind();
            DdAlumno.Items.Insert(0, "SELECIONE");
        }
    }
}