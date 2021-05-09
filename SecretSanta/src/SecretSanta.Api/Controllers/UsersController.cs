﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business;

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
        public IEnumerable<Dto.User> Get()
        {
            return Repository.List().Select(x => ToDto(x)!);
        }

        [HttpGet("{id}")]
        public ActionResult<Dto.User?> Get(int id)
        {
            Dto.User? user = ToDto(Repository.GetItem(id));
            if (user is null) return NotFound();
            return user;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult Delete(int id)
        {
            if (Repository.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Dto.User), (int)HttpStatusCode.OK)]
        public ActionResult<Dto.User?> Post([FromBody] Dto.User user)
        {
            return ToDto(Repository.Create(FromDto(user)!));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult Put(int id, [FromBody] Dto.UpdateUser? user)
        {
            Data.User? foundUser = Repository.GetItem(id);
            if (foundUser is not null)
            {
                foundUser.FirstName = user.FirstName ?? "";
                foundUser.LastName = user.LastName ?? "";

                Repository.Save(foundUser);
                return Ok();
            }
            return NotFound();
        }

        private static Dto.User? ToDto(Data.User? user)
        {
            if (user is null) return null;
            return new Dto.User
            {
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName
            };
        }

        public static Data.User? FromDto(Dto.User? user)
        {
            if (user is null) return null;
            return new Data.User
            {
                Id = user.Id,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? ""
            };
        }
    }
}
