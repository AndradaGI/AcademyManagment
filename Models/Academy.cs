namespace AcademyManagement.Models
{
    public class Academy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}