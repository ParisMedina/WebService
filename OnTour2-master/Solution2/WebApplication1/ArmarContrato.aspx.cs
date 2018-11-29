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
    public partial class ArmarContrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
          
       
           
            if (!IsPostBack)
            {
             
                CargarDdlColegio();
                CargarDdlDestino();
                CargarDdlSeguro();
                CargarDDlServicio();
               
            }

            String user = Session["user"].ToString();
            String id = Session["id"].ToString();
            lblUser.Text = user;

        }

        protected void btnRegistrarContrato_Click(object sender, EventArgs e)
        {
           
            var conId = (from p in Conexion.Entidades.CONTRATO select p.CONTRATO_ID).Max();
            decimal contrato_id = conId + 1; //contratoID

            DateTime fechaViaje = DateTime.Parse (tbxFechaViaje.Text);   //fecha

            string nombreColegio = DdlColegio.SelectedValue; //nombre del colegio

            decimal subTotal = ValorSeguro() + ValorTour();//subtotal

            string nombreSer = DdlServicio.SelectedValue;
            var ser_id = (from a in Conexion.Entidades.SER_ADICIONAL
                          where a.NOMBRE_SER == nombreSer
                          select a.SER_ID).First();
            decimal servicio_id = ser_id; //servicio adicional
            var ser = (from x in Conexion.Entidades.SER_ADICIONAL
                       where x.NOMBRE_SER == nombreSer
                       select x.PRECIO).First();
            decimal valTotal = ser + ValorSeguro() + ValorTour();//total


            string nombreTour = DdlTour.SelectedValue;
            var tou = (from y in Conexion.Entidades.TOUR
                       where y.NOMBRE_TOURS == nombreTour
                       select y.TOUR_ID).First();
            decimal tour_id = tou;//tour id 


            String encargado_id = Session["id"].ToString();  //encargado id 


            decimal aux_id = Decimal.Parse(encargado_id);
            var ag_id = (from z in Conexion.Entidades.ENCARGADO
                         where z.ENCARGADO_ID == aux_id
                         select z.AGENTE_AGENTE_ID).First();
            decimal agente_id = ag_id;  //agente_id
        
            string nombreDestino = DdlDestino.SelectedValue;
            var des = (from i in Conexion.Entidades.DESTINO
                       where i.PAIS == nombreDestino
                       select i.DESTINO_ID).First();
            decimal destino_id = des;     //destino id 

           
            string nombreSeguro = DdlSeguro.SelectedValue;
            var seg = (from j in Conexion.Entidades.POLIZA
                       where j.NOMBRE_POLIZA == nombreSeguro
                       select j.POLIZA_ID).First();
            decimal poliza_id = seg; //poliza id 
                                     // AGREGAR
            CONTRATO contra = new CONTRATO();
            contra.CONTRATO_ID = contrato_id;
            contra.FECHA = fechaViaje;
            contra.NOMBRE_COLEGIO = nombreColegio;
            contra.SUBTOTAL = subTotal;
            contra.TOTAL = valTotal;
            contra.TOUR_TOUR_ID = tour_id;
            contra.AGENTE_AGENTE_ID = agente_id;
            contra.DESTINO_DESTINO_ID = destino_id;
            contra.POLIZA_POLIZA_ID = poliza_id;
            contra.ENCARGADO_ENCARGADO_ID = aux_id;
            contra.SER_ADICIONAL_ID = servicio_id;

            Conexion.Entidades.CONTRATO.Add(contra);
            Conexion.Entidades.SaveChanges();
            lblEstado.Text = "Felicidades tu contrato se ha guardado correctamente";

            //hacer prorrateo 
            var en = (from x in Conexion.Entidades.ENCARGADO
                      where x.ENCARGADO_ID == aux_id
                      select x.CURSO_ID_CURSO).First();

            var al = (from k in Conexion.Entidades.ALUMNO
                      where k.CURSO_ID_CURSO == en 
                      select k);

            foreach (var p in al) {
                p.DEUDA = valTotal;
            }
            Conexion.Entidades.SaveChanges();

            Response.AddHeader("REFRESH", "3;URL=EncargadoTemp.aspx");
        }

        public void CargarDdlColegio() {
            String id = Session["id"].ToString();
            decimal encargado_id = Convert.ToDecimal(id);

            var en = (from x in Conexion.Entidades.ENCARGADO
                      where x.ENCARGADO_ID == encargado_id
                      select x.CURSO_ID_CURSO).First();

            var col = (from y in Conexion.Entidades.CURSO
                       where y.ID_CURSO == en
                       select y.COLEGIO_COLEGIO_ID).First();

            var nCol = (from z in Conexion.Entidades.COLEGIO
                        where z.COLEGIO_ID == col
                        select  z.NOMBRE_COLEGIO );

            DdlColegio.DataSource = nCol.ToList();
            DdlColegio.DataBind();
            DdlColegio.Items.Insert(0, "SELECIONE");
        }
        public void CargarDdlDestino() {
            var des = from x in Conexion.Entidades.DESTINO
                       select x.PAIS ;

            DdlDestino.DataSource = des.ToList();
            DdlDestino.DataBind();
            DdlDestino.Items.Insert(0, "SELECIONE");


        }
        protected void DdlDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreDestino = DdlDestino.SelectedValue;

            var col = (from x in Conexion.Entidades.DESTINO
                      where x.PAIS == nombreDestino
                      select x.DESTINO_ID).First();
        
            
            var cur = from c in Conexion.Entidades.TOUR
                       where c.TOUR_ID == col
                       select c.NOMBRE_TOURS;





            
            DdlTour.DataSource = cur.ToList();
            DdlTour.DataBind();
            DdlTour.Items.Insert(0, "SELECIONE");

        }
        public void CargarDdlSeguro (){

            var ser = from x in Conexion.Entidades.POLIZA
                      select x.NOMBRE_POLIZA;

            DdlSeguro.DataSource = ser.ToList();
            DdlSeguro.DataBind();
            DdlSeguro.Items.Insert(0, "SELECIONE");


        }
        public void CargarDDlServicio() {

            var ser = (from x in Conexion.Entidades.SER_ADICIONAL
                       select x.NOMBRE_SER);


            DdlServicio.DataSource = ser.ToList();
            DdlServicio.DataBind();
            DdlServicio.Items.Insert(0, "SELECIONE");




        }
        protected void DdlSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombrePol = DdlSeguro.SelectedValue;

            var ser = (from x in Conexion.Entidades.POLIZA
                      where x.NOMBRE_POLIZA == nombrePol
                      select x.DESCRIPCION).First();



            decimal valorSubTotal = ValorSeguro() + ValorTour();
            lblInfoSeguro.Text = ser;
            lblSubTotal.Text = valorSubTotal.ToString();


           
        }

        protected void DdlTour_SelectedIndexChanged(object sender, EventArgs e)
        {


            string nombreTour = DdlTour.SelectedValue;
            var val = (from x in Conexion.Entidades.TOUR
                       where x.NOMBRE_TOURS == nombreTour
                       select x.PRECIO_TOTAL).First();

           tbxPrecioTour.Text = val.ToString();




        }

        //metodo para poner en el selected index changed
        public Decimal ValorTour() {
            string nombreTour = DdlTour.SelectedValue;

            var val = (from x in Conexion.Entidades.TOUR
                      where x.NOMBRE_TOURS == nombreTour
                      select  x.PRECIO_TOTAL).First();

            return val;

        }

        //metodo para sacar valor $$ del seguro 

        public Decimal ValorSeguro() {
            string nombreSeguro = DdlSeguro.SelectedValue;

            var val = (from x in Conexion.Entidades.POLIZA
                       where x.NOMBRE_POLIZA == nombreSeguro
                       select x.PRIMA).First();

            return val;



        }

        protected void DdlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreSer = DdlServicio.SelectedValue;
            var ser = (from x in Conexion.Entidades.SER_ADICIONAL
                      where x.NOMBRE_SER == nombreSer
                      select x.PRECIO).First();
            decimal valTotal = ser + ValorSeguro() + ValorTour();
            lblTotal.Text = valTotal.ToString();
        }
    }
}