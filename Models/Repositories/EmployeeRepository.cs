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
                new Employee() {Id = 1, Name ="ali",Email="ali@email.com",Departement=Departement.Math,ImageUrl="/Images/1.jpg" },
                new Employee() {Id = 2, Name ="youcef",Email="youcef@email.com",Departement=Departement.Programming,ImageUrl="/Images/2.jpg" },
                new Employee() {Id = 3, Name ="mohamed",Email="mohamed@email.com",Departement=Departement.IT ,ImageUrl="/Images/3.jpg"},
                new Employee() {Id = 4, Name ="serine",Email="serine@email.com",Departement=Departement.Web ,ImageUrl="/Images/4.jpg"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id= _employees.Max(emp => emp.Id + 1);
            if (employee.ImageUrl is null)
            {
                employee.ImageUrl = "/images/default.png";
            }
            _employees.Add(employee);
            return employee;
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
