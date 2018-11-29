using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFPolizas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioPoliza" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioPoliza
    {
        [OperationContract]
        Poliza ObtenerPoliza(string Identificacion);

    }
    [DataContract]
    public class Poliza : BaseRespuesta
    {
        [DataMember]
        public string Incidencia { get; set; }
        [DataMember]
        public string nombrePoliza { get; set; }
        [DataMember]
        public int numeroPoliza { get; set; }
        [DataMember]
        public int montoPoliza { get; set; }
        [DataMember]
        public string aseguradora { get; set; }
        [DataMember]
        public int cantidadPersonas { get; set; }
        [DataMember]
        public int DiasCobertura { get; set; }
    }
    [DataContract]
    public class BaseRespuesta
    {
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public string error { get; set; }
    }
}
