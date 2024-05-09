using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using CapaEntidad;
using CapaNegocio;


namespace PruebaASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "hello world";

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }


        public JsonResult ListarUsuarios()
        {
            List<User> oLista = new List<User>();
            oLista = new CN_Users().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }









    }

}
