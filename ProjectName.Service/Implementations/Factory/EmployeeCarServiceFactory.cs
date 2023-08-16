using AutoMapper;
using ProjectName.DataAccess.Interfaces;
using ProjectName.Service.Implementations.Strategy;
using ProjectName.Service.Interfaces;
using ProjectName.Service.Interfaces.Factory;
using ProjectName.Service.Interfaces.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Implementations.Factory
{
    public class EmployeeCarServiceFactory : IEmployeeCarServiceFactory
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployeeCarServiceFactory(ICarDal carDal, IMapper mapper, IEmployeeService employeeService)
        {
            _carDal = carDal;
            _mapper = mapper;
            _employeeService = employeeService;
        }
        public IEmployeeCarServiceStrategy ProduceStrategy(string plate, int? registrationNumber)
        {
            if (!string.IsNullOrWhiteSpace(plate) && !registrationNumber.HasValue)
                return new GetEmployeeCarListStrategyA(plate, _carDal, _employeeService, _mapper, this);

            if (registrationNumber.HasValue && string.IsNullOrWhiteSpace(plate))
                return new GetEmployeeCarListStrategyB(registrationNumber, _carDal, _employeeService, _mapper, this);

            return new GetEmployeeCarListStrategyC(plate, registrationNumber, _carDal, _employeeService, _mapper, this);
        }
    }
}
