using ProjectName.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Entities
{
    public class Employee : Entity
    {
        public int RegistrationNumber { get; set; }
        public string NameSurname { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

    }
}
