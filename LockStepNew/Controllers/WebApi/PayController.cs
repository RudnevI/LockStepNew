using LockStep.Library.Domain;
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
    public class PayController : ApiController
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();
      

    

        public async Task<IHttpActionResult> Get(int id, double sum, string email)
        {
            if (!IsValidId(id) || !(await BookExists(id))) return NotFound();
            if (!IsValidsum(sum)) return BadRequest();

            Book book = await GetBook(id);
            Check check = new Check() {Book=book, Email=email};
            Payment payment = new Payment() { Book = book, Email = email, Amount = (decimal)sum };

            AddCheck(check);
            AddPayment(payment);

            return Ok();



        }


        private void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        private void AddCheck(Check check)
        {
             _context.Checks.Add(check);
            _context.SaveChanges();
        }

        private async Task<bool> BookExists(int id)
        {
            return await GetBook(id) != null;
        }

        private async Task<Book> GetBook(int id)
        {
            try
            {
                return await _context.Books.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        private int? GetMaxId()
        {
            return _context.Books.Select(b => b.Id).Max();
        }

        private bool IsValidId(int id)
        {
            int? maxId = GetMaxId();
            //TODO: Рассмотреть вариант с maxId равным null
            return !(id <= 0 || id > maxId);
        }

       private bool IsValidsum(double sum)
        {

            return sum >= 0;
        }
    }
}