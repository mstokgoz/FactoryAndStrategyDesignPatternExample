using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.DTOs
{
    public class EmployeeCarDto
    {
        public int OwnerRegistrationNumber { get; set; }
        public string Plate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string ProductionYear { get; set; }       
        public string NameSurname { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }

    }
}
