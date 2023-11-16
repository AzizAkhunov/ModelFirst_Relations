using System.ComponentModel.DataAnnotations.Schema;

namespace ModelFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}