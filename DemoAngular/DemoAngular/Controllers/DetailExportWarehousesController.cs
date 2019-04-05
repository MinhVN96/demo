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
    public class DetailExportWarehousesController : ApiController
    {
        private WareHouseDB db = new WareHouseDB();

        // GET: api/DetailExportWarehouses
        public IQueryable<DetailExportWarehouse> GetDetailExportWarehouses()
        {
            return db.DetailExportWarehouses;
        }

        // GET: api/DetailExportWarehouses/5
        [ResponseType(typeof(DetailExportWarehouse))]
        public IHttpActionResult GetDetailExportWarehouse(long id)
        {
            DetailExportWarehouse detailExportWarehouse = db.DetailExportWarehouses.Find(id);
            if (detailExportWarehouse == null)
            {
                return NotFound();
            }

            return Ok(detailExportWarehouse);
        }

        // PUT: api/DetailExportWarehouses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetailExportWarehouse(long id, DetailExportWarehouse detailExportWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detailExportWarehouse.ExportID)
            {
                return BadRequest();
            }

            db.Entry(detailExportWarehouse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExportWarehouseExists(id))
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

        // POST: api/DetailExportWarehouses
        [ResponseType(typeof(DetailExportWarehouse))]
        public IHttpActionResult PostDetailExportWarehouse(DetailExportWarehouse detailExportWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetailExportWarehouses.Add(detailExportWarehouse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DetailExportWarehouseExists(detailExportWarehouse.ExportID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = detailExportWarehouse.ExportID }, detailExportWarehouse);
        }

        // DELETE: api/DetailExportWarehouses/5
        [ResponseType(typeof(DetailExportWarehouse))]
        public IHttpActionResult DeleteDetailExportWarehouse(long id)
        {
            DetailExportWarehouse detailExportWarehouse = db.DetailExportWarehouses.Find(id);
            if (detailExportWarehouse == null)
            {
                return NotFound();
            }

            db.DetailExportWarehouses.Remove(detailExportWarehouse);
            db.SaveChanges();

            return Ok(detailExportWarehouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailExportWarehouseExists(long id)
        {
            return db.DetailExportWarehouses.Count(e => e.ExportID == id) > 0;
        }
    }
}