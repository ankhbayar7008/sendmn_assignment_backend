using Assignment.API.Models;
using Assignment.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }

            catch
            {
                return new EmployeeResponse($"Error");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found");

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;

            try
            {
                _employeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }

            catch (Exception ex)
            {
                return new EmployeeResponse($"Error: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> DeleteAsync(int id)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found");

            try
            {
                _employeeRepository.Remove(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }

            catch (Exception ex)
            {
                return new EmployeeResponse($"Error: {ex.Message}");
            }
        }
    }
}
