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
    public class PaymentsController : ApiController
    {
        // GET: Payment
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!PaymentsExist()) return NotFound();


                else return Ok(GetPayments());
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
                if (!PaymentsExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!PaymentExists(id)) return NotFound();


                else return Ok(await _context.Payments.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool PaymentExists(int id)
        {
            return !(_context.Payments.Find(id) is null);
        }

        private bool PaymentsExist()
        {
            return _context.Payments.Count() != 0;
        }

        private List<Payment> GetPayments()
        {

            return _context.Payments.ToList();
        }

        private int? GetMaxId()
        {
            return _context.Payments.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}