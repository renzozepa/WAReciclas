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
    public class USUARIOsController : ApiController
    {
        private Reciclas db = new Reciclas();

        // GET: api/USUARIOs
        public IQueryable<USUARIO> GetUSUARIO()
        {
            return db.USUARIO;
        }

        // GET: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public async Task<IHttpActionResult> GetUSUARIO(int id)
        {
            USUARIO uSUARIO = await db.USUARIO.FindAsync(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            return Ok(uSUARIO);
        }

        // GET: api/GetUSUARIOxTOKEN/xxx-xxxxxx-xxxxx-xxxx
        [ResponseType(typeof(USUARIO))]
        public IQueryable<USUARIO> GetUSUARIOxTOKEN(string token)
        {
            var Usu = db.Database.SqlQuery<USUARIO>("SELECT [ID],[NOMBRE],[USUARIO] AS USUARIO1,[CLAVE],[DIRECCION],[LATITUD],[LONGITUD],[ID_PERFIL],[TOKEN],ISNULL([FECHA_REGISTRO], GETDATE()) AS[FECHA_REGISTRO],[ALTA],ISNULL(FECHA_ALTA, GETDATE()) AS[FECHA_ALTA],[CELULAR],ZIPCODE FROM USUARIO WHERE TOKEN = {0}", token).ToList();
            IQueryable<USUARIO> datalist = Usu.AsQueryable<USUARIO>();
            return datalist;
        }

        // PUT: api/USUARIOs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUSUARIO(int id, USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSUARIO.ID)
            {
                return BadRequest();
            }

            db.Entry(uSUARIO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOExists(id))
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

        // POST: api/USUARIOs
        [ResponseType(typeof(USUARIO))]
        public async Task<IHttpActionResult> PostUSUARIO(USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USUARIO.Add(uSUARIO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = uSUARIO.ID }, uSUARIO);
        }

        // DELETE: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public async Task<IHttpActionResult> DeleteUSUARIO(int id)
        {
            USUARIO uSUARIO = await db.USUARIO.FindAsync(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            db.USUARIO.Remove(uSUARIO);
            await db.SaveChangesAsync();

            return Ok(uSUARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USUARIOExists(int id)
        {
            return db.USUARIO.Count(e => e.ID == id) > 0;
        }
    }
}