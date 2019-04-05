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
    public class WarehousesController : ApiController
    {
        private WareHouseDB db = new WareHouseDB();

        // GET: api/Warehouses
        public IQueryable<Warehouse> GetWarehouses()
        {
            return db.Warehouses;
        }

        // GET: api/Warehouses/5
        [ResponseType(typeof(Warehouse))]
        public IHttpActionResult GetWarehouse(long id)
        {
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        // PUT: api/Warehouses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWarehouse(long id, Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != warehouse.ID)
            {
                return BadRequest();
            }

            db.Entry(warehouse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(id))
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

        // POST: api/Warehouses
        [ResponseType(typeof(Warehouse))]
        public IHttpActionResult PostWarehouse(Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Warehouses.Add(warehouse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = warehouse.ID }, warehouse);
        }

        // DELETE: api/Warehouses/5
        [ResponseType(typeof(Warehouse))]
        public IHttpActionResult DeleteWarehouse(long id)
        {
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            db.Warehouses.Remove(warehouse);
            db.SaveChanges();

            return Ok(warehouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WarehouseExists(long id)
        {
            return db.Warehouses.Count(e => e.ID == id) > 0;
        }
    }
}