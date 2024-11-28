using Cumulative_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Cumulative_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {

        // This is dependancy injection
        private readonly SchoolDbContext _context;
        public StudentAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The 3th link added to our web page is to teachers API (Swagger UI), 
        /// it redirects to a swagger page that shows a list of all teachers in our created database.
        /// </summary>
        /// <example>
        /// GET api/Teacher/LStudent -> [{"s_Id": 0,"s_FName": "string","s_LName": "string","s_Num": "string","s_E_Date": "2024-11-16T03:21:24.340Z"}]
        /// GET api/Teacher/LStudent -> [{"t_Id": 2,"fName": "Caitlin","lName": "Cummings","hireDate": "2014-06-10T00:00:00","e_Number": "T381","salary": 62.77}]
        /// </example>
        /// <returns>
        /// A list all the Student from Student table in the database school
        /// </returns>

        [HttpGet]
        [Route(template: "LStudents")]
        public List<Student> LStudents()
        {
            // Create a list of Students
            List<Student> Students = new List<Student>();

            // 'using' keyword automatically closes the connection by itself after executing the code given inside
            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                // Opening the connection
                Connection.Open();


                // Establishing a new query for our database 
                MySqlCommand Command = Connection.CreateCommand();


                // Writing the SQL Query we want to give to database to access information
                Command.CommandText = "select * from students";


                // Storing the Result Set query in a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

                    // While loop is used to loop through each row in the ResultSet 
                    while (ResultSet.Read())
                    {

                        // Accessing the information of Students using the Column name as an index
                        int s_id = Convert.ToInt32(ResultSet["studentid"]);
                        string fn = ResultSet["studentfname"].ToString();
                        string ln = ResultSet["studentlname"].ToString();
                        string snum = ResultSet["studentnumber"].ToString();
                        DateTime endate = Convert.ToDateTime(ResultSet["enroldate"]);


                        // Assigning short names for properties of the Students
                        Student student_details = new Student()
                        {
                            S_Id = s_id,
                            S_FName = fn,
                            S_LName = ln,
                            S_Num = snum,
                            S_E_Date = endate,
                        };


                        // Adding all the values of properties of Students_details in student List
                        Students.Add(student_details);

                    }
                }
            }


            //Return the final list of Students 
            return Students;
        }


        /// <summary>
        /// When we click on a Student name, it redirects to a new webpage that shows details of that student
        /// same way for API once we give an input of our id it shows details of that student
        /// </summary>
        /// <remarks>
        /// it will select the ID of the student when you click (or give it as an input in swagger ui) on its name and it selects the data from the database from the selected id
        /// </remarks>
        /// <example>
        /// GET api/TeacherInfo/1 -> {"s_Id": 1,"s_FName": "Sarah","s_LName": "Valdez","s_Num": "N1678","s_E_Date": "2018-06-18T00:00:00"}
        /// </example>
        /// <returns>
        /// list of all Information about the Selected student from their database
        /// </returns>



        [HttpGet]
        [Route(template: "StudentInfo/{id}")]
        public Student StudentInfo(int id)
        {

            // Created an object "SelStudent" using student definition defined as Class in Models
            Student SelStudent = new Student();


            // 'using' keyword automatically closes the connection by itself after executing the code given inside
            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                // Opening the Connection
                Connection.Open();

                // Establishing a new query for our database 
                MySqlCommand Command = Connection.CreateCommand();


                // @id is replaced with a 'sanitized'(masked) id so that id can be referenced
                // without revealing the actual @id
                Command.CommandText = "select * from students where studentid=@id";
                Command.Parameters.AddWithValue("@id", id);


                // Storing the Result Set query in a variable
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

                    // While loop is used to loop through each row in the ResultSet 
                    while (ResultSet.Read())
                    {

                        // Accessing the information of student using the Column name as an index
                        int s_id = Convert.ToInt32(ResultSet["studentid"]);
                        string fn = ResultSet["studentfname"].ToString();
                        string ln = ResultSet["studentlname"].ToString();
                        string snum = ResultSet["studentnumber"].ToString();
                        DateTime endate = Convert.ToDateTime(ResultSet["enroldate"]);


                        // Accessing the information of the properties of student and then assigning it to the short names 
                        // created above for all properties of the student
                        SelStudent.S_Id = s_id;
                        SelStudent.S_FName = fn;
                        SelStudent.S_LName = ln;
                        SelStudent.S_Num = snum;
                        SelStudent.S_E_Date = endate;
                    }
                }
            }


            //Return the Information of the SelStudent
            return SelStudent;
        }
    }
}
