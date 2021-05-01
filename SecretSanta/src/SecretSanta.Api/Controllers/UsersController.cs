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
        public IEnumerable<UpdateUser> Get()
        {
            return Repository.List().Select(user => new UpdateUser{
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? ""
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UpdateUser), StatusCodes.Status200OK)]
        public ActionResult<UpdateUser?> Get(int id)
        {
            User? user = Repository.GetItem(id);
            if (user is null) return NotFound();
            return new UpdateUser(){
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? ""
            };
        }

        [HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(UpdateUser), StatusCodes.Status200OK)]
        public ActionResult<UpdateUser?> Post([FromBody] UpdateUser? user)
        {
            if (user is null)
            {
                return BadRequest();
            }

            Repository.Create(new Data.User{
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Id = Repository.List().Select(item => item.Id).Max()
            });

            return user; // this feels wrong, im not entirely sure why I am wanting to return ActionResult<UpdateUser?>
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Put(int id, [FromBody] UpdateUser? user)
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
