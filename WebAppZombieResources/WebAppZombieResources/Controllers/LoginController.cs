using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppZombieResources.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Entrar()
        {
            return View();
        }
    }
}