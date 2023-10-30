using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
using Zxcvbn;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IuserService service;

        public UserController(IuserService service)
        {
            this.service = service;
        }
        //// GET: api/<UserController>
        [HttpGet]
        public ActionResult<User> Get([FromQuery] string email, [FromQuery] string password)
        {
           User user =  service.getUserByEmailandPassword(email, password);
            if(user == null)
             return NotFound();
            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public CreatedAtActionResult Post([FromBody] User user)
        {
            User newUser = service.addUser(user);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);


        }
        // POST api/<UserController>
        [HttpPost("check")]
        public ActionResult<int> Post([FromBody] string password)
        {
          return service.checkPassword(password);
           
        }

        //// PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            service.updetUser(id, userToUpdate);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
