using ProjectName.Core.Utilities.Results;
using ProjectName.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Interfaces
{
    public interface IEmployeeCarService
    {

        Task<IDataResult<List<EmployeeCarDto>>> GetEmployeeCarsListByPlateOrRegistrationNumber(string plate, int? registrationNumber = null);
    }
}
