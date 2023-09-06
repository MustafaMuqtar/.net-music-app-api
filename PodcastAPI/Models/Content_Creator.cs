namespace PodcastAPI.Models
{
    public class Content_Creator
    {

        public int Id { get; set; }


        public int CreatorId { get; set; }
        public Creator Creator { get; set; }

        public int ContentId { get; set; }
        public Content Content { get; set; }


    }
}
