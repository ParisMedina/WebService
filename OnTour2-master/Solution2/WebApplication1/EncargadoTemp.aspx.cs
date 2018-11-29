using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using DALC;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
namespace WebApplication1
{
    public partial class EncargadoTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = Session["user"].ToString();
            String id = Session["id"].ToString();

            txtUser.Text = "Bienvenido " + user;
            CargarAlumnos();
            CargarContrato();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["user"] = "";
            Session["id"] = "";
            Response.Redirect("Login.aspx");
        }



        protected void btnRealizarPago_Click(object sender, EventArgs e)
        {
            lblFormulario.Enabled = true;
            lblMonto.Enabled = true;
            lblDescripcion.Enabled = true;
            tbxDescripcion.Enabled = true;
            rfvDescripcion.Enabled = true;
            tbxMonto.Enabled = true;
            rfvPago.Enabled = true;
            btnPagar.Enabled = true;


            lblFormulario.Visible = true;
            lblMonto.Visible = true;
            tbxMonto.Visible = true;
            rfvPago.Visible = true;
            btnPagar.Visible = true;
            lblDescripcion.Visible = true;
            tbxDescripcion.Visible = true;
            rfvDescripcion.Visible = true;

        }

        protected void btnRevisarContrato_Click(object sender, EventArgs e)
        {


            String id = Session["id"].ToString();
            decimal encargado_id = Decimal.Parse(id);
            //consulta de existencia de contratos
            var cant_cont = (from x in Conexion.Entidades.CONTRATO
                             where encargado_id == x.ENCARGADO_ENCARGADO_ID
                             select x).Count();
            switch (cant_cont)
            {
                case 0:
                    lblEstado.Text = "No presenta contratos existentes";

                    break;

                case 1:
                    lblContrato.Enabled = true;
                    gvContrato.Enabled = true;
                    lblContrato.Visible = true;
                    gvContrato.Visible = true;
                    //consultas para el llenado de informacion dependiendo del encargado
                    //obtener nombre completo del encargado
                    var nombreEn = (from x in Conexion.Entidades.ENCARGADO
                                    where encargado_id == x.ENCARGADO_ID
                                    select x.NOMBRE).First();

                    var apelPatEn = (from x in Conexion.Entidades.ENCARGADO
                                     where encargado_id == x.ENCARGADO_ID
                                     select x.AP_PATERNO).First();

                    var apelMatEn = (from x in Conexion.Entidades.ENCARGADO
                                     where encargado_id == x.ENCARGADO_ID
                                     select x.AP_MATERNO).First();
                    string nomEncargadoCompleto = nombreEn + " " + apelPatEn + " " + apelMatEn;
                    //obtener nombre del curso del encargado
                    var nombreCurso = (from x in Conexion.Entidades.ENCARGADO
                                   where encargado_id == x.ENCARGADO_ID
                                   select x.CURSO.NOMBRE_CURSO).First();
                    //obtener nombre de colegio del encargado
                    var cursoId = (from x in Conexion.Entidades.ENCARGADO
                                   where encargado_id == x.ENCARGADO_ID
                                   select x.CURSO_ID_CURSO).First();

                    var nombreColegio = (from x in Conexion.Entidades.CURSO
                                       where cursoId == x.ID_CURSO
                                       select x.COLEGIO.NOMBRE_COLEGIO).First();

                    //obtener valor de contrato
                    var valorContrato = (from x in Conexion.Entidades.CONTRATO
                                         where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                         select x.TOTAL).First();

                    //obtener destino
                    var nombreDestino = (from x in Conexion.Entidades.CONTRATO
                                         where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                         select x.DESTINO.PAIS).First();

                    //obtener tour
                    var nombreTour = (from x in Conexion.Entidades.CONTRATO
                                      where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                      select x.TOUR.NOMBRE_TOURS).First();

                    //obtener seguro

                    var nombreSeguro = (from x in Conexion.Entidades.CONTRATO
                                        where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                        select x.POLIZA.NOMBRE_POLIZA).First();

                    var infoSeguro = (from x in Conexion.Entidades.CONTRATO
                                      where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                      select x.POLIZA.DESCRIPCION).First();

                    var valorSeguro = (from x in Conexion.Entidades.CONTRATO
                                       where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                       select x.POLIZA.PRIMA).First();

                    var valorAsegu = (from x in Conexion.Entidades.CONTRATO
                                       where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                       select x.POLIZA.SUMA_ASEGURADA).First();
                    //obtener servicios

                    var nombreServicio = (from x in Conexion.Entidades.CONTRATO
                                          where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                          select x.SER_ADICIONAL.NOMBRE_SER).First();

                    var totalServicio = (from x in Conexion.Entidades.CONTRATO
                                         where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                         select x.SER_ADICIONAL.PRECIO).First();

                    //fecha del viaje

                    var fechaViaje = (from x in Conexion.Entidades.CONTRATO
                                      where encargado_id == x.ENCARGADO_ENCARGADO_ID
                                      select x.FECHA).First();

                    //PDF
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    Document doc = new Document(PageSize.LETTER);
                    PdfWriter writer = PdfWriter.GetInstance(doc, HttpContext.Current.Response.OutputStream);
                    doc.Open();

                  
                    //titulo 
                    Paragraph titulo = new Paragraph("CONTRATO DE VIAJE \n \n \n", FontFactory.GetFont("arial", 20, BaseColor.BLACK));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    //cuerpo
                    Paragraph cuerpo = new Paragraph("Entre la agencia de viajes OnTour, en adelante la “EMPRESA”, por una parte y por la otra el encargado/a " + nomEncargadoCompleto + " del colegio " + nombreColegio + " del curso " + nombreCurso + ", en adelante el “Cliente”, convienen celebrar el presente CONTRATO DE COMPRA DE PAQUETE TURISTICO DE ESTUDIO, el cual tendrá el siguiente detalle: \n \n ");
                    cuerpo.Alignment = Element.ALIGN_JUSTIFIED;
                    
                    //cuerpoPAGOS
                    Paragraph cuerpoPagos = new Paragraph("PAGOS: \n \nEl valor de los pasajes son asignados automáticamente a los alumnos que son parte del curso anteriormente mencionados, el valor designado para este es de $" + valorContrato + " pesos chilenos para cada alumno.  \n \n ");
                    cuerpoPagos.Alignment = Element.ALIGN_JUSTIFIED;

                    //cuerpoDestinos 
                    Paragraph cuerpoDestinos = new Paragraph("DESTINOS: \n \nTomando en cuenta las peticiones mencionadas en el sistema por " + nomEncargadoCompleto + ", el destino elegido es " + nombreDestino + ", junto con el tour " + nombreTour + " \n \n");
                    cuerpoDestinos.Alignment = Element.ALIGN_JUSTIFIED;

                    //cuerpoSeguros
                    Paragraph cuerpoSeguros = new Paragraph("SEGUROS: \n \nEl seguro elegido para cada uno de los estudiantes es " + nombreSeguro + ", que ofrece " + infoSeguro + " con el valor de $" + valorSeguro + " y con una suma asegurada de $" + valorAsegu + ", estando este ya agregado al valor total del contrato. \n \n");
                    cuerpoSeguros.Alignment = Element.ALIGN_JUSTIFIED;

                    //cuerpoServicios
                    Paragraph cuerpoServicio = new Paragraph("SERVICIOS ADICIONALES: \n \n Los servicios adicionales requeridos para el viaje son " + nombreServicio + " con el valor adicional de $" + totalServicio + " estando este ya agregado al valor total del contrato. \n \n");
                    cuerpoServicio.Alignment = Element.ALIGN_JUSTIFIED;


                    //final

                    Paragraph final = new Paragraph("\n \nTomando estos puntos presentados y detallados del viaje el cual será realizado el día " + fechaViaje);
                    final.Alignment = Element.ALIGN_JUSTIFIED;


                    doc.Add(titulo);
                    doc.Add(cuerpo);
                    doc.Add(cuerpoPagos);
                    doc.Add(cuerpoDestinos);
                    doc.Add(cuerpoSeguros);
                    doc.Add(cuerpoServicio);
                    doc.Add(final);
                    doc.Close();

                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Contrato de viaje.pdf");
                    HttpContext.Current.Response.Write(doc);
                    HttpContext.Current.Response.BufferOutput = true;
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.Close();


                    break;


                default:
                    break;
            }













        }

        protected void btnArmaContrato_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArmarContrato.aspx");
        }

        public void CargarAlumnos()
        {
            String id = Session["id"].ToString();

            decimal encargado_id = Convert.ToDecimal(id);

            var en = (from x in Conexion.Entidades.ENCARGADO
                      where x.ENCARGADO_ID == encargado_id
                      select x.CURSO_ID_CURSO).First();

            var al = (from y in Conexion.Entidades.ALUMNO
                      where y.CURSO_ID_CURSO == en
                      select new
                      {
                          y.AP_PATERNO,
                          y.AP_MATERNO,
                          y.NOMBRE,
                          y.RUT,
                          y.FECH_NAC,
                          y.DEUDA
                      });

            gvAlumnos.DataSource = al.ToList();
            gvAlumnos.DataBind();


        }
        public void CargarContrato()
        {
            String id = Session["id"].ToString();
            decimal encargado_id = Convert.ToDecimal(id);
            var con = (from x in Conexion.Entidades.CONTRATO
                       where x.ENCARGADO_ENCARGADO_ID == encargado_id
                       select new
                       {

                           x.DESTINO.PAIS,
                           x.TOUR.NOMBRE_TOURS,
                           x.POLIZA.NOMBRE_POLIZA,
                           x.SER_ADICIONAL.NOMBRE_SER,
                           x.FECHA,
                           x.TOTAL

                       });


            gvContrato.DataSource = con.ToList();
            gvContrato.DataBind();


        }
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            String id = Session["id"].ToString();
            decimal encargado_id = Convert.ToDecimal(id);//encargado_id
            var en = (from x in Conexion.Entidades.ENCARGADO            //id del curso del encargado
                      where x.ENCARGADO_ID == encargado_id
                      select x.CURSO_ID_CURSO).First();

            var con = (from j in Conexion.Entidades.CONTRATO
                       where j.ENCARGADO_ENCARGADO_ID == en
                       select j.CONTRATO_ID).First();


            var cant_al = (from y in Conexion.Entidades.ALUMNO               //cantidad de alumnos asignados al curso del encargado
                           where y.CURSO_ID_CURSO == en
                           select y).Count();

            var al = (from k in Conexion.Entidades.ALUMNO           //lista objeto ALUMNO
                      where k.CURSO_ID_CURSO == en
                      select k);

            int montoTotal = Int32.Parse(tbxMonto.Text); //monto pago

            int montoRepartir = montoTotal / cant_al;

            foreach (var i in al)
            {
                i.DEUDA = i.DEUDA - montoRepartir;
            }
            //REGISTRO EN TABLA PAGO
            var pagId = (from p in Conexion.Entidades.PAGO select p.PAGO_ID).Max();
            decimal pago_id = pagId + 1;  //pago id

            //fecha pago
            DateTime fecha = System.DateTime.Today;

            Nullable<Decimal> apoderado_id = null;


            //descripcion
            string descripcion = tbxDescripcion.Text;
            PAGO pago = new PAGO();

            pago.PAGO_ID = pago_id;
            pago.FECHA_PAGO = fecha;
            pago.MONTO_PAGO = montoTotal;
            pago.CONTRATO_CONTRATO_ID = con;
            pago.APODERADO_APODERADO_ID = apoderado_id;
            pago.ENCARGADO_ENCARGADO_ID = encargado_id;
            pago.DESCRIPCION = descripcion;

            Conexion.Entidades.PAGO.Add(pago);




            Conexion.Entidades.SaveChanges();


            Response.Redirect("EncargadoTemp.aspx");
        }
    }
}