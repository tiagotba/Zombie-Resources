using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiZombieResources.AcessoDados;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.Controllers
{
  
    public class RecursosController : ApiController
    {
        private readonly ZombieResourcesDbContext _db = new ZombieResourcesDbContext();

        public RecursosController()
        {

        }

        public RecursosController(ZombieResourcesDbContext db)
        {
            _db = db;
        }

        // GET: api/Recursos
        public IQueryable<Recursos> GetRecursos()
        {
            return _db.Recursos;
        }

        // GET: api/Recursos/5
      
        public IHttpActionResult GetRecursos(int? id)
        {
            Recursos recursos = _db.Recursos.Find(id);

            if (recursos == null)
            {
                return NotFound();
            }

            return Ok(recursos);
        }

        // POST: api/Recursos
        //[ResponseType(typeof(string))]
        
        [HttpPost]
        public  HttpResponseMessage PostRecursos([FromBody] object rec)
        {
            if (!ModelState.IsValid)
            {
                 return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, " Recurso não encontado");
            }

            Recursos recursos = JsonConvert.DeserializeObject<Recursos>(Convert.ToString(rec));
            _db.Recursos.Add(recursos);
            _db.SaveChanges();

            return Request.CreateResponse<Recursos>(HttpStatusCode.OK, recursos);
        }

        // PUT: api/Recursos/5
        [HttpPut]
        public HttpResponseMessage PutRecursos(int id, [FromBody] object rec,int idUser,int qtd)
        {
            Recursos newRecurso;

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, " Recurso não implementado");
            }

            Recursos recurso = _db.Recursos.SingleOrDefault( r=>r.Id == id);
            Sobrevivente sobrevivente = _db.Sobreviventes.SingleOrDefault(r => r.Id == idUser);
           
            if (recurso == null || sobrevivente == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Dados não encontrados");
            }

            newRecurso = JsonConvert.DeserializeObject<Recursos>(Convert.ToString(rec));
           
            if (recurso.Quantidade == newRecurso.Quantidade)
            {
                recurso.Observacao = newRecurso.Observacao;
                recurso.Quantidade = newRecurso.Quantidade;
                recurso.Descricao = newRecurso.Descricao;
            }
            else
            {
                recurso.Observacao = newRecurso.Observacao;
                recurso.Quantidade = newRecurso.Quantidade;
                recurso.Descricao = newRecurso.Descricao;

                Inventario inv = new Inventario();
                inv.RecursoId = recurso.Id;
                inv.SobreviventeId = sobrevivente.Id;
                inv.QtdRetirada = qtd;
                _db.Inventario.Add(inv);
            }

            _db.Entry(recurso).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return Request.CreateResponse<Recursos>(HttpStatusCode.OK, recurso);
        }

        private bool RecursosExists(int id)
        {
            return _db.Recursos.Count(e => e.Id == id) > 0;
        }

        // DELETE: api/Recursos/5
        [ResponseType(typeof(Recursos))]
        [HttpDelete]
        public IHttpActionResult DeleteRecursos(int id)
        {
            Recursos recursos = _db.Recursos.Find(id);
            if (recursos == null)
            {
                return NotFound();
            }

            _db.Recursos.Remove(recursos);
            _db.SaveChanges();

            return Ok(recursos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
