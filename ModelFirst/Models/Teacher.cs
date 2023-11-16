namespace ModelFirst.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> TeacherStudents { get; set; }
    }
}
