using PodcastAPI.Data.RequestHelpers;
using PodcastAPI.Models;
using PodcastAPI.Models.ViewModels;

namespace PodcastAPI.Data.IRepository
{
    public interface ICreatorRepository
    {
        Task<IEnumerable<CreatorWithContentVM>> GetAllAsync();
        Task<CreatorWithContentVM> GetByIdAsync(int id);

        Task AddAsync(CreatorVM data);

        Task DeleteByIdAsync(int id);

        Task<Creator> UpdateByIdAsync(int id, CreatorVM data);


    }
}
