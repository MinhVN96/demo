using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DemoAngular.Models;

namespace DemoAngular.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ImportWarehousesController : ApiController
    {
        private WareHouseDB db = new WareHouseDB();

        // GET: api/ImportWarehouses
        public IQueryable<ImportWarehouse> GetImportWarehouses()
        {
            return db.ImportWarehouses;
        }

        // GET: api/ImportWarehouses/5
        [ResponseType(typeof(ImportWarehouse))]
        public IHttpActionResult GetImportWarehouse(long id)
        {
            ImportWarehouse importWarehouse = db.ImportWarehouses.Find(id);
            if (importWarehouse == null)
            {
                return NotFound();
            }

            return Ok(importWarehouse);
        }

        // PUT: api/ImportWarehouses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImportWarehouse(long id, ImportWarehouse importWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != importWarehouse.ID)
            {
                return BadRequest();
            }

            db.Entry(importWarehouse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportWarehouseExists(id))
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

        // POST: api/ImportWarehouses
        [ResponseType(typeof(ImportWarehouse))]
        public IHttpActionResult PostImportWarehouse(ImportWarehouse importWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImportWarehouses.Add(importWarehouse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = importWarehouse.ID }, importWarehouse);
        }

        // DELETE: api/ImportWarehouses/5
        [ResponseType(typeof(ImportWarehouse))]
        public IHttpActionResult DeleteImportWarehouse(long id)
        {
            ImportWarehouse importWarehouse = db.ImportWarehouses.Find(id);
            if (importWarehouse == null)
            {
                return NotFound();
            }

            db.ImportWarehouses.Remove(importWarehouse);
            db.SaveChanges();

            return Ok(importWarehouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImportWarehouseExists(long id)
        {
            return db.ImportWarehouses.Count(e => e.ID == id) > 0;
        }
    }
}