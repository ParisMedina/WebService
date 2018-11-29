using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFPolizas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPoliza" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioPoliza.svc o ServicioPoliza.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioPoliza : IServicioPoliza
    {
        public Poliza ObtenerPoliza(string Identificacion)
        {
            if (Identificacion == "0")
            {
                return new Poliza() { Incidencia = "accidente grave", nombrePoliza = "seguro para accidente grave", numeroPoliza = 1, aseguradora = "Te aseguramos la vida", cantidadPersonas = 40, DiasCobertura = 20, montoPoliza = 50000 };

            }
            else if (Identificacion == "1")
            {
                return new Poliza() { Incidencia = "robo o hurto", nombrePoliza = "seguro para robo o hurto en domiciliado", numeroPoliza = 2, aseguradora = "Te aseguramos la vida", cantidadPersonas = 40, DiasCobertura = 20, montoPoliza = 50000 };
            }
            else if (Identificacion == "2")
            {
                return new Poliza() { Incidencia = "incendio", nombrePoliza = "seguro contra incendio", numeroPoliza = 3, aseguradora = "Te aseguramos la vida", cantidadPersonas = 40, DiasCobertura = 20, montoPoliza = 50000 };
            }
            else if (Identificacion == "3")
            {
                return new Poliza() { Incidencia = "catastrofe", nombrePoliza = "seguro para desastre natural", numeroPoliza = 4, aseguradora = "Te aseguramos la vida", cantidadPersonas = 40, DiasCobertura = 20, montoPoliza = 50000 };
            }
            else if (Identificacion == "4")
            {
                return new Poliza() { Incidencia = "riesgo vital", nombrePoliza = "seguro de vida", numeroPoliza = 5, aseguradora = "Te aseguramos la vida", cantidadPersonas = 40, DiasCobertura = 20, montoPoliza = 50000 };
            }
            else
            {
                return new Poliza() { error = "poliza no encontrada" };

            }
        }
    }
}
