using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelFirst.AppDataAccess;
using ModelFirst.Models;

namespace ModelFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ChildrenController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }
        [HttpGet]
        public async ValueTask<IList<Child>> GetChildAsync()
        {
            return await _db.Children.ToListAsync();
        }
        [HttpGet]
        public async ValueTask<Child> GetByIdAsync(int id)
        {
            var child = await _db.Children.FirstOrDefaultAsync(x => x.Id == id);
            if(child is not null)
            {
                return child;
            }
            else return new Child();
        }
        [HttpPost]
        public async ValueTask<bool> CreateChildAsync(int fatherId)
        {
            try
            {
                var child = new Child();
                child.FatherId = fatherId;
                await _db.Children.AddAsync(child);
                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        public async ValueTask<bool> DeleteAsync(int id)
        {
            var child = await _db.Children.FirstOrDefaultAsync(x => x.Id == id);
            _db.Children.Remove(child);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
