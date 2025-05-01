using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace School_Management_System
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string GradeLevel { get; set; }
        public string StudentID { get; set; }
        public List<Course> EnrolledCourses { get; set;}
        public List<Grade> Grades { get; set; }

        public Student ( string name, int age, string gradelevel, string studentid)
        {
            Name = name;
            Age = age;
            GradeLevel = gradelevel;
            StudentID = studentid;
             EnrolledCourses = new List<Course>();
            Grades = new List<Grade>();
        }

        public void EnrollCourse(Course course)
        {
            EnrolledCourses.Add(course);
        }
        public void DropCourse(Course course)
        {
            EnrolledCourses.Remove(course);
        }

        public void AddGrade(Grade grade)
        {
            Grades.Add(grade);
        }

       public double CalculateGPA()
        {
            return Grade.CalculateGPA(Grades);
        }
        public void FetchStudentInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Grade Level: {GradeLevel}, Student ID: {StudentID}");
            Console.WriteLine("GPA: " + CalculateGPA().ToString("F2"));
        }

    }
}
