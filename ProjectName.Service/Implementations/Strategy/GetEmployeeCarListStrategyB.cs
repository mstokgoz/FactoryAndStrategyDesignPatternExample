using AutoMapper;
using ProjectName.DataAccess.Interfaces;
using ProjectName.Service.DTOs;
using ProjectName.Service.Interfaces;
using ProjectName.Service.Interfaces.Factory;
using ProjectName.Service.Interfaces.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Implementations.Strategy
{
    public class GetEmployeeCarListStrategyB : EmployeeCarService, IEmployeeCarServiceStrategy
    {
        private int? _registrationNumber;
        public GetEmployeeCarListStrategyB(int? registrationNumber, ICarDal carDal, IEmployeeService employeeService, IMapper mapper, IEmployeeCarServiceFactory employeeCarServiceFactory) : 
            base(carDal, employeeService, mapper, employeeCarServiceFactory)
        {
            _registrationNumber = registrationNumber;
        }

        public async Task<List<EmployeeCarDto>> CreateEmployeeCarListByStrategy()
        {
            var employeeDtoList = new List<EmployeeDto>();
            List<CarDto> carDtoList;

            var employeeCarEntityList = await _carDal.GetAll(c => c.OwnerRegistrationNumber == _registrationNumber);
            carDtoList = _mapper.Map<List<CarDto>>(employeeCarEntityList);
            var employeeEntityList = await _employeeService.GetAll(e => e.RegistrationNumber == _registrationNumber);
            employeeDtoList = _mapper.Map<List<EmployeeDto>>(employeeEntityList);

            return CreateEmployeeCarDtoList(carDtoList, employeeDtoList);
        }
    }
}
