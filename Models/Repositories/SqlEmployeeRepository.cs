using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace learnAspDotNetCore.Models.Repositories
{
    public class SqlEmployeeRepository : ICompanyRepository<Employee>
    {
        private readonly AppDbContext context;

        public SqlEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee entity)
        {
            this.context.Empployees.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public Employee delete(int id)
        {
            var employee=Get(id);
            if (employee != null) {
                this.context.Empployees.Remove(employee);
                this.context.SaveChanges();
            }
            return employee;
        }

        public Employee Get(int id)
        {
            return this.context.Empployees.SingleOrDefault(emp => emp.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.context.Empployees;
        }

        public Employee update(Employee entity)
        {
            var employee = this.context.Empployees.Attach(entity);
            employee.State = EntityState.Modified;
            this.context.SaveChanges();
            return entity;
        }
    }
}
