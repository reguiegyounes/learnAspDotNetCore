namespace learnAspDotNetCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public Departement Departement { get; set; }
    }
}
