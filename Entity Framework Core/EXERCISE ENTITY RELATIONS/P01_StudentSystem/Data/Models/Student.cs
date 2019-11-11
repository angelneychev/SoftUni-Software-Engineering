using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    using System;

    public class Student
    {
        public int StudentId{ get; set; }
        public string Name { get; set; }
        public string PhoneNumber  { get; set; }
        public string RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; } // ? null - not required

        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new HashSet<StudentCourse>();

        public ICollection<Homework> HomeworkSubmissions { get; set; } = new  HashSet<Homework>();

    }
}
