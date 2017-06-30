using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppZombieResources.ViewModels;

namespace WebAppZombieResources.Controllers
{
    public class LoginController : Controller
    {
        private string UriText = "http://localhost:52675/api/Sobreviventes";
        // GET: Login
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Entrar(SobreviventeViewModel model, string returnUrl)
        {
            SobreviventeViewModel user = null;

            using (var cliente = new HttpClient())
            {
                UriText = UriText + "/?hashId=" + model.HashSeguranca;

                HttpResponseMessage response = await cliente.GetAsync(UriText);
                if (response.IsSuccessStatusCode)
                {
                    var userJson = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<List<SobreviventeViewModel>>(userJson).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(user.Nome.ToString(), true);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Recursos");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The or hash provided is incorrect.");
                    return RedirectToAction("Entrar", "Login");
                }
            }

            //return View(user);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}