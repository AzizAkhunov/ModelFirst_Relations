using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelFirst.AppDataAccess;
using ModelFirst.Models;

namespace ModelFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FathersController
    {
        private readonly AppDbContext _db;

        public FathersController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [HttpGet]
        public async ValueTask<IList<Father>> GetFathersAsync()
        {
            return await _db.Fathers.Include(x => x.Children).ToListAsync();
        }
        [HttpGet]
        public async ValueTask<Father> GetByIdAsync(int id)
        {
            var father = await _db.Fathers.FirstOrDefaultAsync(x => x.Id == id);

            return father; 
        }
        [HttpPost]
        public async ValueTask<bool> CreateFather()
        {
            try
            {
                var father = new Father();

                await _db.Fathers.AddAsync(father);
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
            var father = await _db.Fathers.FirstOrDefaultAsync(x => x.Id == id);

            _db.Remove(father);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
