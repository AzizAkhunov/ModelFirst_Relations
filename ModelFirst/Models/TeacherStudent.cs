using System.ComponentModel.DataAnnotations.Schema;

namespace ModelFirst.Models
{
    public class TeacherStudent
    {
        public int  Id { get; set; }

        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teachers { get; set; }

        [ForeignKey("StudentId")]
        public Student Students { get; set; }
    }
}
