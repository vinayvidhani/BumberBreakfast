using BumberBreakfast.Models.DatabaseModels;
using BumberBreakfast.Services.DbServices;
using Microsoft.EntityFrameworkCore;

namespace BumberBreakfast.Services.RepoServices
{
    public class BreakfastRepository : IBreakfastRepository
    {
        private readonly BreakfastDbContext breakfastDbContext;

        public BreakfastRepository(BreakfastDbContext breakfastDbContext)
        {
            this.breakfastDbContext = breakfastDbContext;
        }
        public async Task CreateBreakfast(Breakfast breakfast)
        {
            await breakfastDbContext.Breakfast.AddAsync(breakfast);
            await breakfastDbContext.SaveChangesAsync();
        }

        public async Task DeleteBreakfast(Guid id)
        {
            var breakfast = await breakfastDbContext.FindAsync<Breakfast>(id);
            if (breakfast != null)
            {
                breakfastDbContext.Breakfast.Remove(breakfast);
                await breakfastDbContext.SaveChangesAsync();
            }
            
        }

        public async Task<ICollection<Breakfast>> GetAllBreakfast()
        {
            return await breakfastDbContext.Breakfast.ToListAsync();
        }

        public async Task<Breakfast> GetBreakfast(Guid id)
        {
            return await breakfastDbContext.Breakfast.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Breakfast> UpsertBreakfast(Guid id, Breakfast breakfast)
        {
            var exsitingBreakfast = await breakfastDbContext.Breakfast.FindAsync(id);
            if (exsitingBreakfast is null)
                return null;
            breakfastDbContext.Entry<Breakfast>(breakfast).State = EntityState.Modified;
            await breakfastDbContext.SaveChangesAsync();
            return breakfast;
        }
    }
}
