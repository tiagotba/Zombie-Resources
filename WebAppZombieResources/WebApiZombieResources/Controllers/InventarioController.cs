using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiZombieResources.AcessoDados;

namespace WebApiZombieResources.Controllers
{
    public class InventarioController : ApiController
    {
        private readonly ZombieResourcesDbContext _db = new ZombieResourcesDbContext();

        public InventarioController()
        {

        }
        // GET: api/Inventario
        public IHttpActionResult Get()
        {
            var query = from i in _db.Inventario
                        join r in _db.Recursos on i.RecursoId equals r.Id
                        join s in _db.Sobreviventes on i.SobreviventeId equals s.Id
                        select new
                        {
                            r.Descricao,
                            s.Nome,
                            i.QtdRetirada,
                            r.Quantidade
                        };

            var result = query.ToList();

            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Inventario/5
        public string Get(int id)
        {
            return "value";
        }

    }
}
