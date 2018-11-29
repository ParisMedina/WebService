using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using DALC;
using Oracle.ManagedDataAccess;


namespace WebApplication1
{
    public partial class Registrate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarDdlColegio();

            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ddlTipoUsuario.SelectedValue == "3") //apoderado
            {
                RegistrarApoderado();

            }
            else if (ddlTipoUsuario.SelectedValue == "2")//encargado
            {

                RegistrarEncargado();

            }


        }
        public void cargarDdlCurso() {

            var c = from i in Conexion.Entidades.CURSO
                    select new { i.NOMBRE_CURSO };
            ddlCurso.DataSource = c.ToList();
            ddlCurso.DataBind();
        }
        public void CargarDdlColegio()
        {

            var c = from i in Conexion.Entidades.COLEGIO
                    select new { i.NOMBRE_COLEGIO };
            ddlColegio.DataSource = c.ToList();
            ddlColegio.DataBind();

        }

        public void RegistrarEncargado()
        {
            ENCARGADO en = new ENCARGADO();
            if (RadioButtonList1.SelectedValue == "Si" && RadioButtonList2.SelectedValue == "Si")
            { //list1 = colegio     list2 = curso
                var e = (from p in Conexion.Entidades.ENCARGADO select p.ENCARGADO_ID).Max();
                decimal encargado_id = e + 1;
                string nombre = tbxNombre.Text.ToUpper();
                string apellidoP = tbxApellidoP.Text.ToUpper();
                string apellidoM = tbxApellidoM.Text.ToUpper();
                string username = tbxUsername.Text.ToUpper();
                string password = tbxPassword.Text;
                string email = tbxEmail.Text.ToUpper();
                string telefono = tbxTelefono.Text;
                string nombreCol = ddlColegio.SelectedItem.ToString();
                string nombreCur = ddlCurso.SelectedItem.ToString();


                var i = (from c in Conexion.Entidades.CURSO   // busqueda de id curso mediante nombre
                         where c.NOMBRE_CURSO == nombreCur
                         select c.ID_CURSO).First();

                Random rnd = new Random();
                var ag = (from a in Conexion.Entidades.AGENTE
                          select a).ToList();

                int can_ag = ag.Count() + 1;

                decimal r = Convert.ToDecimal(rnd.Next(can_ag));



                decimal agente_id = r;

                decimal curso_id = i;
                decimal rol_id = 3;

                en.ENCARGADO_ID = encargado_id;
                en.NOMBRE = nombre;
                en.AP_PATERNO = apellidoP;
                en.AP_MATERNO = apellidoM;
                en.EMAIL = email;
                en.PASSWORD = password;
                en.TELEFONO = telefono;
                en.AGENTE_AGENTE_ID = agente_id;
                en.USERNAME = username;
                en.ROLES_ROLES_ID = rol_id;
                en.CURSO_ID_CURSO = curso_id;

                Conexion.Entidades.ENCARGADO.Add(en);
                Conexion.Entidades.SaveChanges();
                lblMensaje.Text = "Agregado Con Exito";
                lblMensaje.Visible = true;


            

            }

        }

        public void RegistrarApoderado()
        {


            Apoderado ap = new Apoderado();

            //buscar ultimo registro

            var a = (from p in Conexion.Entidades.APODERADO select p.APODERADO_ID).Max();


            decimal id = a + 1;
            string username = tbxUsername.Text.ToUpper();
            string password = tbxPassword.Text.ToUpper();
            string email = tbxEmail.Text.ToUpper();
            string nombre = tbxNombre.Text.ToUpper();
            string apellidoP = tbxApellidoP.Text.ToUpper();
            string apellidoM = tbxApellidoM.Text.ToUpper();
            string telefono = tbxTelefono.Text.ToUpper();
            string celular = tbxCelular.Text.ToUpper();
            decimal rol = 2;
            string tipo = ddlTipoUsuario.SelectedItem.ToString();


            ap.InsertarApoderado(id, username, email, apellidoP, apellidoM, nombre, telefono, celular, password, rol);
            lblMensaje.Text = "Agregado Con Exito";
            lblMensaje.Visible = true;

        }

        protected void btnGuardarColegio_Click(object sender, EventArgs e)
        {
            var c = (from x in Conexion.Entidades.COLEGIO select x.COLEGIO_ID).Max();
            decimal colegio_id = c + 1;
            string nombreColegio = tbxNombreColegio.Text.ToUpper();
            string direccion = tbxDireccion.Text.ToUpper();
            string telefono = tbxTelefonoColegio.Text.ToUpper();
            COLEGIO colegio = new COLEGIO();

            colegio.COLEGIO_ID = colegio_id;
            colegio.NOMBRE_COLEGIO = nombreColegio;
            colegio.DIRECCION = direccion;
            colegio.TELEFONO = telefono;
            Conexion.Entidades.COLEGIO.Add(colegio);
            Conexion.Entidades.SaveChanges();
            lblMensajeC.Text = "Colegio agregado Con Exito";
            lblMensaje.Visible = true;
            CargarDdlColegio();
        

            RadioButtonList1.SelectedValue = "Si";

        }

        protected void btnGuardarCurso_Click(object sender, EventArgs e)
        {
            var cur = (from x in Conexion.Entidades.CURSO select x.ID_CURSO).Max();
            decimal curso_id = cur + 1;
            string nombreCurso = tbxNombreCurso.Text.ToUpper();
            string nombreColegio = ddlColegio.SelectedItem.ToString();
            var cuId = (from j in Conexion.Entidades.COLEGIO
                        where j.NOMBRE_COLEGIO == nombreColegio 
                        select j.COLEGIO_ID ).First();
            CURSO curso = new CURSO();

            curso.ID_CURSO = curso_id;
            curso.NOMBRE_CURSO = nombreCurso;
            curso.COLEGIO_COLEGIO_ID = cuId;
            Conexion.Entidades.CURSO.Add(curso);
            Conexion.Entidades.SaveChanges();
            lblMensajeCu.Text = "Curso agregado con exito";
            lblMensajeCu.Visible = true;
            guardarDdlCurso();
            ddlCurso.Enabled = true;
            
            
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "No")
            {
                lblNombreColegio.Enabled = true;
                lblNombreColegio.Visible = true;
                tbxNombreColegio.Enabled = true;
                tbxNombreColegio.Visible = true;
                rfvNombreColegio.Enabled = true;
                rfvNombreColegio.Visible = true;
                lblDireccion.Enabled = true;
                lblDireccion.Visible = true;
                tbxDireccion.Enabled = true;
                tbxDireccion.Visible = true;
                rfvDireccion.Enabled = true;
                rfvDireccion.Visible = true;
                lblTelefonoColegio.Enabled = true;
                lblTelefonoColegio.Visible = true;
                tbxTelefonoColegio.Enabled = true;
                tbxTelefonoColegio.Visible = true;
                rfvFonoColegio.Enabled = true;
                rfvFonoColegio.Visible = true;
                btnGuardarColegio.Enabled = true;
                btnGuardarColegio.Visible = true;
                lblMensajeC.Enabled = true;
                lblMensajeC.Visible = true;
            

                lblNombreCurso.Enabled = false;
                lblNombreCurso.Visible = false;
                tbxNombreCurso.Enabled = false;
                tbxNombreCurso.Visible = false;
                rfvNombreCurso.Enabled = false;
                rfvNombreCurso.Visible = false;
                btnGuardarCurso.Enabled = false;
                btnGuardarCurso.Visible = false;
                lblMensajeCu.Enabled = false;
                lblMensajeCu.Visible = false;
                ddlCurso.Enabled = false;
                rfvCurso.Enabled = false;



            }
            else
            {

                lblNombreColegio.Enabled = false;
                lblNombreColegio.Visible = false;
                tbxNombreColegio.Enabled = false;
                tbxNombreColegio.Visible = false;
                rfvNombreColegio.Enabled = false;
                rfvNombreColegio.Visible = false;
                lblDireccion.Enabled = false;
                lblDireccion.Visible = false;
                tbxDireccion.Enabled = false;
                tbxDireccion.Visible = false;
                rfvDireccion.Enabled = false;
                rfvDireccion.Visible = false;
                lblTelefonoColegio.Enabled = false;
                lblTelefonoColegio.Visible = false;
                tbxTelefonoColegio.Enabled = false;
                tbxTelefonoColegio.Visible = false;
                rfvFonoColegio.Enabled = false;
                rfvFonoColegio.Visible = false;
                btnGuardarColegio.Enabled = false;
                btnGuardarColegio.Visible = false;
                lblMensajeC.Enabled = false;
                lblMensajeC.Visible = false;
                ddlCurso.Enabled = true;


            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedValue == "No")
            {
                lblNombreCurso.Enabled = true;
                lblNombreCurso.Visible = true;
                tbxNombreCurso.Enabled = true;
                tbxNombreCurso.Visible = true;
                rfvNombreCurso.Enabled = true;
                rfvNombreCurso.Visible = true;
                btnGuardarCurso.Enabled = true;
                btnGuardarCurso.Visible = true;
                lblMensajeCu.Enabled = true;
                lblMensajeCu.Visible = true;



            }
            else
            {

                lblNombreCurso.Enabled = false;
                lblNombreCurso.Visible = false;
                tbxNombreCurso.Enabled = false;
                tbxNombreCurso.Visible = false;
                rfvNombreCurso.Enabled = false;
                rfvNombreCurso.Visible = false;
                btnGuardarCurso.Enabled = false;
                btnGuardarCurso.Visible = false;
                lblMensajeCu.Enabled = false;
                lblMensajeCu.Visible = false;


            }
        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlTipoUsuario.SelectedValue == "2")
            {


                lblColegio.Enabled = true;
                lblColegio.Visible = true;
                ddlColegio.Enabled = true;
                ddlColegio.Visible = true;
                rfvColegio.Enabled = true;
                rfvColegio.Visible = true;
                Pregunta1.Enabled = true;
                Pregunta1.Visible = true;
                RadioButtonList1.Enabled = true;
                RadioButtonList1.Visible = true;
                rfvListaColegio.Enabled = true;
                rfvListaColegio.Visible = true;


                lblCurso.Enabled = true;
                lblCurso.Visible = true;
                ddlCurso.Enabled = true;
                ddlCurso.Visible = true;
                rfvCurso.Enabled = true;
                rfvCurso.Visible = true;
                Pregunta2.Enabled = true;
                Pregunta2.Visible = true;
                RadioButtonList2.Enabled = true;
                RadioButtonList2.Visible = true;
                rfvListaCurso.Enabled = true;
                rfvListaCurso.Visible = true;
            }
            else
            {
                lblColegio.Enabled = false;
                lblColegio.Visible = false;
                ddlColegio.Enabled = false;
                ddlColegio.Visible = false;
                rfvColegio.Enabled = false;
                rfvColegio.Visible = false;
                Pregunta1.Enabled = false;
                Pregunta1.Visible = false;
                RadioButtonList1.Enabled = false;
                RadioButtonList1.Visible = false;
                rfvListaColegio.Enabled = false;
                rfvListaColegio.Visible = false;


                lblCurso.Enabled = false;
                lblCurso.Visible = false;
                ddlCurso.Enabled = false;
                ddlCurso.Visible = false;
                rfvCurso.Enabled = false;
                rfvCurso.Visible = false;
                Pregunta2.Enabled = false;
                Pregunta2.Visible = false;
                RadioButtonList2.Enabled = false;
                RadioButtonList2.Visible = false;
                rfvListaCurso.Enabled = false;
                rfvListaCurso.Visible = false;




            }
        }
        public void guardarDdlCurso (){

            string nombreCol = ddlColegio.SelectedValue;

            var col = (from x in Conexion.Entidades.COLEGIO
                       where x.NOMBRE_COLEGIO == nombreCol
                       select x.COLEGIO_ID).First();

            var cur = (from c in Conexion.Entidades.CURSO
                       where c.COLEGIO_COLEGIO_ID == col
                       select new { c.NOMBRE_CURSO });

            ddlCurso.DataSource = cur.ToList();
            ddlCurso.DataBind();

        }
        protected void ddlColegio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreCol = ddlColegio.SelectedValue;

            var col = (from x in Conexion.Entidades.COLEGIO
                       where x.NOMBRE_COLEGIO == nombreCol
                       select x.COLEGIO_ID).First();

            var cur = (from c in Conexion.Entidades.CURSO
                       where c.COLEGIO_COLEGIO_ID == col
                       select new { c.NOMBRE_CURSO });

            ddlCurso.DataSource = cur.ToList();
            ddlCurso.DataBind();
        }
    }
}