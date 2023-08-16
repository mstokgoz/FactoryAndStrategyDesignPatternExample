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
    public class GetEmployeeCarListStrategyA : EmployeeCarService, IEmployeeCarServiceStrategy
    {
      
        string _plate;
        public GetEmployeeCarListStrategyA(string plate, ICarDal carDal, IEmployeeService employeeService, IMapper mapper, IEmployeeCarServiceFactory employeeCarServiceFactory) : 
            base(carDal, employeeService, mapper, employeeCarServiceFactory)
        {        
            _plate = plate;
        }

        public async Task<List<EmployeeCarDto>> CreateEmployeeCarListByStrategy()
        {
            var employeeDtoList = new List<EmployeeDto>();
            List<CarDto> carDtoList;
            var employeeCarEntityList = await _carDal.GetAll(c => c.Plate.Equals(_plate));
            carDtoList = _mapper.Map<List<CarDto>>(employeeCarEntityList);

            var registrationNumberList = carDtoList.Select(p => p.OwnerRegistrationNumber).Distinct();

            foreach (var registNumber in registrationNumberList)
            {
                var employeeDataResult = await _employeeService.Get(p => p.RegistrationNumber == registNumber);
                var employee = employeeDataResult.Data;
                if (employee != null)
                    employeeDtoList.Add(employee);
            }
            return CreateEmployeeCarDtoList(carDtoList, employeeDtoList);
        }
    }
}
