using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Service.DTOs
{
    public class CarDto
    {
        public int OwnerRegistrationNumber { get; set; }
        public string Plate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string ProductionYear { get; set; }

    }
}
