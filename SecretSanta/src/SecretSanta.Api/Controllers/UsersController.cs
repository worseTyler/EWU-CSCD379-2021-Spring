using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business;
using SecretSanta.Data;
using System.Linq;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepository UserRepository;

        public UsersController(IUserRepository userRepository) => UserRepository = userRepository;
        // /api/users
        [HttpGet]
        public List<User> Get()
        {
            return UserRepository.List().ToList();
        }

        // /api/users/<index>
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return UserRepository.GetItem(id);
        }

        //DELETE /api/users/<index>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           if (!UserRepository.Remove(id))
           {
               return NoContent();
           }
           return Ok();
        }

        // POST /api/users
        [HttpPost]
        public void Post([FromBody] User user)
        {
            UserRepository.Create(user);
        }

        [HttpPut("{id}")]
        public void Put (int id,[FromBody] User user){
            UserRepository.Update(id, user);
        }
    }
}
