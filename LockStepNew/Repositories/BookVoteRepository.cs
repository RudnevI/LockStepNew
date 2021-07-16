using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain;
using LockStepNew.Models;

namespace LockStepNew
{
    public class BookVoteRepository : GenericRepository<BookVote>, IBookVoteRepository
    {
        public BookVoteRepository(ApplicationDbContext context) : base(context) { }
    }
}
