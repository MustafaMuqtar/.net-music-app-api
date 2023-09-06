using Microsoft.EntityFrameworkCore;
using PodcastAPI.Data.Extentions;
using PodcastAPI.Data.IRepository;
using PodcastAPI.Data.RequestHelpers;
using PodcastAPI.Models;
using PodcastAPI.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PodcastAPI.Data.Services
{
    public class ContentService : IContentRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IPhotoRepository _photoRepository;

        public ContentService(AppDbContext appDbContext, IPhotoRepository photoRepository)
        {
            _appDbContext = appDbContext;
            _photoRepository = photoRepository;

        }

        public async Task AddAsync(ContentVM data)
        {
            var resultPhoto = await _photoRepository.AddPhotoAsync(data.CoverImageURl);
            var resultAudio = await _photoRepository.AddAudioAsync(data.AudioPlayerURL);

            var _data = new Content()
            {
                Title = data.Title,
                CoverImageURl = resultPhoto.Url.ToString(),
                AudioPlayerURL = resultAudio.Url.ToString(),
                Gengre = data.Gengre,
                Description = data.Description,



            };
            _data.PublicId = resultPhoto.PublicId;
            _data.PublicId = resultAudio.PublicId;
            await _appDbContext.Contents.AddAsync(_data);
            await _appDbContext.SaveChangesAsync();

            foreach (var id in data.CreatorIds)
            {
                var _data_creator = new Content_Creator()
                {
                    ContentId = _data.Id,
                    CreatorId = id,
                };
                await _appDbContext.Content_Creators.AddAsync(_data_creator);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task DeleteByIdAsync(int id)
        {
            var _data = await _appDbContext.Contents.FirstOrDefaultAsync(i => i.Id == id);

            if (_data != null)
            {

                if (!string.IsNullOrEmpty(_data.PublicId))
                {
                    await _photoRepository.DeletePhotoAsync(_data.PublicId);
                }
                _appDbContext.Contents.Remove(_data);
                await _appDbContext.SaveChangesAsync();

            }


        }

        public async Task<IQueryable<ContentWithCreatorVM>> GetAllAsync(ContentParams contentParams)
        {
            var query = _appDbContext.Contents.Select(data => new ContentWithCreatorVM()
            {
                Id = data.Id,
                Title = data.Title,
                CoverImageURl = data.CoverImageURl,
                AudioPlayerURL = data.AudioPlayerURL,
                Gengre = data.Gengre,
                Description = data.Description,
                CreatorName = data.Content_Creators.Select(n => n.Creator.FullName).ToList()
            }).Sort(contentParams.OrderBy)
                .Search(contentParams.SearchTerm)
                .Filter(contentParams.Gengre)
               .AsQueryable();
            return query;

        }

        public async Task<ContentWithCreatorVM> GetByIdAsync(int id)
        {
            var _data = await _appDbContext.Contents.Where(n => n.Id == id).Select(data => new ContentWithCreatorVM()
            {
                Id = data.Id,
                Title = data.Title,
                CoverImageURl = data.CoverImageURl,
                AudioPlayerURL = data.AudioPlayerURL,
                Gengre = data.Gengre,
                Description = data.Description,
                CreatorName = data.Content_Creators.Select(n => n.Creator.FullName).ToList()
            }).FirstOrDefaultAsync();

            return _data;
        }

        public async Task<Content> UpdateByIdAsync(int id, ContentVM data)
        {
            var _data = await _appDbContext.Contents.FirstOrDefaultAsync(i => i.Id == id);
            var resultPhoto = await _photoRepository.AddPhotoAsync(data.CoverImageURl);
            var resultAudio = await _photoRepository.AddAudioAsync(data.AudioPlayerURL);

            if (!string.IsNullOrEmpty(_data.PublicId))
            {
                await _photoRepository.DeletePhotoAsync(_data.PublicId);
            }

            if (_data != null)
            {
                _data.Title = data.Title;
                _data.CoverImageURl = resultPhoto.Url.ToString();
                _data.AudioPlayerURL = resultAudio.Url.ToString();
                _data.Gengre = data.Gengre;
                _data.Description = data.Description;
                _data.PublicId = resultPhoto.PublicId;
                _data.PublicId = resultAudio.PublicId;



                await _appDbContext.SaveChangesAsync();
            }


            return _data;


        }

    }
}
