﻿using System.Net;
using System.Text;

namespace Messages.Client.Managers.EmployeeOptions
{
    public class GetEmployeeById : IEmployeeOption 
    {
        private EntityConsoleOutput _entityConsoleOutput = new EntityConsoleOutput();
        public void Option()
        {
            Console.WriteLine("Enter employee id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var request = HttpWebRequest.Create($"https://localhost:5001/employees/id?id={id}");
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                var response = request.GetResponse();

                var responseStream = response.GetResponseStream();
                using var readStream = new StreamReader(responseStream, Encoding.UTF8);
                var responseString = readStream.ReadToEnd();

                var employee = JsonConvert.DeserializeObject<Employee>(responseString);

                Console.WriteLine("Found employee by id:");
                _entityConsoleOutput.EmployeeOutput(employee);
            }
            catch (WebException e)
            {
                Console.WriteLine("Employee was not found");
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
