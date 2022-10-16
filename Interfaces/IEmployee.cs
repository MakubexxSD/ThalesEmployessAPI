using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployessAPI.Model
{
    public interface IEmployee
    {
        EmployeesAPI getAllEmployees();

        EmployeesAPI getEmployeeById(int idEmp);
    }
}
