﻿using learnAspDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace learnAspDotNetCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "ali", Email = "ali@email.com", Departement = Departement.Math, ImageUrl = "/Images/1.jpg" },
                new Employee() { Id = 2, Name = "youcef", Email = "youcef@email.com", Departement = Departement.Programming, ImageUrl = "/Images/2.jpg" },
                new Employee() { Id = 3, Name = "mohamed", Email = "mohamed@email.com", Departement = Departement.IT, ImageUrl = "/Images/3.jpg" }
            );
        }
    }
}
