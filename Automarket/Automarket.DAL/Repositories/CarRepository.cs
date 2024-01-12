using Automarket.DAL.Interfaces;
using Automarket.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public async Task<bool> Create(Car entity)
        {
            if (entity != null)
            {
                await _dbContext.Cars.AddAsync(entity); 
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(Car entity)
        {
            if(entity != null)
            {
                _dbContext.Cars.Remove(entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Car>> GetAll()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task<Car> GetById(int id)
        {
            return await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _dbContext.Cars.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
