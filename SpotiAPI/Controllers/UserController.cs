using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Spotify_DataLayer.Models;
using SpotiAPI.Service.Interfaces;

namespace SpotiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {





        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetSingleUser")]
        public ActionResult<User> GetSingle(int id)
        {
            var user = _userService.GetSingleUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request body");
            }
            try
            {
                _userService.CreateUser
                    (user.Username,
                    user.Password,
                    user.Email,
                    user.Setting



                    );
                return CreatedAtAction("GetSingleUser", new { id = user.Id_User }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = _userService.GetSingleUser(id);
            if (existingUser == null)
            {
                NotFound();
            }
            existingUser.Username = updatedUser.Username; 
            existingUser.Password = updatedUser.Password;
            existingUser.Email = updatedUser.Email;
            existingUser.Setting = updatedUser.Setting;
            

            _userService.UpdateUser(id, existingUser);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);

            if (result == "Item deleted")
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

    }
}
