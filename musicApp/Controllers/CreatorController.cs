using Microsoft.AspNetCore.Mvc;
using PodcastAPI.Data.IRepository;
using PodcastAPI.Models.ViewModels;

namespace PodcastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ControllerBase
    {
        private readonly ICreatorRepository _creatorRepository;

        public CreatorController(ICreatorRepository creatorRepository)
        {
            _creatorRepository = creatorRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var _data = await _creatorRepository.GetAllAsync();
            return Ok(_data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var _data = await _creatorRepository.GetByIdAsync(id);
            return Ok(_data);
        }

        [HttpPost]
        public async Task<IActionResult> AddASync([FromForm][FromBody] CreatorVM data)
        {

            //if (!ModelState.IsValid) return ViewResult(data);
            await _creatorRepository.AddAsync(data);




            return Ok(data);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateByIdAsync(int id, [FromForm][FromBody] CreatorVM data)
        {
            await _creatorRepository.GetByIdAsync(id);
            var _data = await _creatorRepository.UpdateByIdAsync(id, data);

            return Ok(_data);

        }




        [HttpDelete("{id}")]


        public async Task<IActionResult> DeleteByIdAsync(int id)
        {


            var _data = await _creatorRepository.GetByIdAsync(id);
            //if (_data == null) return View("NotFound");

            await _creatorRepository.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
