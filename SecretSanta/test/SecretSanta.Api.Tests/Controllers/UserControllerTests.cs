using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Api.Dto;
using SecretSanta.Api.Tests.Business;
using SecretSanta.Business;
using SecretSanta.Data;

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
            //Arrange
            UsersController usersController = new(new UserRepository());

            //Act
            IEnumerable<UserDto> users = usersController.Get();

            //Assert
            Assert.IsTrue(users.Any());
    	}
    	
        [TestMethod]
        [DataRow(0)]
        [DataRow(4)]
        public void Get_WithValidId_ReturnsUser(int id)
        {
            //Arrange
            TestableUserRepository userRepository = new();
            UsersController controller = new(userRepository);
            User expectedUser = new()
            {
                Id = id,
				FirstName = "name"
            };
            userRepository.GetItemUser = expectedUser;

            //Act
            ActionResult<UserDto?> result = controller.Get(id);

            //Assert
            Assert.AreEqual(id, userRepository.GetItemId);
            Assert.AreEqual(expectedUser.FirstName, result.Value.FirstName);
        }

        [TestMethod]
        [DataRow(-2)]
        [DataRow(10)]
        public void Get_WithInvalidId_ReturnsNotFound(int id)
        {
            //Arrange
            TestableUserRepository userRepository = new();
            UsersController usersController = new(userRepository);
            User expectedUser = new();
            userRepository.GetItemUser = expectedUser;

            //Act
            ActionResult<UserDto?> result = usersController.Get(id);

            //Assert
            Assert.IsTrue(result.Result is NotFoundResult);
        }

        [TestMethod]
        [DataRow(12)]
        [DataRow(20)]
        public void Delete_WithValidId_DeletesUser(int id)
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableUserRepository userRepository = factory.Manager;
            User foundUser = new User
            {
                Id = id
            };
            userRepository.GetItemUser = foundUser;
            UsersController usersController = new(userRepository);

            //Act
			ActionResult<UserDto?> result = usersController.Delete(id);

            //Assert
            Assert.IsTrue(result.Result is OkResult);
        }

        [TestMethod]
        [DataRow(12, -1)]
        [DataRow(20, 9)]
        public void Delete_WithInvalidId_ReturnsNotFound(int id, int invalidId)
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableUserRepository userRepository = factory.Manager;
            User foundUser = new User
            {
                Id = id
            };
            userRepository.GetItemUser = foundUser;
            UsersController usersController = new(userRepository);

            //Act
			ActionResult<UserDto?> result = usersController.Delete(invalidId);

            //Assert
            Assert.IsTrue(result.Result is NotFoundResult);
        }
        
        [TestMethod]
        [DataRow("Smeagle", "Precious")]
        [DataRow("Humpty", "Dumpty")]
        public async Task Post_WithValidData_UpdatesUser(string firstname, string lastname)
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableUserRepository userRepository = factory.Manager;
			UsersController usersController = new(userRepository);
			userRepository.UserList = new();
            UserDto newUser = new()
            {
                FirstName = firstname,
                LastName = lastname
            };

            HttpClient client = factory.CreateClient();

            //Act
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/users", newUser);
            response.EnsureSuccessStatusCode();
            
            //Assert
            Assert.AreEqual(firstname, userRepository.UserList[0].FirstName);
        }
        
        [TestMethod]
        public async Task Post_WithInvalidData_UpdatesUser()
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableUserRepository userRepository = factory.Manager;
            UserDto newUser = null!;

            HttpClient client = factory.CreateClient();

            //Act
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/users", newUser);
            
            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task Put_WithValidData_UpdatesUser()
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableUserRepository userRepository = factory.Manager;
            User foundUser = new User
            {
                Id = 3
            };
            userRepository.GetItemUser = foundUser;

            HttpClient client = factory.CreateClient();
            UserDto updateUser = new()
            {
                FirstName = "Jonah",
                LastName = "Ark"
            };

            //Act
            HttpResponseMessage response = await client.PutAsJsonAsync("/api/users/3", updateUser);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual("Jonah", userRepository.SavedUser?.FirstName);
        }

        [TestMethod]
        public async Task Put_WithValidIdInvalidData_ReturnsBadRequest()
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableUserRepository userRepository = factory.Manager;
            User foundUser = new User
			{
                Id = 3
            };
            userRepository.GetItemUser = foundUser;

            HttpClient client = factory.CreateClient();
            UserDto updateUser = null!;

            //Act
            HttpResponseMessage response = await client.PutAsJsonAsync("/api/users/3", updateUser);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode); 
        }

        [TestMethod]
        [DataRow(12, -1)]
        [DataRow(20, 9)]
        public async Task Put_WithInvalidIdValidData_ReturnsNotFound(int id, int invalidId)
        {
            //Arrange
            WebApplicationFactory factory = new();
            TestableUserRepository userRepository = factory.Manager;
            User foundUser = new User
			{
                Id = id
            };
            userRepository.GetItemUser = foundUser;

            HttpClient client = factory.CreateClient();
            UserDto updateUser = new()
            {
                FirstName = "Jonah",
                LastName = "Ark"
            };

            //Act
            HttpResponseMessage response = await client.PutAsJsonAsync("/api/users/"+invalidId, updateUser);

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode); 
        }

	}
}
