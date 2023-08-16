using ProjectName.Core.DataAccess.EntityFramework;
using ProjectName.DataAccess.Interfaces;
using ProjectName.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.DataAccess.Implementations
{
    public class CarDal : ICarDal
    {
        public async Task<List<Car>> GetAll(Expression<Func<Car, bool>> filter)
        {
            return await Task.FromResult( new List<Car>
            {
                new Car {Id =1, Color="Red", Make="Tesla", Model="Y", OwnerRegistrationNumber=12345, Plate="00AA185", ProductionYear="2023"},
                new Car {Id =2, Color="White", Make="Tesla", Model="Y", OwnerRegistrationNumber=12346, Plate="00AA186", ProductionYear="2023"},
                new Car {Id =3, Color="Blue", Make="Tesla", Model="Y", OwnerRegistrationNumber=12347, Plate="00AA187", ProductionYear="2023"},
            });
        }
    }
}
