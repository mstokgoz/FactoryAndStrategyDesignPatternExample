using AutoMapper;
using ProjectName.Core.Utilities.Results;
using ProjectName.DataAccess.Interfaces;
using ProjectName.Service.DTOs;
using ProjectName.Service.Interfaces;
using ProjectName.Service.Interfaces.Factory;
using ProjectName.Service.Interfaces.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Implementations
{
    public class EmployeeCarService : IEmployeeCarService
    {
        protected readonly ICarDal _carDal;
        protected readonly IEmployeeService _employeeService;
        protected readonly IMapper _mapper;
        protected readonly IEmployeeCarServiceFactory _employeeCarServiceFactory;
        public EmployeeCarService(ICarDal carDal, IEmployeeService employeeService, IMapper mapper, IEmployeeCarServiceFactory employeeCarServiceFactory)
        {
            _carDal = carDal;
            _employeeService = employeeService;
            _mapper = mapper;
            _employeeCarServiceFactory = employeeCarServiceFactory;
        }


        public async Task<IDataResult<List<EmployeeCarDto>>> GetEmployeeCarsListByPlateOrRegistrationNumber(string plate, int? registrationNumber = null)
        {
            IEmployeeCarServiceStrategy strategy = _employeeCarServiceFactory.ProduceStrategy(plate, registrationNumber);

            var employeeCarDtoList = await strategy.CreateEmployeeCarListByStrategy();

            return new SuccessDataResult<List<EmployeeCarDto>>(employeeCarDtoList);
        }

        //public async Task<IDataResult<List<EmployeeCarDto>>> GetEmployeeCarsListByPlateOrRegistrationNumber(string plate, int? registrationNumber = null)
        //{
        //    var employeeDtoList = new List<EmployeeDto>();
        //    List<CarDto> carDtoList;

        //    if (!string.IsNullOrWhiteSpace(plate) && !registrationNumber.HasValue)
        //    {
        //        var employeeCarEntityList = await _carDal.GetAll(c => c.Plate.Equals(plate));
        //        carDtoList = _mapper.Map<List<CarDto>>(employeeCarEntityList);

        //        var registrationNumberList = carDtoList.Select(p => p.OwnerRegistrationNumber).Distinct();

        //        foreach (var registNumber in registrationNumberList)
        //        {
        //            var employeeDataResult = await _employeeService.Get(p => p.RegistrationNumber == registNumber);
        //            var employee = employeeDataResult.Data;
        //            if (employee != null)
        //                employeeDtoList.Add(employee);
        //        }
        //    }
        //    else if (registrationNumber.HasValue && string.IsNullOrWhiteSpace(plate))
        //    {
        //        var employeeCarEntityList = await _carDal.GetAll(c => c.OwnerRegistrationNumber == registrationNumber);
        //        carDtoList = _mapper.Map<List<CarDto>>(employeeCarEntityList);
        //        var employeeEntityList = await _employeeService.GetAll(e => e.RegistrationNumber == registrationNumber);
        //        employeeDtoList = _mapper.Map<List<EmployeeDto>>(employeeEntityList);

        //    }
        //    else
        //    {
        //        var employeeCarEntityList = await _carDal.GetAll(c => c.Plate.Contains(plate) && c.OwnerRegistrationNumber == registrationNumber);
        //        carDtoList = _mapper.Map<List<CarDto>>(employeeCarEntityList);
        //        var employeeEntityList = await _employeeService.GetAll(e => e.RegistrationNumber == registrationNumber);
        //        employeeDtoList = _mapper.Map<List<EmployeeDto>>(employeeEntityList);
        //    }
        //    return new SuccessDataResult<List<EmployeeCarDto>>(CreateEmployeeCarDtoList(carDtoList, employeeDtoList));
        //}

        protected List<EmployeeCarDto> CreateEmployeeCarDtoList(IEnumerable<CarDto> carList, IEnumerable<EmployeeDto> employeeList)
        {
            IEnumerable<EmployeeCarDto> employeeCarJoinedList = from car in carList
                                                                join
                                                                employee in employeeList on
                                                                car.OwnerRegistrationNumber equals employee.RegistrationNumber
                                                                select new EmployeeCarDto
                                                                {
                                                                    OwnerRegistrationNumber = employee.RegistrationNumber,
                                                                    Plate = car.Plate,
                                                                    ProductionYear = car.ProductionYear,
                                                                    Make = car.Make,
                                                                    Model = car.Model,
                                                                    Color = car.Color,
                                                                    DepartmentId = employee.DepartmentId,
                                                                    DepartmentName = employee.DepartmentName,
                                                                    NameSurname = employee.NameSurname,
                                                                    PhoneNumber = employee.PhoneNumber,
                                                                    Title = employee.Title                                                                    
                                                                };
            return employeeCarJoinedList.ToList();
        }
    }
}
