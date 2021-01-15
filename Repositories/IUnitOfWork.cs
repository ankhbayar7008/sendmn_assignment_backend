using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
