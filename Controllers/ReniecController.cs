using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;

using SIGEM_TAEX.Models;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;


namespace SIGEM_TAEX.Controllers
{
    public class ReniecController : Controller
    {
        public static string mayor = "";
        public static string firstname = "";
        public static string segundo_nombre_temporal = "";
        public static string apellidoPaterno_temporal = "";
        public static string apellido_materno_temporal = "";

        // GET: Reniec
        public ActionResult Index(ClsReniec objReniec)
        {
            string dni = "73570928";

            if (dni != null && !dni.Equals(""))
            {
                String url = "https://quertium.com/api/v1/reniec/dni/" + dni + "?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.MTM3NA.VXfwWGycEWoyGTtzUb3YSNI0688GiCIY6FTXETFEO_c";

                WebClient wc = new WebClient();
                var datos = wc.DownloadString(url);
                // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
                var rs = JsonConvert.DeserializeObject<Root>(datos);

                firstname = Convert.ToString(rs.primerNombre);
                ViewBag.segundonombre_ViewBag = Convert.ToString(rs.segundoNombre);
                ViewBag.apellidoPaterno_ViewBag = Convert.ToString(rs.apellidoPaterno);
                ViewBag.apellidoMaterno_ViewBag = Convert.ToString(rs.apellidoMaterno);


            }

            return View();
        }
    }
}