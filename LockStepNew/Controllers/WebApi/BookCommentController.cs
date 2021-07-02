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
    public class BookCommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!BookCommentsExist()) return NotFound();


                else return Ok(GetBookComments());
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
                if (!BookCommentsExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!BookCommentExists(id)) return NotFound();


                else return Ok(await _context.BookComments.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool BookCommentExists(int id)
        {
            return !(_context.BookComments.Find(id) is null);
        }

        private bool BookCommentsExist()
        {
            return _context.BookComments.Count() != 0;
        }

        private List<BookComment> GetBookComments()
        {

            return _context.BookComments.ToList();
        }

        private int? GetMaxId()
        {
            return _context.BookComments.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}