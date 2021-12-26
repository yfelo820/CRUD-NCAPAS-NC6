using BusinesLogic.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComunicationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userService.GetUserById(id));            
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            return Ok(await _userService.AddUser(user));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            return Ok(await _userService.UpdateUser(user));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            return Ok(await _userService.DeleteUser(Id));
        }
    }
}
