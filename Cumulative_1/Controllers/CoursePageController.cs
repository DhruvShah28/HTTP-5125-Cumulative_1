using Microsoft.AspNetCore.Mvc;
using Cumulative_1.Models;

namespace Cumulative_1.Controllers
{
    public class CoursePageController : Controller
    {
        // API handles gathering all the data from
        // the Database and MVC is responsible for creating an HTTP response
        // and showing it on a web page that displays the data from database
        // to the View.

        private readonly TeacherAPIController _api;

        public CoursePageController(TeacherAPIController api)
        {
            _api = api;
        }

        public IActionResult CList()
        {
            List<Course> courses = _api.Lcourses();

            return View(courses);
        }

        public IActionResult CShow(int id)
        {
            Course SelCourse = _api.CourseInfo(id);
            return View(SelCourse);
        }
    }
}
