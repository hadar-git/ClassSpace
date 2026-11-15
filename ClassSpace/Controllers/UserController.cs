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
        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User user = userRepository.GetUser(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpGet("role/{role}")]
        public List<User> GetUsersByRole(Role role)
        {
            return userRepository.GetUsersByRole(role);
        }

        [HttpPost]
        public User AddUser(User user)
        {
            return userRepository.AddUser(user);
        }

        [HttpPut]
        public User UpdateUser(User user)
        {
            return userRepository.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (!userRepository.DeleteUser(id))
                return NotFound();
            return Ok();
        }
    }
}
