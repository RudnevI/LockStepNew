using LockStep.Library.Domain.Finance;
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
    public class PricesController : ApiController
    {
        // GET: Price
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!PricesExist()) return NotFound();


                else return Ok(GetPrices());
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
                if (!PricesExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!PriceExists(id)) return NotFound();


                else return Ok(await _context.Prices.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool PriceExists(int id)
        {
            return !(_context.Prices.Find(id) is null);
        }

        private bool PricesExist()
        {
            return _context.Prices.Count() != 0;
        }

        private List<Price> GetPrices()
        {

            return _context.Prices.ToList();
        }

        private int? GetMaxId()
        {
            return _context.Prices.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}