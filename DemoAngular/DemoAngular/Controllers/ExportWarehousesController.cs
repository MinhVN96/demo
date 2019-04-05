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
    public class ExportWarehousesController : ApiController
    {
        private WareHouseDB db = new WareHouseDB();

        // GET: api/ExportWarehouses
        public IQueryable<ExportWarehouse> GetExportWarehouses()
        {
            return db.ExportWarehouses;
        }

        // GET: api/ExportWarehouses/5
        [ResponseType(typeof(ExportWarehouse))]
        public IHttpActionResult GetExportWarehouse(long id)
        {
            ExportWarehouse exportWarehouse = db.ExportWarehouses.Find(id);
            if (exportWarehouse == null)
            {
                return NotFound();
            }

            return Ok(exportWarehouse);
        }

        // PUT: api/ExportWarehouses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExportWarehouse(long id, ExportWarehouse exportWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exportWarehouse.ID)
            {
                return BadRequest();
            }

            db.Entry(exportWarehouse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExportWarehouseExists(id))
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

        // POST: api/ExportWarehouses
        [ResponseType(typeof(ExportWarehouse))]
        public IHttpActionResult PostExportWarehouse(ExportWarehouse exportWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExportWarehouses.Add(exportWarehouse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exportWarehouse.ID }, exportWarehouse);
        }

        // DELETE: api/ExportWarehouses/5
        [ResponseType(typeof(ExportWarehouse))]
        public IHttpActionResult DeleteExportWarehouse(long id)
        {
            ExportWarehouse exportWarehouse = db.ExportWarehouses.Find(id);
            if (exportWarehouse == null)
            {
                return NotFound();
            }

            db.ExportWarehouses.Remove(exportWarehouse);
            db.SaveChanges();

            return Ok(exportWarehouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExportWarehouseExists(long id)
        {
            return db.ExportWarehouses.Count(e => e.ID == id) > 0;
        }
    }
}