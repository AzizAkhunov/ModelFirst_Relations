using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelFirst.AppDataAccess;
using ModelFirst.Models;

namespace ModelFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TeacherController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [HttpPost]
        public async ValueTask<bool> CreateTeacherAsync(string name)
        {
            var teacher = new Teacher();
            teacher.Name = name;
            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
            return true;
        }
        [HttpGet]
        public async ValueTask<IList<Teacher>> GetAllAsync()
        {
            IList<Teacher> teachers = await _db.Teachers.Include(x => x.TeacherStudents).ToListAsync();
            
            return teachers;
        }
        [HttpGet]
        public async ValueTask<Teacher> GetTeacherAsync(int id)
        {
            var teacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (teacher == null)
            {
                return teacher;
            }
            else
            {
                return new Teacher();
            }
        }
        [HttpDelete]
        public async ValueTask<bool> DeleteAsync(int id)
        {
            var teacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            _db.Teachers.Remove(teacher);
            await _db.SaveChangesAsync();
            return true;
        } 
    }
}
