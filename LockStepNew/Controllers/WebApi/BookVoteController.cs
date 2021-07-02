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
    public class BookVoteController : ApiController
    {
        // GET: BookVote
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!BookVotesExist()) return NotFound();


                else return Ok(GetBookVotes());
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
                if (!BookVotesExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!BookVoteExists(id)) return NotFound();


                else return Ok(await _context.BookVotes.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool BookVoteExists(int id)
        {
            return !(_context.BookVotes.Find(id) is null);
        }

        private bool BookVotesExist()
        {
            return _context.BookVotes.Count() != 0;
        }

        private List<BookVote> GetBookVotes()
        {

            return _context.BookVotes.ToList();
        }

        private int? GetMaxId()
        {
            return _context.BookVotes.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}