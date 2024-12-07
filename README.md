# School Database MVP: Manage Teachers, Students, and Courses

## Project Overview  
This project demonstrates the implementation of **CRUD (Create, Read, Update, Delete)** operations using **ASP.NET Core Web API and MVC**. The application serves as a foundational system to manage academic data for a school, focusing on teachers, students, and courses. The goal is to deliver a Minimum Viable Product (MVP) that seamlessly integrates backend APIs with dynamic front-end web pages, providing a complete data management experience.

---

## Key Features  

### 1. **Robust CRUD Functionality**  
   - Add, view, edit, and remove records for **Teachers**, **Students**, and **Courses** through a user-friendly interface and API endpoints.

### 2. **Data Validation and Error Handling**  
   - Enforce rules for valid data entries, such as:  
     - Preventing duplicate records.  
     - Restricting invalid dates (e.g., future dates for birth or hire).  
     - Ensuring required fields are not left blank.

### 3. **Relational Database Design**  
   - Built on **MySQL**, the database ensures proper relationships:  
     - **Teachers** linked to their respective **Courses**.  
     - **Students** linked to the **Courses** they enroll in.  

### 4. **Seamless Integration**  
   - Combines a **dynamic web interface** with API endpoints for full-stack functionality, enabling flexibility for both developers and users.

---

## Testing and Validation  

Extensive testing ensures that each feature works reliably. Evidence includes the use of cURL commands, screenshots of web page interactions, and detailed logs of each operation.  

- **Add Records**  
  - Input validation ensures accurate database entry.  
  - Verified creation of new teachers, students, and courses.  

- **View Records**  
  - Confirmed proper retrieval and display of data from the database, including relationships (e.g., courses taught by a teacher).  

- **Update Records**  
  - Validated the successful modification of existing data.  
  - Ensured changes reflect accurately in both the database and front-end display.  

- **Delete Records**  
  - Verified deletion with appropriate confirmation prompts.  
  - Checked handling of non-existent or previously deleted records.  

---

## Usability and Purpose  

This project is designed for educational institutions or learners interested in managing school data. It provides a practical framework for:  
- Understanding **CRUD operations** in web applications.  
- Learning **ASP.NET Core MVC** development practices.  
- Mastering relational database concepts.  

---

## Learning Objectives  

1. **Build Functional CRUD Applications**  
   - Develop and implement CRUD operations for multiple data entities (Teachers, Students, Courses).  

2. **Apply Object-Oriented Programming Principles**  
   - Design modular, scalable classes with encapsulation and clear relationships.  

3. **Integrate and Manage Relational Databases**  
   - Define relationships between entities using foreign keys and enforce referential integrity.  

4. **Combine Back-End and Front-End**  
   - Seamlessly connect APIs with a dynamic UI, ensuring a cohesive user experience.  

---

This project serves as a comprehensive guide for developers and students aiming to enhance their understanding of **full-stack development**, relational databases, and scalable design in a professional environment.
