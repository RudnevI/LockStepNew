using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain;

namespace LockStep.Library.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
