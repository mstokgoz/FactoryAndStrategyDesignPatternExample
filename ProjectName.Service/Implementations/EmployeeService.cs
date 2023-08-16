using AutoMapper;
using ProjectName.Core.Utilities.Results;
using ProjectName.DataAccess.Interfaces;
using ProjectName.Entities;
using ProjectName.Service.DTOs;
using ProjectName.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        IMapper _mapper;

        public EmployeeService(IEmployeeDal employeeDal, IMapper mapper)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
        }
        public async Task<IDataResult<EmployeeDto>> Get(Expression<Func<Employee, bool>> filter = null)
        {
            var employeeEntity = await _employeeDal.Get(filter);
            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);
            return new SuccessDataResult<EmployeeDto>(employeeDto);
        }

        public async Task<IDataResult<List<EmployeeDto>>> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            var employeeEntityList = await _employeeDal.GetAll(filter);
            var employeeDtoList = _mapper.Map<List<EmployeeDto>>(employeeEntityList);
            return new SuccessDataResult<List<EmployeeDto>>(employeeDtoList);
        }
    }
}
