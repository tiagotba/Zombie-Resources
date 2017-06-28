using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppZombieResources.ViewModels;

namespace WebAppZombieResources.Controllers
{
    public class InventarioController : Controller
    {
        private string UriText = "http://localhost:52675/api/Inventario";
        private List<InventarioIndexViewModel> viewModelList;
        // GET: Inventario
        public async Task<ActionResult>Index()
        {
            if (TempData["User"] != null)
            {
                TempData.Keep("User");
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(UriText))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ListInventario = await response.Content.ReadAsStringAsync();
                            viewModelList = JsonConvert.DeserializeObject<InventarioIndexViewModel[]>(ListInventario).ToList();
                        }
                    }

                }

                return View(viewModelList);
            }
            else
            {
                return RedirectToAction("Entrar", "Login");
            }
        }
    }
}