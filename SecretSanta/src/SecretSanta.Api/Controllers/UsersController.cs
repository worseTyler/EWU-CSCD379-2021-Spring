using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business;
using SecretSanta.Data;
using SecretSanta.Api.Dto;
using System.Linq;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository Repository { get; }

        public UsersController(IUserRepository repository)
        {
            Repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return Repository.List().Select(user => new UserDto{
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public ActionResult<UserDto?> Get(int id)
        {
            User? user = Repository.GetItem(id);
            if (user is null) return NotFound();
            return new UserDto(){
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Id = id
            };
        }

        [HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (Repository.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public ActionResult<UserDto?> Post([FromBody] UserDto? userDto)
        {
            if (userDto is null)
            {
                return BadRequest();
            }

            Repository.Create(new Data.User{
                FirstName = userDto.FirstName ?? "",
                LastName = userDto.LastName ?? "",
                Id = (Repository.List().Select(item => item.Id).Max() + 1)
            });

            return userDto;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Put(int id, [FromBody] UserDto? user)
        {
            if (user is null)
            {
                return BadRequest();
            }

            User? foundUser = Repository.GetItem(id);
            if (foundUser is not null)
            {
                foundUser.FirstName = user.FirstName ?? "";
                foundUser.LastName = user.LastName ?? "";

                Repository.Save(foundUser);
                return Ok();
            }
            return NotFound();
        }
    }
}
