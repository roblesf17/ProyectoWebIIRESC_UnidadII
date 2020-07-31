using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIGEM_TAEX.Models;
using SIGEM_TAEX.Filters;


namespace SIGEM_TAEX.Controllers
{
    
    public class LoginController : Controller
    {

        private Usuario objUsuario = new Usuario();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Acceder(/*string usuario, string password*/)
        {
            //var rm = objUsuario.Acceder(usuario, password);
            //if (rm.response)
            //{
            //rm.href = Url.Content("~/Docente");

            return View("~/View/Docente/Index.cshtml");
            //}
            //return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}