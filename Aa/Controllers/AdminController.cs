using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aa.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            usuarios user = (usuarios)Session["user"];

            if(Session.SessionID.Equals(Session["ID"]) && user.autorizacion == "ADMIN")
            {
                return View();
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return Redirect("../Home/Index");
        }
    }
}