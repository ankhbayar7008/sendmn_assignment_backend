using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();

        Task AddAsync(Employee employee);

        Task<Employee> FindByIdAsync(int id);
        void Update(Employee employee);
        void Remove(Employee employee);

    }
}
