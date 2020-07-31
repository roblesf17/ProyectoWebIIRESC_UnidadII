using SIGEM_TAEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGEM_TAEX.Controllers
{
    public class TallerController : Controller
    {
        // GET: Taller
        private Taller objTaller = new Taller();
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objTaller.Listar());
            }
            else
            {
                return View(objTaller.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objTaller.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objTaller.Listar()
                    : objTaller.Buscar(Criterio)
                );
        }

        private Docente objDocente = new Docente();
        private Lugar objLugar = new Lugar();
        private Horario objHorario = new Horario();
        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objDocente.Listar();
            ViewBag.Docente1 = objLugar.Listar();
            ViewBag.Docente2 = objHorario.Listar();
            //  
            return View(
                id == 0 ? new Taller()
                        : objTaller.Obtener(id)
            );
        }

        public ActionResult Guardar(Taller model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Taller");
            }

            else
            {
                return View("~/View/Taller/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objTaller.ID_Taller = id;
            objTaller.Eliminar();
            return Redirect("~/Taller");
        }

    }
}