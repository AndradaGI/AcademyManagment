using Microsoft.AspNetCore.Mvc;

namespace AcademyManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<string> courses = new() { "Math", "Physics", "Biology" };

        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(courses);
        }

        [HttpPost]
        public IActionResult AddCourse(string course)
        {
            courses.Add(course);
            return Ok(courses);
        }
    }
}
