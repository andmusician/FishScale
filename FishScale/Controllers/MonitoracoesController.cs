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
    public class MonitoracoesController : ApiController
    {
        private DomoticEntities db = new DomoticEntities();

        public event EventHandler Event;

        // GET: api/Monitoracoes
        public IQueryable<Monitoracao> GetMonitoracao()
        {
            return db.Monitoracao;
        }

        // GET: api/Monitoracoes/5
        [ResponseType(typeof(Monitoracao))]
        public IHttpActionResult GetMonitoracao(int id)
        {
            Monitoracao monitoracao = db.Monitoracao.Find(id);
            if (monitoracao == null)
            {
                return NotFound();
            }

            return Ok(monitoracao);
        }

        // PUT: api/Monitoracoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitoracao(int id, Monitoracao monitoracao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitoracao.MonitoraID)
            {
                return BadRequest();
            }

            db.Entry(monitoracao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitoracaoExists(id))
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

        // POST: api/Monitoracoes
        [ResponseType(typeof(Monitoracao))]
        public IHttpActionResult PostMonitoracao(Monitoracao monitoracao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monitoracao.Add(monitoracao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monitoracao.MonitoraID }, monitoracao);
        }

        // DELETE: api/Monitoracoes/5
        [ResponseType(typeof(Monitoracao))]
        public IHttpActionResult DeleteMonitoracao(int id)
        {
            Monitoracao monitoracao = db.Monitoracao.Find(id);
            if (monitoracao == null)
            {
                return NotFound();
            }

            db.Monitoracao.Remove(monitoracao);
            db.SaveChanges();

            return Ok(monitoracao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonitoracaoExists(int id)
        {
            return db.Monitoracao.Count(e => e.MonitoraID == id) > 0;
        }
    }
}