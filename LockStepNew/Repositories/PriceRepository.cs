using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain.Finance;
using LockStepNew.Models;

namespace LockStepNew
{
    public class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(ApplicationDbContext context) : base(context) { }
    }
}
