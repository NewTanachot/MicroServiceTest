using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceTest.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string StudentName { get; set; } = null!;

        public StudentProfile? StudentProfile { get; set; }

        public Guid ClassRoomId { get; set; }

        public ClassRoom ClassRoom { get; set; } = null!;

        public ICollection<Subject> Subjects { get; set; } = Enumerable.Empty<Subject>().ToList();
    }
}
