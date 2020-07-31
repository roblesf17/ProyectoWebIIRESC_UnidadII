using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;


using System.Net;
using Newtonsoft.Json;

namespace SIGEM_TAEX.Controllers
{
    public class DocenteController : Controller
    {

        private Docente objDocente = new Docente();
        // GET: Docente
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objDocente.Listar());
            }
            else
            {
                return View(objDocente.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objDocente.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objDocente.Listar()
                    : objDocente.Buscar(Criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objDocente.Listar();
            //  
            return View(
                id == 0 ? new Docente()
                        : objDocente.Obtener(id)
            );
        }



        public ActionResult Login()
        {
            return Redirect("~/Docente");
        }





        public ActionResult AgregarEditarModificar(int id = 0)
        {//
            ViewBag.Docente = objDocente.Listar();
            //  
            return View(
                id == 0 ? new Docente()
                        : objDocente.Obtener(id)
            );
        }

        public ActionResult Guardar(Docente model , string submitButton)
        {
            
            switch (submitButton)
            {
                case "Consultar en RENIEC":

                    //
                    string dni = Convert.ToString( model.DNI);
                    
                    if (dni != null && !dni.Equals(""))
                    {
                        String url = "https://quertium.com/api/v1/reniec/dni/" + dni + "?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.MTM3NA.VXfwWGycEWoyGTtzUb3YSNI0688GiCIY6FTXETFEO_c";

                        WebClient wc = new WebClient();
                        var datos = wc.DownloadString(url);
                        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
                        var rs = JsonConvert.DeserializeObject<Root>(datos);
                        primero_nombre_temporal = Convert.ToString(rs.primerNombre);
                        segundo_nombre_temporal = Convert.ToString(rs.segundoNombre);
                        apellido_paterno_temporal = Convert.ToString(rs.apellidoPaterno);
                        apellido_materno_temporal = Convert.ToString(rs.apellidoMaterno);

                        dni_docente_temporal = dni;
                    }

                    //
                return RedirectToAction("AgregarEditar");

                case "Guardar Datos":
                    if (ModelState.IsValid)
                    {
                        model.Guardar();
                        return Redirect("~/Docente");
                    }

                    else
                    {
                        return View("~/View/Docente/AgregarEditar.cshtml", model);
                    }
                    ///
                    case "Limpiar Consulta":
                    primero_nombre_temporal = "";
                    segundo_nombre_temporal = "";
                    apellido_paterno_temporal = "";
                    apellido_materno_temporal = "";
                    dni_docente_temporal = "";

                    return RedirectToAction("AgregarEditar");
            }

            return View();
            
        }

        public ActionResult Eliminar(int id)
        {
            objDocente.ID_Docente = id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }

        //////////////////////////////////////////////////
        public static string primero_nombre_temporal = "";
        public static string segundo_nombre_temporal = "";
        public static string apellido_paterno_temporal = "";
        public static string apellido_materno_temporal = "";
        public static string dni_docente_temporal = "";
        //////////////////////////////////////////////////

        public ActionResult ReniecDocente(Docente model)
        {
            string dni = "73570928";

            if (dni != null && !dni.Equals(""))
            {
                String url = "https://quertium.com/api/v1/reniec/dni/" + dni + "?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.MTM3NA.VXfwWGycEWoyGTtzUb3YSNI0688GiCIY6FTXETFEO_c";

                WebClient wc = new WebClient();
                var datos = wc.DownloadString(url);
                // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
                var rs = JsonConvert.DeserializeObject<Root>(datos);

                primero_nombre_temporal = Convert.ToString(rs.primerNombre);
                ViewBag.segundo_nombre_temporal = Convert.ToString(rs.segundoNombre);
                ViewBag.apellido_paterno_temporal = Convert.ToString(rs.apellidoPaterno);
                ViewBag.apellido_materno_temporal = Convert.ToString(rs.apellidoMaterno);

            }
            return View();
        }
        //////////////////////////////////////////////////

    }
}