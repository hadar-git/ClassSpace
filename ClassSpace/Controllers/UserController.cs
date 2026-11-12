using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User user = _userRepository.GetUser(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpGet("role/{role}")]
        public List<User> GetUsersByRole(Role role)
        {
            return _userRepository.GetUsersByRole(role);
        }

        [HttpPost]
        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        [HttpPut]
        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (!_userRepository.DeleteUser(id))
                return NotFound();
            return Ok();
        }
    }
}
