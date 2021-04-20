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
        public void Delete(int index)
        {
            if(!UserRepository.Remove(index))
           {
               System.Console.WriteLine("There was nothing at this index");
           }
        }

        // POST /api/users
        public void Post([FromBody] string userName)
        {
            var names = userName.Split(" ");
            User user = new () {
                FirstName = names[0],
                LastName = names[1],
                Id = UserRepository.List().Select(item => item.Id).Max()
            };
            UserRepository.Create(user);
        }
    }
}