using SIGEM_TAEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGEM_TAEX.Controllers
{
    public class MatriculaController : Controller
    {
        // GET: Matricula
        private Matricula objMatricula = new Matricula();
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objMatricula.Listar());
            }
            else
            {
                return View(objMatricula.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objMatricula.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objMatricula.Listar()
                    : objMatricula.Buscar(Criterio)
                );
        }

        private Estudiante objDocente = new Estudiante();
        private Taller objLugar = new Taller();
        private Periodo objHorario = new Periodo();
        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objDocente.Listar();
            ViewBag.Docente1 = objLugar.Listar();
            ViewBag.Docente2 = objHorario.Listar();
            //  
            return View(
                id == 0 ? new Matricula()
                        : objMatricula.Obtener(id)
            );
        }

        public ActionResult Guardar(Matricula model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Matricula");
            }

            else
            {
                return View("~/View/Matricula/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objMatricula.ID_Matricula = id;
            objMatricula.Eliminar();
            return Redirect("~/Taller");
        }

    }
}