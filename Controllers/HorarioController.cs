using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;

namespace SIGEM_TAEX.Controllers
{
    public class HorarioController : Controller
    {

        public Horario objHorario = new Horario();

        // GET: Horario
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objHorario.Listar());
            }
            else
            {
                return View(objHorario.Buscar(Criterio));
            }
        }


        public ActionResult Ver(int id)
        {
            return View(objHorario.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objHorario.Listar()
                    : objHorario.Buscar(Criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objHorario.Listar();
            //  
            return View(
                id == 0 ? new Horario()
                        : objHorario.Obtener(id)
            );
        }

        public ActionResult Guardar(Horario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Horario");
            }

            else
            {
                return View("~/View/Horario/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objHorario.ID_Horario = id;
            objHorario.Eliminar();
            return Redirect("~/Horario");
        }


    }
}