using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceTest.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; } = null!;

        [Column(TypeName = "varchar(50)")]
        public string? FatherName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? MotherName { get; set; }
    }
}
