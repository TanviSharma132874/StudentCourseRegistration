using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;

namespace StudentCourseRegistration.Controllers;

public class StudentController : Controller
{
    // In-memory storage (no database needed). Data is lost when the application restarts.
    private static readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Aarav Mehta", Email = "aarav.mehta@example.com", Course = "Computer Engineering", Semester = 5 },
        new Student { Id = 2, Name = "Priya Sharma", Email = "priya.sharma@example.com", Course = "Information Technology", Semester = 3 }
    };

    private static int _nextId = 3;

    // GET: /Student  - passes the list of students to the view
    public IActionResult Index()
    {
        return View(_students);
    }

    // GET: /Student/Details/1
    public IActionResult Details(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        return View(student);
    }

    // GET: /Student/Create  - shows the empty registration form
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Student/Create  - the form values are bound to the Student object (model binding)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        // Extra rules that data annotations cannot express.
        if (!CourseCatalog.Courses.Contains(student.Course))
        {
            ModelState.AddModelError(nameof(Student.Course), "Please select a valid course.");
        }

        if (_students.Any(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(nameof(Student.Email), "This email is already registered.");
        }

        // Invalid data: show the same form again together with the error messages.
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        // Valid data: save, then redirect to the list (Post-Redirect-Get).
        student.Id = _nextId++;
        _students.Add(student);

        TempData["Success"] = $"{student.Name} was registered successfully.";
        return RedirectToAction(nameof(Index));
    }
}
