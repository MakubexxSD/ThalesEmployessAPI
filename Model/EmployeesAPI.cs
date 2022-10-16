using System.Collections.Generic;

namespace ThalesEmployessAPI.Model
{
    public class EmployeesAPI
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }

        public List<EmployeesAPI> lstEmployees { get; set; }
    }

    public class manyEmployees
    {
        public string status { get; set; }
        public List<EmployeesAPI> data { get; set; }
        public string message { get; set; }
    }

    public class singleEmployee
    {
        public string status { get; set; }
        public EmployeesAPI data { get; set; }
        public string message { get; set; }
    }

}
