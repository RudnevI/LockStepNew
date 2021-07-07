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
      

    

        public async Task<IHttpActionResult> Get(int bookId, string paymentId, double sum, string email)
        {
          
            if (!IsValidsum(sum)) return BadRequest();

            Book book = await GetBook(bookId);
            if (book is null) return BadRequest("Книга не найдена");

            Check check = new Check() {Book=book, Email=email, IdRequest = paymentId};
            Payment payment = new Payment() { Book = book, Email = email, Amount = (decimal)sum, IdRequest = paymentId };

            AddCheck(check);
            AddPayment(payment);

            return Ok(new {product = book.Name, Price = payment.Amount});



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

    

        private async Task<Book> GetBook(int id)
        {
           
                return await _context.Books.FindAsync(id);
            
           
        }

        private int? GetMaxId()
        {

            return _context.Books.Select(b => b.Id).Max();
        }

  

       private bool IsValidsum(double sum)
        {

            return sum >= 0;
        }
    }
}