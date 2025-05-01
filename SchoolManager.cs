using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System
{
    public class SchoolManager
    {
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; } 
        public List<Course> Courses { get; set; } 
        public List<Grade> Grades { get; set; }

        public SchoolManager()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Courses = new List<Course>();
            Grades = new List<Grade>();
        }



        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }
        public void AddGrade(Grade grade)
        {
            Grades.Add(grade);
        }

        public void DisplaySchoolInfo()
        {
            Console.WriteLine("\n -----School Information-----\n");

            Console.WriteLine("Students:");
            foreach (var student in Students)
            {
                student.FetchStudentInfo();
            }
            Console.WriteLine("\nTeachers:");
            foreach(var teacher in Teachers)
            {
                teacher.FetchTeacherInfo();
            }
            Console.WriteLine("\nCourse:");
                foreach(var course in Courses)
            {
                course.FetchCourseInfo();

            }
            Console.WriteLine("\nGrades:");
            foreach(var grade in Grades)
            {
                grade.DisplayGradeInfo();
            }
                
        }

    }
}