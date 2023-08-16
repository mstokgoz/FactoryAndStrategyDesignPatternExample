using ProjectName.DataAccess.Interfaces;
using ProjectName.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.DataAccess.Implementations
{
    public class EmployeeDal : IEmployeeDal
    {
        public async Task<Employee> Get(Expression<Func<Employee, bool>> filter = null)
        {
            var employeeList = await GetAll();
            var employee = employeeList.AsQueryable().Where(filter).FirstOrDefault();
            return employee;
        }

        public async Task<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            return await Task.FromResult(new List<Employee>
            {
                new Employee{Id = 1, DepartmentId = 2, DepartmentName="Department", NameSurname="ST", PhoneNumber="12345678911", RegistrationNumber=12345, Title="Software Engineer"},
                new Employee{Id = 2, DepartmentId = 2, DepartmentName="Department", NameSurname="MT", PhoneNumber="12345678912", RegistrationNumber=12346, Title="Software Engineer"},
                new Employee{Id = 3, DepartmentId = 2, DepartmentName="Department", NameSurname="CT", PhoneNumber="12345678913", RegistrationNumber=12347, Title="Software Engineer"}
            });
        }

       
    }
}
