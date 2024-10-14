using Crud_Web_Api.Models;
using Crud_Web_Api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("createUser/{user}")]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("O usuário não pode ser vazio!");
            }
            else
            {
                await _userRepository.CreateUser(user);
                return Ok(user);
            }
        }

        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            UserModel user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound("Usuário não encontrado!");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPut("updateUser/{user}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("O usuário não pode ser vazio!");
            }
            else
            {
                await _userRepository.UpdateUser(user);
                return Ok(user);
            }
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            UserModel response = await _userRepository.DeleteUser(id);

            if (response == null)
            {
                return NotFound("Usuário não encontrado!");
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("getUsers/")]
        public async Task<ActionResult<UserModel>> GetUsers()
        {
           List<UserModel> users = await _userRepository.GetAllUsers();
           return Ok(users);
        }
    }
}
