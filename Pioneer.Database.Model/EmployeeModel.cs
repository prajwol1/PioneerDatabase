using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneer.Database.Model
{
    public class EmployeeModel
    {
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long MobileNumber { get; set; }
        public long AlternateMobileNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CurrentCountry { get; set; }
        public string HomeCountry { get; set; }
        public int ZipCode { get; set; }
    }

    
    
}
