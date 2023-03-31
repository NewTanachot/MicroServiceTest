using System.ComponentModel.DataAnnotations;

namespace MicroServiceTest.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string SubjectName { get; set; } = null!;

        public ICollection<Student> Students { get; set;} = Enumerable.Empty<Student>().ToList();
    }
}
