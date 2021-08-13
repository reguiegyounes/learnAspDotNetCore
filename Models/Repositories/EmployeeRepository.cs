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
                new Employee() {Id = 1, Name ="ali",Email="ali@email.com",Departement="math",ImageUrl="/Images/1.jpg" },
                new Employee() {Id = 2, Name ="youcef",Email="youcef@email.com",Departement="programming",ImageUrl="/Images/2.jpg" },
                new Employee() {Id = 3, Name ="mohamed",Email="mohamed@email.com",Departement="IT" ,ImageUrl="/Images/3.jpg"},
                new Employee() {Id = 4, Name ="serine",Email="serine@email.com",Departement="web" ,ImageUrl="/Images/4.jpg"}
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
