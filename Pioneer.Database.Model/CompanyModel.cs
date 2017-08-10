using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.Database.Model
{

    public class CompanyModel
    {
        public String EmployerName { get; set; }
        public long EmployerContactNumber { get; set; }
        public String EmployerAddress { get; set; }
        public String Website { get; set; }
        public int EmployeeId { get; set; }

    }
}
