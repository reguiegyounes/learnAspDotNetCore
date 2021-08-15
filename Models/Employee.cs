using System.ComponentModel.DataAnnotations;

namespace learnAspDotNetCore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Enter email")]
        public string Email { get; set; }

        public string ImageUrl { get; set; }
        public Departement Departement { get; set; }
    }
}
