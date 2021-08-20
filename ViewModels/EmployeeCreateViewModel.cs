using learnAspDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace learnAspDotNetCore.ViewModels
{
    public class EmployeeCreateViewModel
    {
        

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Enter email")]
        public string Email { get; set; }

        [Required]
        public Departement? Departement { get; set; }

        public IFormFile Image{ get; set; }
    }
}
