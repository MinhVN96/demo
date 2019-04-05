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
    public class CategoryProductsController : ApiController
    {
        private WareHouseDB db = new WareHouseDB();

        // GET: api/CategoryProducts
        public IQueryable<CategoryProduct> GetCategoryProducts()
        {
            return db.CategoryProducts;
        }

        // GET: api/CategoryProducts/5
        [ResponseType(typeof(CategoryProduct))]
        public IHttpActionResult GetCategoryProduct(long id)
        {
            CategoryProduct categoryProduct = db.CategoryProducts.Find(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            return Ok(categoryProduct);
        }

        // PUT: api/CategoryProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoryProduct(long id, CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryProduct.ID)
            {
                return BadRequest();
            }

            db.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProductExists(id))
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

        // POST: api/CategoryProducts
        [ResponseType(typeof(CategoryProduct))]
        public IHttpActionResult PostCategoryProduct(CategoryProduct categoryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryProducts.Add(categoryProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoryProduct.ID }, categoryProduct);
        }

        // DELETE: api/CategoryProducts/5
        [ResponseType(typeof(CategoryProduct))]
        public IHttpActionResult DeleteCategoryProduct(long id)
        {
            CategoryProduct categoryProduct = db.CategoryProducts.Find(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            db.CategoryProducts.Remove(categoryProduct);
            db.SaveChanges();

            return Ok(categoryProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryProductExists(long id)
        {
            return db.CategoryProducts.Count(e => e.ID == id) > 0;
        }
    }
}