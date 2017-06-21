using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiZombieResources.AcessoDados;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.Controllers
{
    public class SobreviventesController : ApiController
    {
        private readonly ZombieResourcesDbContext _db;

        public SobreviventesController()
        {
            if (_db == null)
            {
                _db = new ZombieResourcesDbContext();
            }
           
        }

       

        // GET: api/Sobreviventes
        public IQueryable<Sobrevivente> GetSobreviventes()
        {
            return _db.Sobreviventes;
        }

        // GET: api/Sobreviventes/5
        [ResponseType(typeof(Sobrevivente))]
        public IHttpActionResult GetSobreviventes(int id)
        {
            Sobrevivente sobreviventes = _db.Sobreviventes.Find(id);

            if (sobreviventes == null)
            {
                return NotFound();
            }

            return Ok(sobreviventes);
        }

        // GET: api/Sobreviventes/Hash
        //[ResponseType(typeof(string))]
        //public IHttpActionResult GetHash()
        //{
        //    Random randHash = new Random();
        //    string Hash = randHash.Next().ToString();

        //    if (Hash == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Hash);
        //}

        // POST: api/Sobreviventes
        [HttpPost]
        [ResponseType(typeof(Sobrevivente))]
        public IHttpActionResult PostSobreviventes(Sobrevivente sobreviventes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sobreviventes.HashSeguranca==null || sobreviventes.HashSeguranca.Equals(""))
            {
                Random randHash = new Random();
                sobreviventes.HashSeguranca = HashPassword(randHash.Next().ToString());
            }
            else
            {
                sobreviventes.HashSeguranca = HashPassword(sobreviventes.HashSeguranca);
            }
            _db.Sobreviventes.Add(sobreviventes);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sobreviventes.Id }, sobreviventes);
        }

        // PUT: api/Sobreviventes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSobreviventes(int id, Recursos recursos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recursos.Id)
            {
                return BadRequest();
            }

            _db.Entry(recursos).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SobreviventeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool SobreviventeExists(int id)
        {
            return _db.Sobreviventes.Count(e => e.Id == id) > 0;
        }

        // DELETE: api/Sobreviventes/5
        [ResponseType(typeof(Sobrevivente))]
        public IHttpActionResult DeleteSobreviventes(int id)
        {
            Sobrevivente sobreviventes = _db.Sobreviventes.Find(id);
            if (sobreviventes == null)
            {
                return NotFound();
            }

            _db.Sobreviventes.Remove(sobreviventes);
            _db.SaveChanges();

            return Ok(sobreviventes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}
