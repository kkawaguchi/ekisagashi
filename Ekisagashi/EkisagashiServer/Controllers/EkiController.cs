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
    public class EkiController : ApiController
    {
        private EkisagashiContext db = new EkisagashiContext();

        // GET: api/Eki
        public IQueryable<Eki> GetEkis()
        {
            return db.Ekis;
        }

        // GET: api/Eki/5
        [ResponseType(typeof(Eki))]
        public async Task<IHttpActionResult> GetEki(int id)
        {
            Eki eki = await db.Ekis.FindAsync(id);
            if (eki == null)
            {
                return NotFound();
            }

            return Ok(eki);
        }

        // PUT: api/Eki/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEki(int id, Eki eki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eki.EkiId)
            {
                return BadRequest();
            }

            db.Entry(eki).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EkiExists(id))
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

        // POST: api/Eki
        [ResponseType(typeof(Eki))]
        public async Task<IHttpActionResult> PostEki(Eki eki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ekis.Add(eki);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eki.EkiId }, eki);
        }

        // DELETE: api/Eki/5
        [ResponseType(typeof(Eki))]
        public async Task<IHttpActionResult> DeleteEki(int id)
        {
            Eki eki = await db.Ekis.FindAsync(id);
            if (eki == null)
            {
                return NotFound();
            }

            db.Ekis.Remove(eki);
            await db.SaveChangesAsync();

            return Ok(eki);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EkiExists(int id)
        {
            return db.Ekis.Count(e => e.EkiId == id) > 0;
        }
    }
}