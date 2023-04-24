using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Datadto
{
    public class EmployeeDto
    {
        /*[Required(ErrorMessage = " EmployeeId is Mandotory Field")]
        public int EmployeeId { get; set; }*/

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pan { get; set; }
    }
}
