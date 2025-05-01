
using System;
using System.Diagnostics;
using School_Management_System.Helpers;

namespace School_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolManager schoolManager = new SchoolManager();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO SCHOOL MANAGEMENT SYSTEM");
                Console.WriteLine("How can we assist you today.\n");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Teacher");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Assign Course to Teacher");
                Console.WriteLine("6. Add Grade");
                Console.WriteLine("7. Display All Information");
                Console.WriteLine("8. Display Student Details");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(schoolManager);
                        break;
                    case "2":
                        AddTeacher(schoolManager);
                        break;
                    case "3":
                        AddCourse(schoolManager);
                        break;
                    case "4":
                        EnrollStudentInCourse(schoolManager);
                        break;
                    case "5":
                        AssignCourseToTeacher(schoolManager);
                        break;
                    case "6":
                        AddGrade(schoolManager);
                        break;
                    case "7":
                        ConsoleHelper.DisplayAllInformation(schoolManager);
                        break;
                    case "8":
                        DisplayStudentDetails(schoolManager);
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            Console.WriteLine("Goodbye! Thank you for using the School Management System.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void AddStudent(SchoolManager schoolManager)
        {
            Console.WriteLine("\nENTER STUDENT DETAILS:");
            Console.Write("Student ID: ");
            string studentID = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();

            int age;
            Console.Write("Age: ");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input for Age. Please enter a valid integer.");
                Console.Write("Age: ");
            }

            Console.Write("Grade Level: ");
            string gradeLevel = Console.ReadLine();

            if (schoolManager.Students.Exists(s => s.StudentID == studentID))
            {
                Console.WriteLine("Student with this ID already exists.");
                return;
            }

            Student newStudent = new Student(name, age, gradeLevel, studentID);
            schoolManager.AddStudent(newStudent);
            Console.WriteLine("Student added successfully!");
        }

        static void AddTeacher(SchoolManager schoolManager)
        {
            Console.WriteLine("\nENTER TEACHER DETAIL:");
            Console.Write("Teacher ID: ");
            string teacherID = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();

            int age;
            Console.Write("Age: ");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input for Age. Please enter a valid integer.");
                Console.Write("Age: ");
            }

            Console.Write("Department: ");
            string department = Console.ReadLine();

            if (schoolManager.Teachers.Exists(t => t.TeacherID == teacherID))
            {
                Console.WriteLine("Teacher with this ID already exists.");
                return;
            }

            Teacher newTeacher = new Teacher(name, age, department, teacherID);
            schoolManager.AddTeacher(newTeacher);
            Console.WriteLine("Teacher added successfully!");
        }

        static void AddCourse(SchoolManager schoolManager)
        {
            Console.WriteLine("\nEnter course details:");
            Console.Write("Course ID: ");
            string courseID = Console.ReadLine();
            Console.Write("Course Name: ");
            string courseName = Console.ReadLine();

            double credits;
            Console.Write("Credits: ");
            while (!double.TryParse(Console.ReadLine(), out credits))
            {
                Console.WriteLine("Invalid input for Credits. Please enter a valid number.");
                Console.Write("Credits: ");
            }

            if (schoolManager.Courses.Exists(c => c.CourseID == courseID))
            {
                Console.WriteLine("Course with this ID already exists.");
                return;
            }

            Course newCourse = new Course(courseName, courseID, credits);
            schoolManager.AddCourse(newCourse);
            Console.WriteLine("Course added successfully!");
        }

        static void EnrollStudentInCourse(SchoolManager schoolManager)
        {
            Console.Write("\nEnter student ID to enroll: ");
            string studentID = Console.ReadLine();
            Student student = schoolManager.Students.Find(s => s.StudentID == studentID);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter course ID to enroll: ");
            string courseID = Console.ReadLine();
            Course course = schoolManager.Courses.Find(c => c.CourseID == courseID);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            student.EnrollCourse(course);
            course.EnrollStudents(student);
            Console.WriteLine("Student enrolled successfully!");
        }

        static void AssignCourseToTeacher(SchoolManager schoolManager)
        {
            Console.Write("\nEnter teacher ID: ");
            string teacherID = Console.ReadLine();
            Teacher teacher = schoolManager.Teachers.Find(t => t.TeacherID == teacherID);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            Console.Write("Enter course ID to assign: ");
            string courseID = Console.ReadLine();
            Course course = schoolManager.Courses.Find(c => c.CourseID == courseID);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            teacher.AssignCourse(course);
            Console.WriteLine("Course assigned to teacher successfully!");
        }

        static void AddGrade(SchoolManager schoolManager)
        {
            Console.WriteLine("\nENTER GRADE DETAILS:");
            Console.Write("Student ID: ");
            string studentID = Console.ReadLine();
            Student student = schoolManager.Students.Find(s => s.StudentID == studentID);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Course ID: ");
            string courseID = Console.ReadLine();
            Course course = schoolManager.Courses.Find(c => c.CourseID == courseID);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }

            double score;
            Console.Write("Grade (0-100): ");
            while (!double.TryParse(Console.ReadLine(), out score) || score < 0 || score > 100)
            {
                Console.WriteLine("Invalid input for grade. Please enter a number between 0 and 100.");
                Console.Write("Grade (0-100): ");
            }

            Grade newGrade = new Grade(studentID, courseID, score);
            schoolManager.AddGrade(newGrade);
            student.AddGrade(newGrade); 
            Console.WriteLine("Grade added successfully!");
        }

        static void DisplayStudentDetails(SchoolManager schoolManager)
        {
            Console.Write("\nEnter student ID to view details: ");
            string studentID = Console.ReadLine();
            Student student = schoolManager.Students.Find(s => s.StudentID == studentID);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            student.FetchStudentInfo();
            Console.WriteLine("Enrolled Courses:");
            foreach (var course in student.EnrolledCourses)
            {
                Console.WriteLine($"- {course.CourseName} ({course.CourseID})");
            }
        }
    }
}


