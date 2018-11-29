using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace WebApplication1
{
    public partial class VerContratoAp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = Session["user"].ToString();
            String id = Session["id"].ToString();
            if (!IsPostBack)
            {
                CargarDdlAlumno();
            }
            }

        protected void VerContrato_Click(object sender, EventArgs e)
        {
            string nombre_al = DdlNombreAl.SelectedValue;

            //tomar id curso para encontrar encargado

            var id_curso = (from x in Conexion.Entidades.ALUMNO
                            where x.NOMBRE == nombre_al
                            select x.CURSO_ID_CURSO).First();
            //encargado id 
        
            var id_encargado = (from x in Conexion.Entidades.ENCARGADO
                                where x.CURSO_ID_CURSO == id_curso
                                select x.ENCARGADO_ID).First();
            //consulta de existencia de contratos
            var cant_cont = (from x in Conexion.Entidades.CONTRATO
                             where id_encargado == x.ENCARGADO_ENCARGADO_ID
                             select x).Count();

            switch (cant_cont)
            {
                case 0:
                    lblPrueba.Text = "No presenta contratos existentes";

                    break;

                case 1:
                
                    //consultas para el llenado de informacion dependiendo del encargado
                    //obtener nombre completo del encargado
                    var nombreEn = (from x in Conexion.Entidades.ENCARGADO
                                    where id_encargado == x.ENCARGADO_ID
                                    select x.NOMBRE).First();

                    var apelPatEn = (from x in Conexion.Entidades.ENCARGADO
                                     where id_encargado == x.ENCARGADO_ID
                                     select x.AP_PATERNO).First();

                    var apelMatEn = (from x in Conexion.Entidades.ENCARGADO
                                     where id_encargado == x.ENCARGADO_ID
                                     select x.AP_MATERNO).First();
                    string nomEncargadoCompleto = nombreEn + " " + apelPatEn + " " + apelMatEn;

                    //obtener nombre completo del alumno
                    var ap_paternoAl = (from x in Conexion.Entidades.ALUMNO
                                        where nombre_al == x.NOMBRE
                                        select x.AP_PATERNO).First();
                    var ap_maternoAl = (from x in Conexion.Entidades.ALUMNO
                                        where nombre_al == x.NOMBRE
                                        select x.AP_MATERNO).First();

                    string nombre_completoAl = nombre_al + " " + ap_paternoAl + " " + ap_maternoAl;


                    //obtener nombre del curso del encargado
                    var nombreCurso = (from x in Conexion.Entidades.ENCARGADO
                                       where id_encargado == x.ENCARGADO_ID
                                       select x.CURSO.NOMBRE_CURSO).First();
                    //obtener nombre de colegio del encargado
                    var cursoId = (from x in Conexion.Entidades.ENCARGADO
                                   where id_encargado == x.ENCARGADO_ID
                                   select x.CURSO_ID_CURSO).First();

                    var nombreColegio = (from x in Conexion.Entidades.CURSO
                                         where cursoId == x.ID_CURSO
                                         select x.COLEGIO.NOMBRE_COLEGIO).First();

                    //obtener valor de contrato
                    var valorContrato = (from x in Conexion.Entidades.CONTRATO
                                         where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                         select x.TOTAL).First();

                    //obtener destino
                    var nombreDestino = (from x in Conexion.Entidades.CONTRATO
                                         where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                         select x.DESTINO.PAIS).First();

                    //obtener tour
                    var nombreTour = (from x in Conexion.Entidades.CONTRATO
                                      where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                      select x.TOUR.NOMBRE_TOURS).First();

                    //obtener seguro

                    var nombreSeguro = (from x in Conexion.Entidades.CONTRATO
                                        where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                        select x.POLIZA.NOMBRE_POLIZA).First();

                    var infoSeguro = (from x in Conexion.Entidades.CONTRATO
                                      where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                      select x.POLIZA.DESCRIPCION).First();

                    var valorSeguro = (from x in Conexion.Entidades.CONTRATO
                                       where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                       select x.POLIZA.PRIMA).First();

                    var valorAsegu = (from x in Conexion.Entidades.CONTRATO
                                      where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                      select x.POLIZA.SUMA_ASEGURADA).First();
                    //obtener servicios

                    var nombreServicio = (from x in Conexion.Entidades.CONTRATO
                                          where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                          select x.SER_ADICIONAL.NOMBRE_SER).First();

                    var totalServicio = (from x in Conexion.Entidades.CONTRATO
                                         where id_encargado == x.ENCARGADO_ENCARGADO_ID
                                         select x.SER_ADICIONAL.PRECIO).First();

                    //fecha del viaje

                    var fechaViaje = (from x in Conexion.Entidades.CONTRATO
                                      where id_encargado == x.ENCARGADO_ENCARGADO_ID
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
                    Paragraph cuerpo = new Paragraph("Entre la agencia de viajes OnTour, en adelante la “EMPRESA”, por una parte y por la otra el encargado/a " + nomEncargadoCompleto + " y el alumno " + nombre_completoAl + " del colegio " + nombreColegio + " del curso " + nombreCurso + ", en adelante el “Cliente”, convienen celebrar el presente CONTRATO DE COMPRA DE PAQUETE TURISTICO DE ESTUDIO, el cual tendrá el siguiente detalle: \n \n ");
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

        public void CargarDdlAlumno() {
            String id = Session["id"].ToString();
            int idApo = Int32.Parse(id);

            var alum = (from a in Conexion.Entidades.ALUMNO
                        where a.APODERADO_APODERADO_ID == idApo
                        select a.NOMBRE);


            DdlNombreAl.DataSource = alum.ToList();
            DdlNombreAl.DataBind();
            DdlNombreAl.Items.Insert(0, "SELECIONE");




        }
    }
}