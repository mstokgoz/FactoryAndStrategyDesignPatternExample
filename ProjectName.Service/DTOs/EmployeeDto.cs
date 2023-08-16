using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.DTOs
{
    public class EmployeeDto
    {
        public int RegistrationNumber { get; set; }

        public string NameSurname { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }


    }
}
