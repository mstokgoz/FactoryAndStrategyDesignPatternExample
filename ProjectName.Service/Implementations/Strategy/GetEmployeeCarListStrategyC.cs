using AutoMapper;
using ProjectName.DataAccess.Interfaces;
using ProjectName.Service.Interfaces.Factory;
using ProjectName.Service.Interfaces;
using ProjectName.Service.Interfaces.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectName.Service.DTOs;

namespace ProjectName.Service.Implementations.Strategy
{
    public class GetEmployeeCarListStrategyC : EmployeeCarService, IEmployeeCarServiceStrategy
    {
        private int? _registrationNumber;
        private string _plate;
        public GetEmployeeCarListStrategyC(string plate, int? registrationNumber, ICarDal carDal, IEmployeeService employeeService, IMapper mapper, IEmployeeCarServiceFactory employeeCarServiceFactory) :
            base(carDal, employeeService, mapper, employeeCarServiceFactory)
        {
            _plate = plate;
            _registrationNumber = registrationNumber;
        }

        public async Task<List<EmployeeCarDto>> CreateEmployeeCarListByStrategy()
        {
            var employeeDtoList = new List<EmployeeDto>();
            List<CarDto> carDtoList;
            var employeeCarEntityList = await _carDal.GetAll(c => c.Plate.Contains(_plate) && c.OwnerRegistrationNumber == _registrationNumber);
            carDtoList = _mapper.Map<List<CarDto>>(employeeCarEntityList);
            var employeeEntityList = await _employeeService.GetAll(e => e.RegistrationNumber == _registrationNumber);
            employeeDtoList = _mapper.Map<List<EmployeeDto>>(employeeEntityList);
            return CreateEmployeeCarDtoList(carDtoList, employeeDtoList);
        }
    }
}
