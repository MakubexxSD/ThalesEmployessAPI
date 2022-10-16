using Newtonsoft.Json;
using RestSharp;
using System;
using ThalesEmployessAPI.Model;

namespace ThalesEmployessAPI.Controllers
{
    public class EmployeesApiController : IEmployee
    {       
        private readonly RestClient client = new RestClient("http://dummy.restapiexample.com/api/v1");
        static EmployeesAPI emp = new EmployeesAPI();

        public EmployeesAPI getAllEmployees()
        {
            try
            {                
                var request = new RestRequest("/employees", Method.Get);
                var response  = persistence(request);                
                if (response.ErrorMessage != null)
                {
                    throw new ApplicationException("The service is unaviable. Try Again later. "+ response.ErrorMessage.ToString());
                }
                manyEmployees lstData = JsonConvert.DeserializeObject<manyEmployees>(response.Content);
                emp.lstEmployees = lstData.data;
                return emp;
            }
            catch (Exception e)
            {
                throw new Exception("We have a problem to get all employees for: " + e.InnerException.Message.ToString());    
            }
        }


        public EmployeesAPI getEmployeeById(int idEmp)
        {

            try
            {
                var request = new RestRequest("/employee/"+idEmp, Method.Get);
                var response = persistence(request);
                if (response.ErrorMessage != null)
                {
                    throw new ApplicationException("The service is unaviable. Try Again later. " + response.ErrorMessage.ToString());
                }
                singleEmployee x = JsonConvert.DeserializeObject<singleEmployee>(response.Content);
                emp = x.data;
                
                return emp;
                
            }
            catch (Exception e)
            {
                throw new Exception("We have a problem to get the employees for: " + e.InnerException.Message.ToString());
                
            }
        
        }

        /// <summary>
        /// Method for create multi API calls while the response be a 409 or others
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private RestResponse persistence(RestRequest request)
        {
            RestResponse Resp = new RestResponse();
            var intent = 0;
            
            while (intent >=0)
            {
                Resp = client.Execute(request);
                if (Resp.StatusCode.ToString() == "OK")
                {
                    intent = -1;
                }
                else
                {
                    intent = intent + 1;
                    if (intent == 10)
                    {
                        Resp.ErrorMessage = "We try to comunicate with the API server, but this throws an unaviable error. Try again later.";
                    }
                }
            }

            return Resp;
        }

    }
}
