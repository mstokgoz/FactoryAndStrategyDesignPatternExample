using ProjectName.Core.DataAccess;
using ProjectName.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.DataAccess.Interfaces
{
    public interface ICarDal
    {
        Task<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null);

    }
}
