using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await userRepository.GetUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await userRepository.GetUserAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpGet("role/{role}")]
        public async Task<List<User>> GetUsersByRole(Role role)
        {
            return await userRepository.GetUsersByRoleAsync(role);
        }

        [HttpPost]
        public async Task<User> AddUser(User user)
        {
            return await userRepository.AddUserAsync(user);
        }

        [HttpPut]
        public async Task<User> UpdateUser(User user)
        {
            return await userRepository.UpdateUserAsync(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (!await userRepository.DeleteUserAsync(id))
                return NotFound();
            return Ok();
        }
    }
}