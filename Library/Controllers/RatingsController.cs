using Library.Domain.DTO.Rating;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        // PUT api/<RatingsController>/5
        [HttpPut]
        [Route("books/{id}/rate")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRatingDTO model)
        {
            if (!ModelState.IsValid || model.Score < 1 || model.Score > 5)
            {
                return BadRequest(ModelState);
            }
            var reviewId = await _ratingService.SaveRatingAsync(id, model);
            if (reviewId == -1)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
