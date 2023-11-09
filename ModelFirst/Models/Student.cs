namespace ModelFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TeacherStudent> StudentTeacher { get; set; }
    }
}