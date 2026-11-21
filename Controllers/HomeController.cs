using Microsoft.AspNetCore.Mvc;

namespace StudentCourseRegistration.Controllers;

public class HomeController : Controller
{
    // GET: /  (home page)
    public IActionResult Index()
    {
        return View();
    }
}
