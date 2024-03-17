using Microsoft.AspNetCore.Mvc;

namespace _6lr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase{

        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _usersService.GetUsers();
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Users user)
        {
            await _usersService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Users user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _usersService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usersService.DeleteUser(id);
            return NoContent();
        }
    }
}