using Microsoft.AspNetCore.Mvc;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;
using TwitterCloneAPI.Repository;

namespace TwitterCloneAPI.Controllers
{
    [Route("api/comments")]
    [Controller]
    public class CommentController : ControllerBase
    {
            private readonly IRepository _repository;
            public CommentController(IRepository repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<ActionResult<List<Comment>>> GetAllComments()
            {
                try
                {
                    List<CommentDTO> comments = await _repository.GetAllCommentsAsync();
                    return Ok(comments);
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            [HttpGet]
            [Route("{id}")]
            public async Task<ActionResult<Comment>> GetCommentById(int id)
            {
                try
                {
                    CommentDTO comment = await _repository.GetCommentByIdAsync(id);

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
            public async Task<IActionResult> CreateComment(Comment comment)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        await _repository.CreateCommentAsync(comment);
                        return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
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
            public async Task<ActionResult<Comment>> UpdateComment(int id, [FromBody] Comment comment)
            {
                try
                {
                    Comment updatedComment = await _repository.UpdateCommentAsync(id, comment);

                    if (updatedComment == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return CreatedAtAction(nameof(GetCommentById), new { id = updatedComment.Id }, updatedComment);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<ActionResult<Comment>> DeleteComment(int id)
            {
                try
                {
                    bool delteSuccesfull = await _repository.DeleteCommentAsync(id);
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

