using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EkisagashiServer.Models;

namespace EkisagashiServer.Controllers
{
    public class RosenController : ApiController
    {
        private EkisagashiContext db = new EkisagashiContext();

        // GET: api/Rosen
        public IQueryable<Rosen> GetRosens()
        {
            return db.Rosens;
        }

        // GET: api/Rosen/5
        [ResponseType(typeof(Rosen))]
        public async Task<IHttpActionResult> GetRosen(int id)
        {
            Rosen rosen = await db.Rosens.FindAsync(id);
            if (rosen == null)
            {
                return NotFound();
            }

            return Ok(rosen);
        }

        // PUT: api/Rosen/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRosen(int id, Rosen rosen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rosen.RosenId)
            {
                return BadRequest();
            }

            db.Entry(rosen).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RosenExists(id))
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

        // POST: api/Rosen
        [ResponseType(typeof(Rosen))]
        public async Task<IHttpActionResult> PostRosen(Rosen rosen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rosens.Add(rosen);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rosen.RosenId }, rosen);
        }

        // DELETE: api/Rosen/5
        [ResponseType(typeof(Rosen))]
        public async Task<IHttpActionResult> DeleteRosen(int id)
        {
            Rosen rosen = await db.Rosens.FindAsync(id);
            if (rosen == null)
            {
                return NotFound();
            }

            db.Rosens.Remove(rosen);
            await db.SaveChangesAsync();

            return Ok(rosen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RosenExists(int id)
        {
            return db.Rosens.Count(e => e.RosenId == id) > 0;
        }
    }
}