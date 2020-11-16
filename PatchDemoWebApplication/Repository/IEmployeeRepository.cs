using PatchDemoWebApplication.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatchDemoWebApplication.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> Employees();
        Task<Employee> Employee(int? employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);

    }
}
