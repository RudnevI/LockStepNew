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
    public class BookGenreController : ApiController
    {
        // GET: BookGenre
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!BookGenresExist()) return NotFound();


                else return Ok(GetBookGenres());
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
                if (!BookGenresExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!BookGenreExists(id)) return NotFound();


                else return Ok(await _context.BookGenres.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool BookGenreExists(int id)
        {
            return !(_context.BookGenres.Find(id) is null);
        }

        private bool BookGenresExist()
        {
            return _context.BookGenres.Count() != 0;
        }

        private List<BookGenre> GetBookGenres()
        {

            return _context.BookGenres.ToList();
        }

        private int? GetMaxId()
        {
            return _context.BookGenres.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}