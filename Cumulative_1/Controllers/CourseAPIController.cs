using Cumulative_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Cumulative_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAPIController : ControllerBase
    {
        // This is dependancy injection
        private readonly SchoolDbContext _context;
        public CourseAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        // -------------------------------------------------Courses--------------------------------------------------------------------------------------

        /// <summary>
        /// The 3th link added to our web page is to student API (Swagger UI), 
        /// it redirects to a swagger apge that shows a list of all teachers in our created database.
        /// </summary>
        /// <example>
        /// GET api/Teacher/LTeachers -> [{"c_Id": 0,"cCode": "string","t_Id": 0,"s_Date": "2024-11-16T03:27:01.671Z","e_Date": "2024-11-16T03:27:01.671Z","cName": "string"}]
        /// GET api/Teacher/LTeachers -> [{"t_Id": 2,"fName": "Caitlin","lName": "Cummings","hireDate": "2014-06-10T00:00:00","e_Number": "T381","salary": 62.77}]
        /// </example>
        /// <returns>
        /// A list all the teachers from teachers table in the database school
        /// </returns>

        [HttpGet]
        [Route(template: "LCourses")]
        public List<Course> Lcourses()
        {
            // Create a list of course
            List<Course> Courses = new List<Course>();

            // 'using' keyword automatically closes the connection by itself after executing the code given inside
            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                // Opening the connection
                Connection.Open();


                // Establishing a new query for our database 
                MySqlCommand Command = Connection.CreateCommand();


                // Writing the SQL Query we want to give to database to access information
                Command.CommandText = "SELECT * FROM courses;";


                // Storing the Result Set query in a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

                    // While loop is used to loop through each row in the ResultSet 
                    while (ResultSet.Read())
                    {

                        // Accessing the information of course using the Column name as an index
                        int c_id = Convert.ToInt32(ResultSet["Courseid"]);
                        string c_code = ResultSet["coursecode"].ToString();
                        int t_id = Convert.ToInt32(ResultSet["teacherid"]);
                        DateTime sdate = Convert.ToDateTime(ResultSet["startdate"]);
                        DateTime edate = Convert.ToDateTime(ResultSet["finishdate"]);
                        string c_name = ResultSet["coursename"].ToString();


                        // Assigning short names for properties of the course
                        Course course_details = new Course()
                        {
                            Course_Id = c_id,
                            Course_Code = c_code,
                            Teacher_Id = t_id,
                            C_Start_Date = sdate,
                            C_End_Date = edate,
                            C_Name = c_name,
                        };


                        // Adding all the values of properties of Course_details in student List
                        Courses.Add(course_details);

                    }
                }
            }


            //Return the final list of course 
            return Courses;
        }


        /// <summary>
        /// When we click on a course name, it redirects to a new webpage that shows details of that course
        /// same wayf for API once we give an input of our id it shows details of that course
        /// </summary>
        /// <remarks>
        /// it will select the ID of the course when you click (or give it as an input in swagger ui) on its name and it selects the data from the database from the selected id
        /// </remarks>
        /// <example>
        /// GET api/Teacher/TeacherInfo/1 -> {"c_Id": 1,"cCode": "http5101","t_Id": 1,"s_Date": "2018-09-04T00:00:00","e_Date": "2018-12-14T00:00:00","cName": "Web Application Development"}
        /// </example>
        /// <returns>
        /// list of all Information about the Selected course from their database
        /// </returns>



        [HttpGet]
        [Route(template: "CourseInfo/{id}")]
        public Course CourseInfo(int id)
        {

            // Created an object "SelTeachers" using course definition defined as Class in Models
            Course SelCourse = new Course();


            // 'using' keyword automatically closes the connection by itself after executing the code given inside
            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                // Opening the Connection
                Connection.Open();

                // Establishing a new query for our database 
                MySqlCommand Command = Connection.CreateCommand();


                // @id is replaced with a 'sanitized'(masked) id so that id can be referenced
                // without revealing the actual @id
                Command.CommandText = "SELECT * FROM courses WHERE courseid = @id;";
                Command.Parameters.AddWithValue("@id", id);


                // Storing the Result Set query in a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

                    // While loop is used to loop through each row in the ResultSet 
                    while (ResultSet.Read())
                    {

                        // Accessing the information of course using the Column name as an index
                        int c_id = Convert.ToInt32(ResultSet["Courseid"]);
                        string c_code = ResultSet["coursecode"].ToString();
                        int t_id = Convert.ToInt32(ResultSet["teacherid"]);
                        DateTime sdate = Convert.ToDateTime(ResultSet["startdate"]);
                        DateTime edate = Convert.ToDateTime(ResultSet["finishdate"]);
                        string c_name = ResultSet["coursename"].ToString();


                        // Accessing the information of the properties of course and then assigning it to the short names 
                        // created above for all properties of the course
                        SelCourse.Course_Id = c_id;
                        SelCourse.Course_Code = c_code;
                        SelCourse.Teacher_Id = t_id;
                        SelCourse.C_Start_Date = sdate;
                        SelCourse.C_End_Date = edate;
                        SelCourse.C_Name = c_name;
                    }
                }
            }


            //Return the Information of the SelCourse
            return SelCourse;
        }
    }
}
