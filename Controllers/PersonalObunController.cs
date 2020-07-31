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
    public class PersonalObunController : Controller
    {
        public Personal_OBUN objPersonalOBUN = new Personal_OBUN();
        // GET: PersonalObun
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objPersonalOBUN.Listar());
            }
            else
            {
                return View(objPersonalOBUN.Buscar(Criterio));
            }
        }
        public ActionResult Ver(int id)
        {
            return View(objPersonalOBUN.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objPersonalOBUN.Listar()
                    : objPersonalOBUN.Buscar(Criterio)
                );
        }

        public ActionResult Agregar(int id = 0)
        {
            //
            ViewBag.Docente = objPersonalOBUN.Listar();
            //  
            return View(
                id == 0 ? new Personal_OBUN()
                        : objPersonalOBUN.Obtener(id)
            );
        }

        public ActionResult AgregarModificar(int id = 0)
        {
            //
            ViewBag.Docente = objPersonalOBUN.Listar();
            //  
            return View(
                id == 0 ? new Personal_OBUN()
                        : objPersonalOBUN.Obtener(id)
            );
        }
        //////////////////////////////////////////////////
        public static string primero_nombre_temporal = "";
        public static string segundo_nombre_temporal = "";
        public static string apellido_paterno_temporal = "";
        public static string apellido_materno_temporal = "";
        public static string dni_docente_temporal = "";
        //////////////////////////////////////////////////
        public ActionResult Guardar(Personal_OBUN model ,  string submitButton)
        {
            switch (submitButton)
            {
                case "Consultar en RENIEC":
                    string dni = Convert.ToString(model.DNI);
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
                    return RedirectToAction("Agregar");

                case "Guardar Datos":
                    if (ModelState.IsValid)
                    {
                        model.Guardar();
                        return Redirect("~/PersonalObun");
                    }

                    else
                    {
                        return View("~/View/PersonalObun/Agregar.cshtml", model);
                    }

            }

            return View();
        }

        public ActionResult Eliminar(int id)
        {
            objPersonalOBUN.ID_Personal = id;
            objPersonalOBUN.Eliminar();
            return Redirect("~/PersonalObun");
        }


    }
}