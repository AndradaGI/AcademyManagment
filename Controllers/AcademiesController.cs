
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademyManagement.Data;
using AcademyManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace AcademyManagement.Controllers
{
    public class AcademiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? courseId)
        {
            var academies = _context.Academies.Include(a => a.Courses).ToList();
            ViewBag.SelectedCourse = null;
            ViewBag.EnrolledStudents = new List<Student>();

            if (courseId.HasValue)
            {
                ViewBag.SelectedCourse = _context.Courses.FirstOrDefault(c => c.Id == courseId);
                ViewBag.EnrolledStudents = _context.Enrollments
                    .Where(e => e.CourseId == courseId)
                    .Select(e => e.Student)
                    .ToList();
            }

            return View(academies);
        }

        public IActionResult Select(int id)
        {
            var academy = _context.Academies.Find(id);
            if (academy == null)
            {
                return NotFound();
            }
            ViewBag.SelectedAcademy = academy;
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var academy = _context.Academies.Find(id);
            if (academy == null)
            {
                return NotFound();
            }
            return View(academy);
        }

        [HttpPost]
        public IActionResult Edit(int id, Academy academy)
        {
            if (id != academy.Id)
            {
                return BadRequest();
            }

            _context.Update(academy);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Academy academy)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Academies.Add(academy);
                    _context.SaveChanges();
                    return RedirectToAction("Index"); // Redirecționează către lista academiilor
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the academy.");
                    Console.WriteLine(ex.Message);
                }
            }

            return View(academy); // Dacă sunt erori, reafișăm formularul
        }





        public IActionResult Details(int id)
        {
            var academy = _context.Academies.Include(a => a.Courses)
                                             .FirstOrDefault(a => a.Id == id);
            if (academy == null)
            {
                return NotFound();
            }
            return View(academy);
        }

        public IActionResult Delete(int id)
        {
            var academy = _context.Academies.Find(id);
            if (academy == null)
            {
                return NotFound();
            }
            return View(academy);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var academy = _context.Academies.Find(id);
            if (academy != null)
            {
                _context.Academies.Remove(academy);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
