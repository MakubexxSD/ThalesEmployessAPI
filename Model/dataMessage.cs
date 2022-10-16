using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployessAPI.Model
{
    public class dataMessage
    {
        public string status { get; set; }
        public EmployeesAPI data { get; set; }
        public string message { get; set; }

        public List<dataMessage> lstData { get; set; }
    }
}
