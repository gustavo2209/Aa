using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aa.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            usuarios user = (usuarios)Session["user"];

            if (Session.SessionID.Equals(Session["ID"]) && user.autorizacion == "CLIENT")
            {
                return View();
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }
    }
}