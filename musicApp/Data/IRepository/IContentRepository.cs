using PodcastAPI.Data.RequestHelpers;
using PodcastAPI.Models;
using PodcastAPI.Models.ViewModels;

namespace PodcastAPI.Data.IRepository
{
    public interface IContentRepository
    {
        Task<IQueryable<ContentWithCreatorVM>> GetAllAsync(ContentParams contentParams);
        Task<ContentWithCreatorVM> GetByIdAsync(int id);

        Task AddAsync(ContentVM data);

        Task DeleteByIdAsync(int id);

        Task<Content> UpdateByIdAsync(int id, ContentVM data);


    }
}
