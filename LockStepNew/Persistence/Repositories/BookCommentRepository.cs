using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain;
using LockStepNew.Models;

namespace LockStep.Library.Persistence.Repositories
{
    public class BookCommentRepository : GenericRepository<BookComment>, IBookCommentRepository
    {
        public BookCommentRepository(ApplicationDbContext context) : base(context) { }
    }
}
