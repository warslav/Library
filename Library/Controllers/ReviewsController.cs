using Library.Domain.DTO.Review;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // PUT api/<ReviewsController>/5
        [HttpPut]
        [Route("books/{id}/review")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReviewDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviewId = await _reviewService.SaveReviewAsync(id, model);
            if (reviewId == -1)
            {
                return NotFound();
            }
            return Ok(reviewId);
        }
        
    }
}
