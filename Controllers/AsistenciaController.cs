using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;

namespace SIGEM_TAEX.Controllers
{
    public class AsistenciaController : Controller
    {
        // GET: Asistencia
        private Asistencia objAsistencia = new Asistencia();
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objAsistencia.Listar());
            }
            else
            {
                return View(objAsistencia.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objAsistencia.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objAsistencia.Listar()
                    : objAsistencia.Buscar(Criterio)
                );
        }

        private Estudiante objEstudiante = new Estudiante();
        private Taller objTaller = new Taller();

        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objEstudiante.Listar();
            ViewBag.Docente1 = objTaller.Listar();
            //  
            return View(
                id == 0 ? new Asistencia()
                        : objAsistencia.Obtener(id)
            );
        }

        public ActionResult Guardar(Asistencia model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Asistencia");
            }

            else
            {
                return View("~/View/Asistencia/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objAsistencia.ID_Asistencia = id;
            objAsistencia.Eliminar();
            return Redirect("~/Asistencia");
        }
    }
}