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
    public class GenresController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!GenresExist()) return NotFound();


                else return Ok(GetGenres());
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
                if (!GenresExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!GenreExists(id)) return NotFound();


                else return Ok(await _context.Genres.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool GenreExists(int id)
        {
            return !(_context.Genres.Find(id) is null);
        }

        private bool GenresExist()
        {
            return _context.Genres.Count() != 0;
        }

        private List<Genre> GetGenres()
        {

            return _context.Genres.ToList();
        }

        private int? GetMaxId()
        {
            return _context.Genres.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}
