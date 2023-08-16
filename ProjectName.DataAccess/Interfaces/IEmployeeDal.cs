using ProjectName.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.DataAccess.Interfaces
{
    public interface IEmployeeDal
    {
        Task<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null);

        Task<Employee> Get(Expression<Func<Employee, bool>> filter = null);

    }
}
