using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppZombieResources.ViewModels;

namespace WebAppZombieResources.Controllers
{
    public class RecursosController : Controller
    {
        private string UriText = "http://localhost:52675/api/Sobreviventes";
        public SobreviventeViewModel sobreLogado;
        // GET: Recursos
        public async System.Threading.Tasks.Task<ActionResult> Index(int? hasSeguranca)
        {
            if (sobreLogado == null)
                sobreLogado = new SobreviventeViewModel();

            if (TempData["User"] != null)
            {
                TempData.Keep("User");
                sobreLogado = TempData["User"] as SobreviventeViewModel;
                return View();
            }
            else
            {
                UriText = UriText + "/?id=0&hashId=" + hasSeguranca.ToString();

                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(UriText);
                    if (response.IsSuccessStatusCode)
                    {
                        var SobreviventeLogado = await response.Content.ReadAsStringAsync();
                        sobreLogado = JsonConvert.DeserializeObject<SobreviventeViewModel>(SobreviventeLogado);
                    }
                }


                if (sobreLogado != null && sobreLogado.Id > 0)
                {
                    TempData["User"] = sobreLogado;
                    return View();
                }
                else
                {
                    return RedirectToAction("Entrar", "Login");
                }
            }
        }

        public ActionResult Edit()
        {
            if (TempData["User"] != null || sobreLogado != null && !sobreLogado.HashSeguranca.Equals(string.Empty))
            {
                TempData.Keep("User");
                sobreLogado = TempData["User"] as SobreviventeViewModel;
                return View(sobreLogado);
            }
            else
            {
                return RedirectToAction("Entrar", "Login");
            }

        }


        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Retirar()
        {
            return View();
        }

        public ActionResult Create()
        {
            if (TempData["User"] != null || sobreLogado != null && !sobreLogado.HashSeguranca.Equals(string.Empty))
            {
                TempData.Keep("User");
                sobreLogado = TempData["User"] as SobreviventeViewModel;
                return View();
            }
            else
            {
                return RedirectToAction("Entrar", "Login");
            }

        }

    }
}