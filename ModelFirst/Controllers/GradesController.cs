using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelFirst.AppDataAccess;
using ModelFirst.Models;

namespace ModelFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GradesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async ValueTask<IEnumerable<Grade>> GetAll()
        {
            return await _context.Grades.ToListAsync();
        }
        [HttpPost]
        public async ValueTask<bool> Create([FromForm]Grade grade)
        {
            try
            {

                await _context.Grades.AddAsync(grade);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
