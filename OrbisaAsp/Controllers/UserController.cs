//Cristian Ramirez
using Microsoft.AspNetCore.Mvc;
using OrbisaApi.Data.Models;
using OrbisaApi.Data.Services;

namespace OrbisaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }

        // GET api/user/{uuid}
        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetById(string uuid)
        {
            var user = await _userService.GetById(uuid);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            try
            {
                var response = await _userService.CreateUser(user);
                if (response)
                {
                    return Created();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            
        }

        // PUT api/user/{uuid}
        [HttpPut("{uuid}")]
        public async Task<ActionResult> Put(string uuid, [FromBody] User user)
        {
            try
            {
                var response = await _userService.UpdateUser(uuid, user);
                if (response)
                {
                    return Created();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/user/{uuid}
        [HttpDelete("{uuid}")]
        public async Task<ActionResult> Delete(string uuid)
        {
            try
            {
                var response = await _userService.DeleteUser(uuid);
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
