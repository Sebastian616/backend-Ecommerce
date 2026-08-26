using Microsoft.AspNetCore.Mvc;
using OrbisaApi.Data.Models;
using OrbisaApi.Data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }

        // GET api/<UserController>/5
        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetById(string uuid)
        {
            var user = await _userService.GetById(uuid);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            var response = await _userService.CreateUser(user);
            return Ok(response);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
