using LockStep.Library.Domain;
using LockStepNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LockStepNew.Controllers.WebApi
{

    public class ProductsController : ApiController
    {
        // GET: Product
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!ProductsExist()) return NotFound();


                else return Ok(GetProducts());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                if (!ProductsExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!ProductExists(id)) return NotFound();


                else return Ok(await _context.Products.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool ProductExists(int id)
        {
            return !(_context.Products.Find(id) is null);
        }

        private bool ProductsExist()
        {
            return _context.Products.Count() != 0;
        }

        private List<Product> GetProducts()
        {

            return _context.Products.ToList();
        }

        private int? GetMaxId()
        {
            return _context.Products.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}