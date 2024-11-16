namespace Cumulative_1.Models
{

    // Created a Course Class that defines different properties of the course table
    // This definition is used to create different objects for each row in that table
    // The properties of that each object is then accessed and are sent to view to display on the respective webpages
    // Here, course 'Class' has 6 properties (C_Id, CCode, T_Id, S_Date, E_Date, CName)
    // these are accessed by Controllers and then retrived to View to display that properties information on the web page
    public class Course
    {
        // Unique identifier for each Course. It is used as the primary key in a database.
        public int C_Id { get; set; }

        // Name of the teacher. It stores the Course's name as a string.
        public string CCode { get; set; }

        // we are using inner join to connet teacher table using teacher_id abd displaying teacher fname for each
        // courses(linked to teacher table).
        public int T_Id { get; set; }

        // The Start date and end date of a course. It is used to track course duration.
        // Stored as datetime
        public DateTime S_Date { get; set; }
        public DateTime E_Date { get; set; }

        // It is a Course name. stored as a string
        public string CName { get; set; }
    }
}
