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
using log4net;
using PM.WebAPI.Models;


namespace PM.WebAPI.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProductsController));
        // GET: api/Products
        public IEnumerable<Product> GetProducts()
        {

            try
            {
                return db.Products.Include(p => p.Category).ToList();
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);
                return new List<Product>();
            }

        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            try
            {

                Product product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);
                return InternalServerError();
            }

        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Log.Error(ex.Message, ex);

                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5yfd
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            try
            {

                db.Products.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}