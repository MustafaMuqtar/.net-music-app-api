using Microsoft.EntityFrameworkCore;
using PodcastAPI.Data.Extentions;
using PodcastAPI.Data.IRepository;
using PodcastAPI.Data.RequestHelpers;
using PodcastAPI.Models;
using PodcastAPI.Models.ViewModels;

namespace PodcastAPI.Data.Services
{
    public class CreatorService : ICreatorRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPhotoRepository _photoRepository;

        public CreatorService(AppDbContext appDbContext, IPhotoRepository photoRepository)
        {
            _appDbContext = appDbContext;
            _photoRepository = photoRepository;

        }

        public async Task AddAsync(CreatorVM data)
        {
            var resultPhoto = await _photoRepository.AddPhotoAsync(data.ImageURL);


            var _data = new Creator()
            {
                FullName = data.FullName,
                ImageURL = resultPhoto.Url.ToString(),

            };
            _data.PublicId = resultPhoto.PublicId;
            await _appDbContext.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var _data = await _appDbContext.Creators.FirstOrDefaultAsync(i => i.Id == id);

            if (_data != null)
            {

                if (!string.IsNullOrEmpty(_data.PublicId))
                {
                    await _photoRepository.DeletePhotoAsync(_data.PublicId);
                }
                _appDbContext.Creators.Remove(_data);
                await _appDbContext.SaveChangesAsync();

            }


        }

        public async Task<IEnumerable<CreatorWithContentVM>> GetAllAsync()
        {

            var _data = await _appDbContext.Creators.Select(data => new CreatorWithContentVM()
            {
                Id = data.Id,
                FullName = data.FullName,
                ImageURL = data.ImageURL,
                ContentImages = data.Content_Creators.Select(n => n.Content.CoverImageURl).ToList(),
                ContentAudios = data.Content_Creators.Select(n => n.Content.AudioPlayerURL).ToList(),
                ContentTitles = data.Content_Creators.Select(n => n.Content.Title).ToList()
            }).ToListAsync();

            return _data;

        }

        public async Task<CreatorWithContentVM> GetByIdAsync(int id)
        {
            var _data = await _appDbContext.Creators.Where(n => n.Id == id).Select(data => new CreatorWithContentVM()
            {
                Id = data.Id,
                FullName = data.FullName,
                ImageURL = data.ImageURL,


                ContentImages = data.Content_Creators.Select(n => n.Content.CoverImageURl).ToList(),
                ContentAudios = data.Content_Creators.Select(n => n.Content.AudioPlayerURL).ToList(),
                ContentTitles = data.Content_Creators.Select(n => n.Content.Title).ToList()
            }).FirstOrDefaultAsync();

            return _data;
        }

        public async Task<Creator> UpdateByIdAsync(int id, CreatorVM data)
        {
            var _data = await _appDbContext.Creators.FirstOrDefaultAsync(i => i.Id == id);
            var resultPhoto = await _photoRepository.AddPhotoAsync(data.ImageURL);

            if (!string.IsNullOrEmpty(_data.PublicId))
            {
                await _photoRepository.DeletePhotoAsync(_data.PublicId);
            }

            if (_data != null)
            {
                _data.FullName = data.FullName;
                _data.ImageURL = resultPhoto.Url.ToString();

                _data.PublicId = resultPhoto.PublicId;

                await _appDbContext.SaveChangesAsync();
            }

            return _data;


        }

    }
}
