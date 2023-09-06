namespace PodcastAPI.Models
{
    public class Creator
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public string? PublicId { get; set; }


        public List<Content_Creator> Content_Creators { get; set; }
    }
}
