using MicroServiceTest.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceTest.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }

        public DbSet<StudentProfile> StudentProfile { get; set; }

        public DbSet<ClassRoom> ClassRoom { get; set; }

        public DbSet<Subject> Subject { get; set; }
    }
}
