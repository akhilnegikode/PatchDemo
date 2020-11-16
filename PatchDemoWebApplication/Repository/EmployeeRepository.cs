using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PatchDemoWebApplication.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatchDemoWebApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDbContext dbContext;
        private readonly IValidator<Employee> _validator;

        public EmployeeRepository(EmployeeDbContext _db, IValidator<Employee> validator)
        {
            dbContext = _db;
            this._validator = validator;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (dbContext != null)
            {
                await dbContext.Employees.AddAsync(employee);
                await dbContext.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employee> Employee(int? employeeId)
        {
            if (dbContext != null)
            {
                return await dbContext.Employees.FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Employee>> Employees()
        {
            if (dbContext != null)
            {
                return await dbContext.Employees.ToListAsync();
            }
            return null;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            if (dbContext != null)
            {
                if(_validator.Validate(employee).IsValid)
                {
                    dbContext.Employees.Update(employee);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
