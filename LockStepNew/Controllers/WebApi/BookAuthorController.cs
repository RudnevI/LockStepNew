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
    public class BookAuthorController : ApiController
    {
        // GET: BookAuthor
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!BookAuthorsExist()) return NotFound();


                else return Ok(GetBookAuthors());
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
                if (!BookAuthorsExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!BookAuthorExists(id)) return NotFound();


                else return Ok(await _context.BookAuthors.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool BookAuthorExists(int id)
        {
            return !(_context.BookAuthors.Find(id) is null);
        }

        private bool BookAuthorsExist()
        {
            return _context.BookAuthors.Count() != 0;
        }

        private List<BookAuthor> GetBookAuthors()
        {

            return _context.BookAuthors.ToList();
        }

        private int? GetMaxId()
        {
            return _context.BookAuthors.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}
