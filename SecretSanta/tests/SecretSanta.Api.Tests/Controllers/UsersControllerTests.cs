using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Data;

namespace SecretSanta.Api.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        public void GetList_WhenCalled_ReturnsListofUsers()
        {
            string expectedString = "Actually Called";
            Mock<IUserRepository> mock = new();
            mock.Setup(item => item.List())
            .Returns(new List<User>()
            {
                new User()
                {
                    FirstName = expectedString,
                    LastName = "Doesn't Matter",
                    Id = 0
                }
            });
            UsersController usersController = new(mock.Object);

            Assert.AreEqual<string>(usersController.Get()[0].FirstName, expectedString);
        }
        [TestMethod]
        public void GetUser_GivenIndex_ReturnsUser()
        {
            User expectedUser = new()
            {
                FirstName = "Yes",
                LastName = "No",
                Id = 5
            };
            Mock<IUserRepository> mock = new();
            mock.Setup(item => item.GetItem(0))
            .Returns(expectedUser);

            UsersController usersController = new(mock.Object);

            Assert.AreEqual<User>(expectedUser, usersController.Get(0));
        }

        [TestMethod]
        public void Delete_GivenValidIndex_ReturnsOk()
        {
            Mock<IUserRepository> mock = new();
            mock.Setup(item => item.Remove(0))
            .Returns(true);

            UsersController usersController = new(mock.Object);

            Assert.IsTrue(usersController.Delete(0) is OkResult);
        }

        [TestMethod]
        public void Delete_GivenInValidIndex_ReturnsNoContent()
        {
            Mock<IUserRepository> mock = new();
            mock.Setup(item => item.Remove(0))
            .Returns(false);

            UsersController usersController = new(mock.Object);

            Assert.IsTrue(usersController.Delete(0) is NoContentResult);
        }

        [TestMethod]
        public void Post_GivenUser_CreateIsCalled()
        {
            User paramUser = new()
            {
                FirstName = "This will",
                LastName = "Be Added",
                Id = 0
            };
            Mock<IUserRepository> mock = new();
            mock.Setup(item => item.Create(paramUser)).Returns(paramUser);

            UsersController usersController = new(mock.Object);
            usersController.Post(paramUser);

            mock.Verify(item => item.Create(paramUser), Times.Once());
        }

        [TestMethod]
        public void Put_GivenParams_UpdateIsCalled()
        {
            User paramUser = new()
            {
                FirstName = "This will",
                LastName = "Be Added",
                Id = 0
            };
            Mock<IUserRepository> mock = new();
            mock.Setup(item => item.Update(0, paramUser));

            UsersController usersController = new(mock.Object);
            usersController.Put(0, paramUser);

            mock.Verify(item => item.Update(0, paramUser), Times.Once());
        }
    }

}
