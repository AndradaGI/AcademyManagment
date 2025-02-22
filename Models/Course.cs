namespace AcademyManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AcademyId { get; set; }
        public Academy? Academy { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}