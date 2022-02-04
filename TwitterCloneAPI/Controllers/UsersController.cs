using Microsoft.AspNetCore.Mvc;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;
using TwitterCloneAPI.Repository;

namespace TwitterCloneAPI.Controllers
{
    [Route("api/users")]
    [Controller]
    public class UsersController : ControllerBase 
    {
        private readonly IRepository _repository;
        public UsersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            try
            {
                List<UserDTO> users = await _repository.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                UserDTO user = await _repository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateUserAsync(user);
                    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
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
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                User updatedUser = await _repository.UpdateUserAsync(id, user);

                if (updatedUser == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetUserById), new {id = updatedUser.Id}, updatedUser);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                bool delteSuccesfull = await _repository.DeleteUserAsync(id);
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
