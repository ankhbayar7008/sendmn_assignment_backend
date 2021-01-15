using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.API.Extentions;
using Assignment.API.Models;
using Assignment.API.Resources;
using Assignment.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class EmployeesController:Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await _employeeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);
            return employees;
        }
         
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);

            var result = await _employeeService.SaveAsync(employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployeeResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.UpdateAsync(id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Employee);
            return Ok(employeeResource);
        }

    }
}
