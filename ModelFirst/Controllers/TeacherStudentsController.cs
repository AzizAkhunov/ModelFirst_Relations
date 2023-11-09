using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelFirst.AppDataAccess;
using ModelFirst.Models;

namespace ModelFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherStudentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TeacherStudentsController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }
        [HttpGet]
        public async ValueTask<IList<TeacherStudent>> GetAll()
        {
            return await _db.TeacherStudents
                .Include(x => x.Teachers)
                .Include(x => x.Students)
                .ToListAsync();
        }
        [HttpPost]
        public async ValueTask<bool> CreateTeacherStudents(int teacherId, int studentId)
        {
            try
            {
                var teacherStudents = new TeacherStudent();
                teacherStudents.TeacherId = teacherId;
                teacherStudents.StudentId = studentId;

                await _db.TeacherStudents.AddAsync(teacherStudents);
                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
