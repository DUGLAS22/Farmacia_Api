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
using FARMACIA_API.Models;

namespace FARMACIA_API.Controllers
{
    public class ProveedorsController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Proveedors
        public IQueryable<Proveedor> GetProveedor()
        {
            return db.Proveedor;
        }

        // GET: api/Proveedors/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult GetProveedor(int id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT: api/Proveedors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProveedor(int id, Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.Id)
            {
                return BadRequest();
            }

            db.Entry(proveedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedors
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult PostProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proveedor.Add(proveedor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proveedor.Id }, proveedor);
        }

        // DELETE: api/Proveedors/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult DeleteProveedor(int id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            db.Proveedor.Remove(proveedor);
            db.SaveChanges();

            return Ok(proveedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedorExists(int id)
        {
            return db.Proveedor.Count(e => e.Id == id) > 0;
        }
    }
}