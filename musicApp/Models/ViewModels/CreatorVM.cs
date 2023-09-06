namespace PodcastAPI.Models.ViewModels
{
    public class CreatorVM
    {
        public string FullName { get; set; }
        public IFormFile ImageURL { get; set; }


    }


    public class CreatorWithContentVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public List<string> ContentImages { get; set; }
        public List<string> ContentAudios { get; set; }
        public List<string> ContentTitles { get; set; }

    }



}
