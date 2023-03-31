using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceTest.Models
{
    public class ClassRoom
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ClassName { get; set; } = null!;

        public string TeacherName { get; set; } = null!;

        public ICollection<Student> Students { get; set; } = Enumerable.Empty<Student>().ToList();
    }
}
