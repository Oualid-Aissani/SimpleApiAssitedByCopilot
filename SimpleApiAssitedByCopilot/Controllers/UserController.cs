using Microsoft.AspNetCore.Mvc;
using SimpleApiAssitedByCopilot.Models;
using System.Collections.Generic;

namespace SimpleApiAssitedByCopilot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<Users> users = new List<Users>();

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(new { users });
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
                var user = users.Find(u => u.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] Users newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest();
                }
                if (users.Where(i=>i.Id==newUser.Id).Any())
                {
                    return Conflict("User already exists.");
                }
                users.Add(newUser);
                return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] Users updatedUser)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = updatedUser.Name;
            user.Age = updatedUser.Age;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = users.Where(i => i.Id == id).FirstOrDefault();
                if (user == null)
                {
                    return BadRequest();

                }
                users.Remove(user);
                return NoContent();
            }catch(Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}

