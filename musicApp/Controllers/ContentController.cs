using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PodcastAPI.Data;
using PodcastAPI.Data.Extentions;
using PodcastAPI.Data.IRepository;
using PodcastAPI.Data.RequestHelpers;
using PodcastAPI.Models;
using PodcastAPI.Models.ViewModels;

namespace PodcastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : Controller
    {
        private readonly AppDbContext _appDbContext;

        private readonly IContentRepository _contentRepository;

        public ContentController(IContentRepository contentRepository, AppDbContext appDbContext)
        {
            _contentRepository = contentRepository;
            _appDbContext = appDbContext;
        }



        [HttpGet]
        public async Task<ActionResult<PagedList<ContentWithCreatorVM>>> GetAllAsync([FromQuery] ContentParams contentParams)
        {
            var _data = await _contentRepository.GetAllAsync(contentParams);

            var products = await PagedList<ContentWithCreatorVM>.ToPagedList(_data, contentParams.PageNumber, contentParams.PageSize);

            Response.AddPaginationHeader(products.MetaData);


            return products;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var _data = await _contentRepository.GetByIdAsync(id);


            return Ok(_data);
        }


        [HttpPost]
        public async Task<IActionResult> AddASync([FromForm] ContentVM data)
        {

            if (!ModelState.IsValid) return View(data);
            await _contentRepository.AddAsync(data);


            return Ok(data);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateByIdAsync(int id, [FromForm][FromBody] ContentVM data)
        {
            var _data = await _contentRepository.UpdateByIdAsync(id, data);

            return Ok(_data);

        }




        [HttpDelete("{id}")]


        public async Task<IActionResult> DeleteByIdAsync(int id)
        {


            var _data = await _contentRepository.GetByIdAsync(id);
            if (_data == null) return View("NotFound");

            await _contentRepository.DeleteByIdAsync(id);
            return Ok();
        }


        [HttpGet("filters")]
        public async Task<IActionResult> GetFiltersAsync()
        {
            var gengre = await _appDbContext.Contents.Select(p => p.Gengre).Distinct().ToListAsync();


            return Ok(new { gengre });

        }


    }
}
