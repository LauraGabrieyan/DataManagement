using DataManagement.Models;
using DataManagement.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DataManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] User newUser)
        {
            var createdUser = await _userRepository.CreateUserAsync(newUser);

            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int id, [FromBody] UserResponse newUser)
        {
            var updatedUser = await _userRepository.UpdateUserAsync(newUser);
            return Ok(updatedUser);

        }
    }
}
