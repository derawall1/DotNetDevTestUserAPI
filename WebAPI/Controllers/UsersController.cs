using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _userService.GetUsersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);


            var createdUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();

            var result = await _userService.UpdateUserAsync(user);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}