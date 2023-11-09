namespace ModelFirst.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TeacherStudent> TeacherStudents { get; set; }
    }
}
