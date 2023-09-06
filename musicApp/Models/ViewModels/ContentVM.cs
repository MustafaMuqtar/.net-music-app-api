namespace PodcastAPI.Models.ViewModels
{
    public class ContentVM
    {
        public string Title { get; set; }
        public string Gengre { get; set; }
        public string Description { get; set; }
        public IFormFile CoverImageURl { get; set; }
        public IFormFile AudioPlayerURL { get; set; }
        public List<int> CreatorIds { get; set; }
    }

    public class ContentWithCreatorVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Gengre { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public string CoverImageURl { get; set; }
        public string AudioPlayerURL { get; set; }
        public List<string> CreatorName { get; set; }
    }
}
