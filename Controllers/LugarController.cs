using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;

namespace SIGEM_TAEX.Controllers
{
    public class LugarController : Controller
    {
        public Lugar objLugar = new Lugar();

        // GET: Lugar
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objLugar.Listar());
            }
            else
            {
                return View(objLugar.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objLugar.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objLugar.Listar()
                    : objLugar.Buscar(Criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objLugar.Listar();
            //  
            return View(
                id == 0 ? new Lugar()
                        : objLugar.Obtener(id)
            );
        }

        public ActionResult Guardar(Lugar model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Lugar");
            }

            else
            {
                return View("~/View/Lugar/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objLugar.ID_Lugar = id;
            objLugar.Eliminar();
            return Redirect("~/Lugar");
        }


    }
}