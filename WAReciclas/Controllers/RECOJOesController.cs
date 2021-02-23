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
    public class RECOJOesController : ApiController
    {
        private Reciclas db = new Reciclas();

        // GET: api/RECOJOes
        public IQueryable<RECOJO> GetRECOJO()
        {
            return db.RECOJO;
        }

        // GET: api/RECOJOes/5
        [ResponseType(typeof(RECOJO))]
        public async Task<IHttpActionResult> GetRECOJO(int id)
        {
            RECOJO rECOJO = await db.RECOJO.FindAsync(id);
            if (rECOJO == null)
            {
                return NotFound();
            }

            return Ok(rECOJO);
        }

        // PUT: api/RECOJOes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRECOJO(int id, RECOJO rECOJO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rECOJO.ID)
            {
                return BadRequest();
            }

            db.Entry(rECOJO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RECOJOExists(id))
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

        // POST: api/RECOJOes
        [ResponseType(typeof(RECOJO))]
        public async Task<IHttpActionResult> PostRECOJO(RECOJO rECOJO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RECOJO.Add(rECOJO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rECOJO.ID }, rECOJO);
        }

        // DELETE: api/RECOJOes/5
        [ResponseType(typeof(RECOJO))]
        public async Task<IHttpActionResult> DeleteRECOJO(int id)
        {
            RECOJO rECOJO = await db.RECOJO.FindAsync(id);
            if (rECOJO == null)
            {
                return NotFound();
            }

            db.RECOJO.Remove(rECOJO);
            await db.SaveChangesAsync();

            return Ok(rECOJO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RECOJOExists(int id)
        {
            return db.RECOJO.Count(e => e.ID == id) > 0;
        }
    }
}