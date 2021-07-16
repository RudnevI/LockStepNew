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
    public class AuthorsController : ApiController
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!AuthorsExist()) return NotFound();


                else return Ok(GetAuthors());
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
                if (!AuthorsExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!AuthorExists(id)) return NotFound();


                else return Ok(await _context.Authors.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool AuthorExists(int id)
        {
            return !(_context.Authors.Find(id) is null);
        }

        private bool AuthorsExist()
        {
            return _context.Authors.Count() != 0;
        }

        private List<Author> GetAuthors()
        {

            return _context.Authors.ToList();
        }

        private int? GetMaxId()
        {
            return _context.Authors.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}