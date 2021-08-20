﻿using System.Collections.Generic;

namespace learnAspDotNetCore.Models.Repositories
{
    public interface ICompanyRepository<TEntity>
    {
        TEntity Get(int id); 
        IEnumerable<Employee> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
    }
}
