using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructor_GivenNullUserRepository_ThrowsArgumentNullException()
		{
			UsersController usersController = new(null!);
		}

		[TestMethod]
        public void Get_WithData_ReturnsUsers(){
    	}
	}
}
