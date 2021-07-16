using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain;
using LockStepNew.Models;

namespace LockStepNew
{
    public class BookGenreRepository : GenericRepository<BookGenre>, IBookGenreRepository
    {
        public BookGenreRepository(ApplicationDbContext context) : base(context) { }
    }
}
