using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System
{
    public class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string TeacherID { get; set; }
        public List<Course> AssignedCourses { get; set; }
        

        public Teacher(string name, int age, string department, string teacherID)
        { 
            Name = name;
            Age = age;
            Department = department;
            TeacherID = teacherID;
            AssignedCourses = new List<Course>();
        }

        public void AssignCourse(Course course)
        {
            AssignedCourses.Add(course);
        }

        public void DroppedCourse(Course course) 
        {
            AssignedCourses.Remove(course);
        }
        
        public void FetchTeacherInfo()
        {

            Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Teacher ID: {TeacherID}");
        }
    }
}
