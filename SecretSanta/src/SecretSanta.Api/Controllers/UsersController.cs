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
        [HttpGet("{index}")]
        public User Get(int index)
        {
            return UserRepository.GetItem(index);
        }

        //DELETE /api/users/<index>
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
           if (!UserRepository.Remove(index))
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

        [HttpPut("{index}")]
        public void Put (int index,[FromBody] User user){
            user.Id = index;
            UserRepository.Update(user);
        }
    }
}
