using MicroServiceTest.Data;
using MicroServiceTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFCoreController : ControllerBase
    {
        private readonly DatabaseContext context;

        public EFCoreController(DatabaseContext context)
        {
            this.context = context;
        }

        // ==== Student ====

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStudent(bool profileInclude = false, bool subjectInclude = false, bool classroomInclude = false)
        {
            var queryData = context.Student.AsQueryable();

            if (profileInclude)
            {
                queryData = queryData
                    .Include(x => x.StudentProfile)
                    .AsNoTracking();
            }

            if (subjectInclude)
            {
                queryData = queryData
                    .Include(x => x.Subjects)
                    .AsNoTracking();
            }

            if (classroomInclude)
            {
                queryData = queryData
                    .Include(x => x.ClassRoom)
                    .AsNoTracking();
            }

            return Ok(await queryData.ToListAsync());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostStudent(string name, string classroom, string subject1, string subject2)
        {
            var newStudent = new Student
            {
                StudentName = name,
                ClassRoom = await context.ClassRoom.FirstAsync(x => x.ClassName == classroom),
                Subjects = new List<Subject>
                {
                    await context.Subject.FirstAsync(x => x.SubjectName == subject1),
                    await context.Subject.FirstAsync(x => x.SubjectName == subject2),
                },
                StudentProfile = new StudentProfile
                {
                    FatherName = $"{name}_Father",
                    MotherName = $"{name}_Mother"
                }
            };

            await context.Student.AddAsync(newStudent);
            await context.SaveChangesAsync();

            return Created("PostStudent", newStudent);
        }

        // ==== Profile ====

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProfile(bool isInclude = false)
        {
            if (isInclude)
            {
                return Ok(await context.StudentProfile.Include(x => x.Student)
                    .AsNoTracking()
                    .ToListAsync());
            }
            else
            {
                return Ok(await context.StudentProfile.ToListAsync());
            }
        }

        // ==== Subject ====

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSubject(bool isInclude = false)
        {
            if (isInclude)
            {
                return Ok(await context.Subject.Include(x => x.Students)
                    .AsNoTracking()
                    .ToListAsync());
            }
            else
            {
                return Ok(await context.Subject.ToListAsync());
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostSubject(string name)
        {
            var newSubject = new Subject
            {
                SubjectName = name,
            };

            await context.Subject.AddAsync(newSubject);
            await context.SaveChangesAsync();

            return Created("PostSubject", newSubject);
        }

        // ==== Classroom ====

        [HttpGet("[action]")]
        public async Task<IActionResult> GetClassroom(bool isInclude = false)
        {
            if (isInclude)
            {
                return Ok(await context.ClassRoom
                    .Include(x => x.Students)
                    .AsNoTracking()
                    .ToListAsync());
            }
            else
            {
                return Ok(await context.ClassRoom.ToListAsync());
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostClassroom(string name)
        {
            var newClassroom = new ClassRoom
            {
                ClassName = name,
                TeacherName = $"Teacher_{name}"
            };

            await context.ClassRoom.AddAsync(newClassroom);
            await context.SaveChangesAsync();

            return Created("PostClassroom", newClassroom);
        }

    }
}
