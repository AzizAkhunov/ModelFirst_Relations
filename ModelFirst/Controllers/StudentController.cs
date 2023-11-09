using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelFirst.AppDataAccess;
using ModelFirst.Models;

namespace ModelFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [HttpPost]
        public async ValueTask<bool> CreateTeacherAsync(string name)
        {
            try
            {
                var student = new Student();
                student.Name = name;
                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpGet]
        public async ValueTask<IList<Student>> GetAllAsync()
        {
            IList<Student> students = await _db.Students.ToListAsync();

            return students;
        }
        [HttpGet]
        public async ValueTask<Student> GetStudentAsync(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return student;
            }
            else
            {
                return new Student();
            }
        }
        [HttpDelete]
        public async ValueTask<bool> DeleteAsync(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
