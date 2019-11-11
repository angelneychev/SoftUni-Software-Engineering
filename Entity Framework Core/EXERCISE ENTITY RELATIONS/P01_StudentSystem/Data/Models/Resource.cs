using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    using P01_StudentSystem.Data.Models.Enum;

    public class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        //public ICollection<StudentCourse> StudentsEnrolled { get; set; } = new HashSet<StudentCourse>();
        //public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
        //public ICollection<Homework> HomeworkSubmissions { get; set; } = new HashSet<Homework>();

    }
}
