using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TachesController : ApiController
    {
        private TodoDbContext db = new TodoDbContext();

        // GET: api/Taches
        public IQueryable<Tache> GetTaches()
        {
            return db.Taches;
        }

        // GET: api/Taches/5
        [ResponseType(typeof(Tache))]
        public IHttpActionResult GetTache(int id)
        {
            Tache tache = db.Taches.Find(id);
            if (tache == null)
            {
                return NotFound();
            }

            return Ok(tache);
        }

        // PUT: api/Taches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTache(int id, Tache tache)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tache.ID)
            {
                return BadRequest();
            }

            db.Entry(tache).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacheExists(id))
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

        // POST: api/Taches
        [ResponseType(typeof(Tache))]
        public IHttpActionResult PostTache(Tache tache)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Taches.Add(tache);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tache.ID }, tache);
        }

        // DELETE: api/Taches/5
        [ResponseType(typeof(Tache))]
        public IHttpActionResult DeleteTache(int id)
        {
            Tache tache = db.Taches.Find(id);
            if (tache == null)
            {
                return NotFound();
            }

            db.Taches.Remove(tache);
            db.SaveChanges();

            return Ok(tache);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TacheExists(int id)
        {
            return db.Taches.Count(e => e.ID == id) > 0;
        }
    }
}