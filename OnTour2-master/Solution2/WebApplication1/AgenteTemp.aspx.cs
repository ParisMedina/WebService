using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgenteTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPoliza_Click(object sender, EventArgs e)
        {
            var identificacion = txtIdentificacion.Text;

            using (ReferenciaWCF.ServicioPolizaClient Poliza = new ReferenciaWCF.ServicioPolizaClient())
            {
                var poliza = Poliza.ObtenerPoliza(identificacion);
            }

        }
    }
}