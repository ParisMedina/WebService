using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALC;
using Negocio;
namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.ToUpper();
            string pass = txtPassword.Text;

            var consulta = (from a in Conexion.Entidades.APODERADO
                            where a.USERNAME == user && a.PASSWORD == pass && a.ROLES_ROLES_ID == 2
                            select a);


            var consulta2 = (from u in Conexion.Entidades.ADMINISTRADOR
                             where u.USERNAME == user && u.PASSWORD == pass && u.ROLES_ROLES_ID == 4
                             select u);

            var consulta3 = (from b in Conexion.Entidades.AGENTE
                             where b.USERNAME == user && b.PASSWORD == pass && b.ROLES_ROLES_ID == 1
                             select b);

            var consulta4 = (from c in Conexion.Entidades.ENCARGADO
                             where c.USERNAME == user && c.PASSWORD == pass && c.ROLES_ROLES_ID == 3
                             select c);

            //login apoderado
            if (consulta.Count() > 0)
            {
                foreach (var apo in consulta) {
                    Session["user"] = apo.USERNAME;
                    Session["id"] = apo.APODERADO_ID;
                    Response.Redirect("ApoderadoTemp.aspx");
                }
             

            }
            else {
                //login administrador
                if (consulta2.Count() > 0)
                {

                    foreach (var adm in consulta2)
                    {

                        Session["user"] = adm.USERNAME;
                        Response.Redirect("AdministradorTemp.aspx");
                    }

                }
                else
                    //login agente
                    if (consulta3.Count() > 0)
                {

                    foreach (var ag in consulta3)
                    {
                        Session["user"] = ag.USERNAME;
                        Response.Redirect("AgenteTemp.aspx");

                    }
                }
                else
                //login encargado
                    if (consulta4.Count() > 0)
                {
                    foreach (var en in consulta4)
                    {

                        Session["user"] = en.USERNAME;
                        Session["id"] = en.ENCARGADO_ID;
                        Response.Redirect("EncargadoTemp.aspx");

                    }

                }
                else {

                    Estado.Text = "El usuario no se encuntra registrado";

                }

            }



        }

    }
}
