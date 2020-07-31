using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;

namespace SIGEM_TAEX.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private Usuario objUsuario = new Usuario();
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(objUsuario.Listar());
            }
            else
            {
                return View(objUsuario.Buscar(Criterio));
            }
        }

        public ActionResult Ver(int id)
        {
            return View(objUsuario.Obtener(id));
        }


        private Personal_OBUN objPersonalOBUN = new Personal_OBUN();
        private Docente objDocente = new Docente();
        private Estudiante objEstudiante = new Estudiante();
        public ActionResult AgregarEditar(int id = 0)
        {
            //
            ViewBag.Docente = objPersonalOBUN.Listar();
            ViewBag.Docente1 = objDocente.Listar();
            ViewBag.Docente2 = objEstudiante.Listar();
            //  
            return View(
                id == 0 ? new Usuario()
                        : objUsuario.Obtener(id)
            );
        }

        public ActionResult Guardar(Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Usuario");
            }

            else
            {
                return View("~/View/Usuario/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objUsuario.ID_Usuario = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario");
        }


    }
}