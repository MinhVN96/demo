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
    public class DetailImportWarehosesController : ApiController
    {
        private WareHouseDB db = new WareHouseDB();

        // GET: api/DetailImportWarehoses
        public IQueryable<DetailImportWarehose> GetDetailImportWarehoses()
        {
            return db.DetailImportWarehoses;
        }

        // GET: api/DetailImportWarehoses/5
        [ResponseType(typeof(DetailImportWarehose))]
        public IHttpActionResult GetDetailImportWarehose(long id)
        {
            DetailImportWarehose detailImportWarehose = db.DetailImportWarehoses.Find(id);
            if (detailImportWarehose == null)
            {
                return NotFound();
            }

            return Ok(detailImportWarehose);
        }

        // PUT: api/DetailImportWarehoses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetailImportWarehose(long id, DetailImportWarehose detailImportWarehose)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detailImportWarehose.ImportID)
            {
                return BadRequest();
            }

            db.Entry(detailImportWarehose).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailImportWarehoseExists(id))
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

        // POST: api/DetailImportWarehoses
        [ResponseType(typeof(DetailImportWarehose))]
        public IHttpActionResult PostDetailImportWarehose(DetailImportWarehose detailImportWarehose)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetailImportWarehoses.Add(detailImportWarehose);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DetailImportWarehoseExists(detailImportWarehose.ImportID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = detailImportWarehose.ImportID }, detailImportWarehose);
        }

        // DELETE: api/DetailImportWarehoses/5
        [ResponseType(typeof(DetailImportWarehose))]
        public IHttpActionResult DeleteDetailImportWarehose(long id)
        {
            DetailImportWarehose detailImportWarehose = db.DetailImportWarehoses.Find(id);
            if (detailImportWarehose == null)
            {
                return NotFound();
            }

            db.DetailImportWarehoses.Remove(detailImportWarehose);
            db.SaveChanges();

            return Ok(detailImportWarehose);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailImportWarehoseExists(long id)
        {
            return db.DetailImportWarehoses.Count(e => e.ImportID == id) > 0;
        }
    }
}