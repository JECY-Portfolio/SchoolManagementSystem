using System;
using System.Collections.Generic;

namespace School_Management_System.Helpers
{
    public static class ConsoleHelper
    {
        public static void DisplayHeader(string title)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine($"=                    {title}                =");
            Console.WriteLine("==========================================================================");
        }

        public static void DisplayStudentInfo(List<Student> students)
        {
            Console.WriteLine("| Student ID     | Name                  | Age | Grade Level     | GPA   |");
            Console.WriteLine("|----------------|-----------------------|-----|-----------------|-------|");

            foreach (var student in students)
            {
                Console.WriteLine($"| {student.StudentID,-16} | {student.Name,-21} | {student.Age,3} | {student.GradeLevel,-16} | {student.CalculateGPA()} |");
            }

            Console.WriteLine("=========================================================================");
        }

        public static void DisplayGradeInfo(List<Grade> grades)
        {
            Console.WriteLine("| Student ID     | Course ID      | Score    | GPA Value |");
            Console.WriteLine("|----------------|----------------|----------|-----------|");

            foreach (var grade in grades)
            {
                Console.WriteLine($"| {grade.StudentID,-16} | {grade.CourseID,-14} | {grade.Score,7:F1} | {grade.GradePoint} |");
            }

            Console.WriteLine("===============================================================");
        }

        public static void DisplayTeacherInfo(List<Teacher> teachers)
        {
            Console.WriteLine("| Teacher ID     | Name                  | Age | Department         |");
            Console.WriteLine("|----------------|-----------------------|-----|--------------------|");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"| {teacher.TeacherID,-16} | {teacher.Name,-21} | {teacher.Age,3} | {teacher.Department,-18} |");
            }

            Console.WriteLine("======================================================================");
        }

        public static void DisplayCourseInfo(List<Course> courses)
        {
            Console.WriteLine("| Course ID      | Course Name           | Credits |");
            Console.WriteLine("|----------------|-----------------------|---------|");

            foreach (var course in courses)
            {
                Console.WriteLine($"| {course.CourseID,-16} | {course.CourseName,-22} | {course.Credits,7} |");
            }

            Console.WriteLine("===========================================================");
        }

        public static void DisplayStudentCourseEnrollment(SchoolManager schoolManager)
        {
            foreach (var student in schoolManager.Students)
            {
                Console.WriteLine($"Student: {student.Name} ({student.StudentID})");
                foreach (var course in student.EnrolledCourses)
                {
                    Console.WriteLine($"  - {course.CourseName} ({course.CourseID})");
                }
                Console.WriteLine();
            }
        }

        public static void DisplayTeacherCourseAssignment(SchoolManager schoolManager)
        {
            foreach (var teacher in schoolManager.Teachers)
            {
                Console.WriteLine($"Teacher: {teacher.Name} ({teacher.TeacherID})");
                foreach (var course in teacher.AssignedCourses)
                {
                    Console.WriteLine($"  - {course.CourseName} ({course.CourseID})");
                }
                Console.WriteLine();
            }
        }

        public static void DisplayAllInformation(SchoolManager schoolManager)
        {
            DisplayHeader("School Management System");
            schoolManager.DisplaySchoolInfo();
            Console.WriteLine();

            DisplayHeader("Student Information");
            DisplayStudentInfo(schoolManager.Students);
            Console.WriteLine();

            DisplayHeader("Teacher Information");
            DisplayTeacherInfo(schoolManager.Teachers);
            Console.WriteLine();

            DisplayHeader("Course Information");
            DisplayCourseInfo(schoolManager.Courses);
            Console.WriteLine();

            DisplayHeader("Student Grades");
            foreach (var student in schoolManager.Students)
            {
                if (student.Grades.Count > 0)
                {
                    Console.WriteLine($"\nGrades for {student.Name} ({student.StudentID}):");
                    DisplayGradeInfo(student.Grades);
                }
            }
        }
    }
}


