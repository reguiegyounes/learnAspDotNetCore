using learnAspDotNetCore.Models;
using learnAspDotNetCore.Models.Repositories;

namespace learnAspDotNetCore.Controllers
{
    public class EmployeeController
    {
        private readonly ICompanyRepository<Employee> _employee;
        public EmployeeController(ICompanyRepository<Employee> employee)
        {
            _employee = employee;
        }

        public string Index(int id)
        {
            return _employee.Get(id).Name;
        }
       
    }
}
