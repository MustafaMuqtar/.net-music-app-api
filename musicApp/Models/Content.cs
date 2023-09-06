using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PodcastAPI.Data.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace PodcastAPI.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Gengre { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string CoverImageURl { get; set; }
        public string AudioPlayerURL { get; set; }
        public string? PublicId { get; set; }
        public List<Content_Creator> Content_Creators { get; set; }

    }
}


