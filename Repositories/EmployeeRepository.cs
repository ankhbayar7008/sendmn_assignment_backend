using Assignment.API.Contexts;
using Assignment.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context): base(context) { }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
    }
}
