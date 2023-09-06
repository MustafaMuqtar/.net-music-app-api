using CloudinaryDotNet.Actions;

namespace PodcastAPI.Data.IRepository
{
    public interface IPhotoRepository
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile formFile);
        Task<VideoUploadResult> AddAudioAsync(IFormFile formFile);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
