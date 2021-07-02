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
    public class BooksController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!BooksExist()) return NotFound();


                else return Ok(GetBooks());
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
                if (!BooksExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!BookExists(id)) return NotFound();


                else return Ok(await _context.Books.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool BookExists(int id)
        {
            return !(_context.Books.Find(id) is null);
        }

        private bool BooksExist()
        {
            return _context.Books.Count() != 0;
        }

        private List<Book> GetBooks()
        {

            return _context.Books.ToList();
        }

        private int? GetMaxId()
        {
            return _context.Books.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}
