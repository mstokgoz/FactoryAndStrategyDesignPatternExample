using ProjectName.Service.Interfaces.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.Interfaces.Factory
{
    public interface IEmployeeCarServiceFactory
    {
        IEmployeeCarServiceStrategy ProduceStrategy(string plate, int? registrationNumber);
    }
}
