﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebAppZombieResources.ViewModels;

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