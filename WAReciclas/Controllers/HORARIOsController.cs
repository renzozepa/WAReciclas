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
    public class HORARIOsController : ApiController
    {
        private Reciclas db = new Reciclas();

        // GET: api/HORARIOs
        public IQueryable<HORARIO> GetHORARIO()
        {
            return db.HORARIO;
        }

        // GET: api/HORARIOs/5
        [ResponseType(typeof(HORARIO))]
        public async Task<IHttpActionResult> GetHORARIO(int id)
        {
            HORARIO hORARIO = await db.HORARIO.FindAsync(id);
            if (hORARIO == null)
            {
                return NotFound();
            }

            return Ok(hORARIO);
        }

        // GET: api/HORARIO/15096
        [ResponseType(typeof(HORARIO))]
        public IQueryable<HORARIO_DISPONIBLE> GetHorarioDisponible(string zipcode)
        {
            var HorarioDisponible = db.Database.SqlQuery<HORARIO_DISPONIBLE>("LISTAR_UBIGEO_ZIPCODE @ZIPCODE = {0}", zipcode).ToList();
            IQueryable<HORARIO_DISPONIBLE> datalist = HorarioDisponible.AsQueryable<HORARIO_DISPONIBLE>();
            return datalist;
        }

        // GET: api/HORARIO/LUNES - 09:00 A 09:59
        [ResponseType(typeof(HORARIO))]
        public IQueryable<HORARIO_DISPONIBLE> GetIdHorarioDisponible(string descripcion)
        {
            var HorarioDisponible = db.Database.SqlQuery<HORARIO_DISPONIBLE>("GET_ID_HORARIO @DESCRIPCION = {0}", descripcion).ToList();
            IQueryable<HORARIO_DISPONIBLE> datalist = HorarioDisponible.AsQueryable<HORARIO_DISPONIBLE>();
            return datalist;
        }

        // PUT: api/HORARIOs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHORARIO(int id, HORARIO hORARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hORARIO.ID)
            {
                return BadRequest();
            }

            db.Entry(hORARIO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HORARIOExists(id))
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

        // POST: api/HORARIOs
        [ResponseType(typeof(HORARIO))]
        public async Task<IHttpActionResult> PostHORARIO(HORARIO hORARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HORARIO.Add(hORARIO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hORARIO.ID }, hORARIO);
        }

        // DELETE: api/HORARIOs/5
        [ResponseType(typeof(HORARIO))]
        public async Task<IHttpActionResult> DeleteHORARIO(int id)
        {
            HORARIO hORARIO = await db.HORARIO.FindAsync(id);
            if (hORARIO == null)
            {
                return NotFound();
            }

            db.HORARIO.Remove(hORARIO);
            await db.SaveChangesAsync();

            return Ok(hORARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HORARIOExists(int id)
        {
            return db.HORARIO.Count(e => e.ID == id) > 0;
        }
    }
}