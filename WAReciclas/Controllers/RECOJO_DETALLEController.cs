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
using WAReciclas.Models;

namespace WAReciclas.Controllers
{
    public class RECOJO_DETALLEController : ApiController
    {
        private Reciclas db = new Reciclas();

        // GET: api/RECOJO_DETALLE
        public IQueryable<RECOJO_DETALLE> GetRECOJO_DETALLE()
        {
            return db.RECOJO_DETALLE;
        }

        // GET: api/RECOJO_DETALLE/5
        [ResponseType(typeof(RECOJO_DETALLE))]
        public async Task<IHttpActionResult> GetRECOJO_DETALLE(string id)
        {
            RECOJO_DETALLE rECOJO_DETALLE = await db.RECOJO_DETALLE.FindAsync(id);
            if (rECOJO_DETALLE == null)
            {
                return NotFound();
            }

            return Ok(rECOJO_DETALLE);
        }

        // PUT: api/RECOJO_DETALLE/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRECOJO_DETALLE(string id, RECOJO_DETALLE rECOJO_DETALLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rECOJO_DETALLE.TOKEN_RECOJO_DETALLE)
            {
                return BadRequest();
            }

            db.Entry(rECOJO_DETALLE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RECOJO_DETALLEExists(id))
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

        // POST: api/RECOJO_DETALLE
        [ResponseType(typeof(RECOJO_DETALLE))]
        public async Task<IHttpActionResult> PostRECOJO_DETALLE(RECOJO_DETALLE rECOJO_DETALLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RECOJO_DETALLE.Add(rECOJO_DETALLE);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RECOJO_DETALLEExists(rECOJO_DETALLE.TOKEN_RECOJO_DETALLE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rECOJO_DETALLE.TOKEN_RECOJO_DETALLE }, rECOJO_DETALLE);
        }

        // DELETE: api/RECOJO_DETALLE/5
        [ResponseType(typeof(RECOJO_DETALLE))]
        public async Task<IHttpActionResult> DeleteRECOJO_DETALLE(string id)
        {
            RECOJO_DETALLE rECOJO_DETALLE = await db.RECOJO_DETALLE.FindAsync(id);
            if (rECOJO_DETALLE == null)
            {
                return NotFound();
            }

            db.RECOJO_DETALLE.Remove(rECOJO_DETALLE);
            await db.SaveChangesAsync();

            return Ok(rECOJO_DETALLE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RECOJO_DETALLEExists(string id)
        {
            return db.RECOJO_DETALLE.Count(e => e.TOKEN_RECOJO_DETALLE == id) > 0;
        }
    }
}