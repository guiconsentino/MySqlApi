using Microsoft.AspNetCore.Mvc;
using MysqlApi.Model;
using MysqlApi.Repository;

namespace MysqlApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();

            if (users.Count() == 0)
                return NoContent();

            return Ok(users);
        }

        [HttpPost()]
        public IActionResult Post(User newUser)
        {
            var response = _userRepository.InsertUser(newUser);

            return Ok("number of lines affected "+response);
        }

        [HttpDelete()]

        public IActionResult Delete(int id)
        {
            var response = _userRepository.DeleteUser(id);

            return Ok("Users delete "+response);
        }
  
    
    }
}
