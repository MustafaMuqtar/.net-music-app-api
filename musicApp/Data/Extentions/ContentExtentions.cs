using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using PodcastAPI.Models;
using PodcastAPI.Models.ViewModels;

namespace PodcastAPI.Data.Extentions
{
    public static class ContentExtentions
    {

        public static IQueryable<ContentWithCreatorVM> Sort(this IQueryable<ContentWithCreatorVM> queryContent, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return queryContent.OrderBy(p => p.Title);




            queryContent = orderBy switch
            {
                "price" => queryContent.OrderBy(p => p.DateAdded),
                "priceDescending" => queryContent.OrderByDescending(p => p.DateAdded),
                _ => queryContent.OrderBy(p => p.Title)
            };
            return queryContent;
        }


        public static IQueryable<ContentWithCreatorVM> Search(this IQueryable<ContentWithCreatorVM> queryContent, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return queryContent;
            };
            var loweCaseSearchTerm = searchTerm.Trim().ToLower();

            return queryContent.Where(p => p.Title.ToLower().Contains(loweCaseSearchTerm));
        }

        public static IQueryable<ContentWithCreatorVM> Filter(this IQueryable<ContentWithCreatorVM> queryFilter, string genre)
        {

            var categoryList = new List<string>();
            var brandList = new List<string>();
            var colorList = new List<string>();
            if (!string.IsNullOrEmpty(genre))
            {
                categoryList.AddRange(genre.ToLower().Split(",").ToList());
            };
            queryFilter = queryFilter.Where(p => categoryList.Count == 0 || categoryList.Contains(p.Gengre.ToLower()));

            return queryFilter;



        }

    }
}
