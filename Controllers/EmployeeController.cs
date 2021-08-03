using learnAspDotNetCore.Models;
using learnAspDotNetCore.Models.Repositories;

namespace learnAspDotNetCore.Controllers
{
    public class EmployeeController
    {
        private  ICompanyRepository<Employee> _employee;
        public EmployeeController()
        {
            _employee = new EmployeeRepository();
        }

        public string Index(int id)
        {
            return _employee.Get(id).Name;
        }
       
    }
}
