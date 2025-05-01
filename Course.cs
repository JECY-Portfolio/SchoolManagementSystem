using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace School_Management_System
{
    public class Course
    {
        public string CourseName { get; set; }
        public string CourseID { get; set; }
        public double Credits { get; set; }
        public List<Student> EnrolledStudents { get; set; }
        public string AssignedToTeacherID { get; set; }


        public Course(string courseName, string courseID, double credits)
        {
            CourseName = courseName;
            CourseID = courseID;
            Credits = credits;
            EnrolledStudents = new List<Student>();


        }

        public void EnrollStudents(Student student)
        {
            EnrolledStudents.Add(student);
        }
        public void DropStudent(Student student)
        {
            EnrolledStudents.Remove(student);
        }
        public void FetchCourseInfo()
        {
            Console.WriteLine($"Course Name: {CourseName}, Course ID: {CourseID}, Credits: {Credits}");

        }


    }
}

          