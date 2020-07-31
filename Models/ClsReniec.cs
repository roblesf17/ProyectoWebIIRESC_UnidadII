using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGEM_TAEX.Models
{
    public class ClsReniec
    {
        public string DNI { set; get; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public string primer_nombre_cls { set; get; }
        public string segundo_nombre_cls { set; get; }
        public string apellidomaterno_cls { set; get; }
        public string apellidopaterno_cls { set; get; }
    }

    public class Root
    {
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }

    }

}