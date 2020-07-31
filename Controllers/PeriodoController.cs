using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;


namespace SIGEM_TAEX.Controllers
{
    public class PeriodoController : Controller
    {

        public Periodo objPeriodo = new Periodo();

        // GET: Periodo
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objPeriodo.Listar());
            }
            else
            {
                return View(objPeriodo.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objPeriodo.Obtener(id));
        }

        public ActionResult Buscar(string Criterio)
        {
            return View
                (
                Criterio == null || Criterio == "" ? objPeriodo.Listar()
                    : objPeriodo.Buscar(Criterio)
                );
        }

        public ActionResult AgregarEditar(int id = 0)
        {//
            ViewBag.Docente = objPeriodo.Listar();
            //  
            return View(
                id == 0 ? new Periodo()
                        : objPeriodo.Obtener(id)
            );
        }

        public ActionResult Guardar(Periodo model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Periodo");
            }

            else
            {
                return View("~/View/Periodo/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objPeriodo.ID_Periodo = id;
            objPeriodo.Eliminar();
            return Redirect("~/Periodo");
        }

    }
}