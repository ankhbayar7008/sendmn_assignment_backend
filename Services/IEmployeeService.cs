using Assignment.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task<EmployeeResponse> SaveAsync(Employee employee);
        Task<EmployeeResponse> UpdateAsync(int id, Employee employee);
        Task<EmployeeResponse> DeleteAsync(int id);
    }
}
