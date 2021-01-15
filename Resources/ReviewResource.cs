using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Resources
{
    public class ReviewResource
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public EmployeeResource Employee { get; set; }
    }
}
