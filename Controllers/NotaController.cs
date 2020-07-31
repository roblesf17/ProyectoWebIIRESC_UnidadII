using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;

namespace SIGEM_TAEX.Controllers
{
    public class NotaController : Controller
    {
        // GET: Nota
        private Nota objNota = new Nota();
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objNota.Listar());
            }
            else
            {
                return View(objNota.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objNota.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objNota.Listar()
                    : objNota.Buscar(Criterio)
                );
        }

        private Estudiante objEstudainte = new Estudiante();
        private Taller objTaller = new Taller();
        private Periodo objPeriodo = new Periodo();

        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objEstudainte.Listar();
            ViewBag.Docente1 = objTaller.Listar();
            ViewBag.Docente2 = objPeriodo.Listar();
            //  
            return View(
                id == 0 ? new Nota()
                        : objNota.Obtener(id)
            );
        }

        public ActionResult Guardar(Nota model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Nota");
            }

            else
            {
                return View("~/View/Nota/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objNota.ID_Nota = id;
            objNota.Eliminar();
            return Redirect("~/Nota");
        }

    }
}