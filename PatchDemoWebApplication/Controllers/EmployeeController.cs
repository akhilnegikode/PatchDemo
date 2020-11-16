using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatchDemoWebApplication.Context;
using PatchDemoWebApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatchDemoWebApplication.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await employeeRepository.Employees();
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(int? employeeId)
        {
            if (employeeId is null)
            {
                return BadRequest();
            }
            var employee = await employeeRepository.Employee(employeeId);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var employeeId = await employeeRepository.AddEmployee(employee);
                return Ok(employeeId);
            }
            return BadRequest();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> JsonPatchRequest(int id, [FromBody] JsonPatchDocument<Employee> patchRequest)
        {
            if (patchRequest != null)
            {
                var entity = employeeRepository.Employees().Result.FirstOrDefault(employee => employee.EmployeeId == id);

                patchRequest.ApplyTo(entity, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                TryValidateModel(entity);
                if (!ModelState.IsValid)
                {
                    return BadRequest(this.ModelState);
                }
                await employeeRepository.UpdateEmployee(entity);

                return Ok(entity);
            }
            return BadRequest();
        }
    }
}
