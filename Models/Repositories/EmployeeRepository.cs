using System.Collections.Generic;
using System.Linq;

namespace learnAspDotNetCore.Models.Repositories
{
    public class EmployeeRepository : ICompanyRepository<Employee>
    {
        List<Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new List<Employee>() {
                new Employee() {Id = 1, Name ="ali",Email="ali@email.com",Departement="math" },
                new Employee() {Id = 2, Name ="youcef",Email="youcef@email.com",Departement="programming" }
            };
        }
        public Employee Get(int id)
        {
            return _employees.SingleOrDefault(emp => emp.Id == id); ;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }
    }
}
