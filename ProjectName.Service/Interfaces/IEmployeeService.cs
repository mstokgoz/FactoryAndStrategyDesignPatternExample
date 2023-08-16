using ProjectName.Core.Utilities.Results;
using ProjectName.Entities;
using ProjectName.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Interfaces
{
    public interface IEmployeeService
    {

        Task<IDataResult<EmployeeDto>> Get(Expression<Func<Employee, bool>> filter = null);

        Task<IDataResult<List<EmployeeDto>>> GetAll(Expression<Func<Employee, bool>> filter = null);

    }
}
