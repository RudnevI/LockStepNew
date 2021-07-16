using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain;
using LockStepNew.Models;

namespace LockStepNew
{
    public class BookAuthorRepository : GenericRepository<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(ApplicationDbContext context) : base(context) { }
    }
}
