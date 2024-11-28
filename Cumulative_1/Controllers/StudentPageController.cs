using Microsoft.AspNetCore.Mvc;
using Cumulative_1.Models;

namespace Cumulative_1.Controllers
{
    public class StudentPageController : Controller
    {

        // API handles gathering all the data from
        // the Database and MVC is responsible for creating an HTTP response
        // and showing it on a web page that displays the data from database
        // to the View.

        private readonly StudentAPIController _api;

        public StudentPageController(StudentAPIController api)
        {
            _api = api;
        }

        public IActionResult SList()
        {
            List<Student> students = _api.LStudents();

            return View(students);
        }

        public IActionResult SShow(int id)
        {
            Student SelStudents = _api.StudentInfo(id);
            return View(SelStudents);
        }
    }
}
