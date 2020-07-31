using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;

namespace SIGEM_TAEX.Controllers
{

    public class EscuelaProfesionalController : Controller
    {

        public Escuela_Profesional objEscuela = new Escuela_Profesional();

        // GET: EscuelaProfesional
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objEscuela.Listar());
            }
            else
            {
                return View(objEscuela.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objEscuela.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objEscuela.Listar()
                    : objEscuela.Buscar(Criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objEscuela.Listar();
            //  
            return View(
                id == 0 ? new Escuela_Profesional()
                        : objEscuela.Obtener(id)
            );
        }

        public ActionResult Guardar(Escuela_Profesional model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/EscuelaProfesional");
            }

            else
            {
                return View("~/View/EscuelaProfesional/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objEscuela.ID_Escuela = id;
            objEscuela.Eliminar();
            return Redirect("~/EscuelaProfesional");
        }



    }
}