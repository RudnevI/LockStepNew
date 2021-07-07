using LockStep.Library.Domain.Finance;
using LockStepNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;

namespace LockStepNew.Controllers.WebApi
{
    public class ChecksController : ApiController
    {
        // GET: Check
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IHttpActionResult Get()
        {

            try
            {
                if (!ChecksExist()) return NotFound();


                else return Ok(GetChecks());
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
                if (!ChecksExist()) return BadRequest();
                if (!IsValidId(id)) return BadRequest();
                if (!CheckExists(id)) return NotFound();


                else return Ok(await _context.Checks.FindAsync(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private bool CheckExists(int id)
        {
            return !(_context.Checks.Find(id) is null);
        }

        private bool ChecksExist()
        {
            return _context.Checks.Count() != 0;
        }

        private List<Check> GetChecks()
        {
            

            return _context.Checks.Include(c => c.Book).ToList();
        }

        private int? GetMaxId()
        {
            return _context.Checks.Count();
        }
        private bool IsValidId(int id)
        {
            return id > 0 && id <= GetMaxId();
        }



    }
}