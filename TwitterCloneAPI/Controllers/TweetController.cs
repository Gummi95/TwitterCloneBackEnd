using Microsoft.AspNetCore.Mvc;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;
using TwitterCloneAPI.Repository;

namespace TwitterCloneAPI.Controllers
{
    [Route("api/tweets")]
    [Controller]
    public class TweetController : ControllerBase
    {
        private readonly IRepository _repository;
        public TweetController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tweet>>> GetAllTweets()
        {
            try
            {
                
                List<TweetDTO> tweets = await _repository.GetAllTweetsAsync();
                return Ok(tweets);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Tweet>> GetTweetById(int id)
        {
            try
            {
                TweetDTO comment = await _repository.GetTweetByIdAsync(id);

                if (comment == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(comment);
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateTweet(Tweet tweet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateTweetAsync(tweet);
                    return CreatedAtAction(nameof(GetTweetById), new { id = tweet.Id }, tweet);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Tweet>> UpdateTweet(int id, [FromBody] Tweet tweet)
        {
            try
            {
                Tweet updatedTweet = await _repository.UpdateTweetAsync(id, tweet);

                if (updatedTweet == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTweetById), new { id = updatedTweet.Id }, updatedTweet);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Tweet>> DeleteTweet(int id)
        {
            try
            {
                bool delteSuccesfull = await _repository.DeleteTweetAsync(id);
                if (!delteSuccesfull)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}

