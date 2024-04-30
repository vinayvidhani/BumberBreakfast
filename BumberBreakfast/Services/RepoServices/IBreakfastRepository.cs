using BumberBreakfast.Models.DatabaseModels;

namespace BumberBreakfast.Services.RepoServices
{
    public interface IBreakfastRepository
    {
        Task<ICollection<Breakfast>> GetAllBreakfast();
        Task<Breakfast> GetBreakfast(Guid id);
        Task CreateBreakfast(Breakfast breakfast);
        Task DeleteBreakfast(Guid id);
        Task<Breakfast> UpsertBreakfast(Guid id, Breakfast breakfast);
    }
}
