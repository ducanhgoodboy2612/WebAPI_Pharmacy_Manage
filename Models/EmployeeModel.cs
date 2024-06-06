using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Gender { get; set; }

        public int? YoB { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int? Salary { get; set; }
    }
}
