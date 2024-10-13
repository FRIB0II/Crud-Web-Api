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

        [HttpPost]
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

        [HttpGet]
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

        [HttpPut]
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

        [HttpDelete]
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
    }
}
