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
using FishScale.Models;

namespace FishScale.Controllers
{
    public class AlertasController : ApiController
    {
        private DomoticEntities db = new DomoticEntities();

        // GET: api/Alertas
        public IQueryable<Alerta> GetAlerta()
        {
            return db.Alerta;
        }

        // GET: api/Alertas/5
        [ResponseType(typeof(Alerta))]
        public IHttpActionResult GetAlerta(int id)
        {
            Alerta alerta = db.Alerta.Find(id);
            if (alerta == null)
            {
                return NotFound();
            }

            return Ok(alerta);
        }

        // PUT: api/Alertas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlerta(int id, Alerta alerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alerta.AlertaID)
            {
                return BadRequest();
            }

            db.Entry(alerta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertaExists(id))
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

        // POST: api/Alertas
        [ResponseType(typeof(Alerta))]
        public IHttpActionResult PostAlerta(Alerta alerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alerta.Add(alerta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alerta.AlertaID }, alerta);
        }

        // DELETE: api/Alertas/5
        [ResponseType(typeof(Alerta))]
        public IHttpActionResult DeleteAlerta(int id)
        {
            Alerta alerta = db.Alerta.Find(id);
            if (alerta == null)
            {
                return NotFound();
            }

            db.Alerta.Remove(alerta);
            db.SaveChanges();

            return Ok(alerta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlertaExists(int id)
        {
            return db.Alerta.Count(e => e.AlertaID == id) > 0;
        }
    }
}