using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Aa.Models;
using Algoritmos;

namespace Aa.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult Autentica(string usuario, string password)
        {
            Mensaje mensaje = new Mensaje();

            if(usuario!=null && password != null && usuario.Trim().Length > 0 && password.Trim().Length > 0)
            {
                string password_encripted = Aes.Encrypt(password);

                DaoUsuarios daoUsuarios = new DaoUsuarios();
                usuarios user = daoUsuarios.Autentica(usuario, password_encripted);

                if(user != null)
                {
                    Session["user"] = user;
                    Session["ID"] = Session.SessionID;

                }
                else
                {
                    mensaje.msg = "Usuario NO Registrado";
                    mensaje.estado = false;
                }
            }
            else
            {
                mensaje.msg = "Debe ingresar Usuario y Password";
                mensaje.estado = false;
            }

            return Json(mensaje, JsonRequestBehavior.AllowGet);
        }

        private class Mensaje{
            public string msg { get; set; }
            public bool estado { get; set; }
        }

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
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}