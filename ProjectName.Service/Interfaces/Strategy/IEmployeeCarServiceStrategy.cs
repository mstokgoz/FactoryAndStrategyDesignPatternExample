using ProjectName.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Interfaces.Strategy
{
    public interface IEmployeeCarServiceStrategy
    {
        Task<List<EmployeeCarDto>> CreateEmployeeCarListByStrategy();

    }
}
