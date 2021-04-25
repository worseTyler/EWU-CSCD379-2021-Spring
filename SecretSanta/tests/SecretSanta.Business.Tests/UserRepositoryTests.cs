using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using SecretSanta.Business;
using SecretSanta.Data;

namespace SecretSanta.Business.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {

        [TestMethod]
        public void List_WhenCalled_ReturnsUserList()
        {
            Mock<IUserRepository> mockUserRepository = new();
            mockUserRepository.Setup(item => item.List())
            .Returns(new List<User>()
            {
                new User()
                {
                    FirstName = "fname",
                    LastName = "Doesn't Matter",
                    Id = 0
                }
            });
            
            Assert.AreEqual(1, mockUserRepository.Object.List().Count);
            Assert.AreEqual(UserList.Users.GetType(), mockUserRepository.Object.List().GetType());
            bool result = false;
            foreach (User user in mockUserRepository.Object.List())
            {
                if (user.FirstName == "fname")
                {
                    result = true;
                }
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetItem_GivenValidIndex_ReturnsCorrectUser()
        {
            User expectedUser = new()
            {
                FirstName = "Yes",
                LastName = "No",
                Id = 5
            };
            Mock<IUserRepository> mockUserRepository = new();
            mockUserRepository.Setup(item => item.GetItem(0))
            .Returns(expectedUser);

            Assert.AreEqual<User>(expectedUser, mockUserRepository.Object.GetItem(0));
        }

        [TestMethod]
        public void GetItem_GivenInValidIndex_ReturnsNull()
        {
            User expectedUser = new()
            {
                FirstName = "Yes",
                LastName = "No",
                Id = 5
            };
            Mock<IUserRepository> mockUserRepository = new();
            mockUserRepository.Setup(item => item.GetItem(0))
            .Returns(expectedUser);

            Assert.IsNull(mockUserRepository.Object.GetItem(3));
        }

        [TestMethod]
        public void Remove_GivenValidIndex_IsRemovedTrue()
        {
            Mock<IUserRepository> mockUserRepository = new();
            mockUserRepository.Setup(item => item.Remove(0))
            .Returns(true);

            Assert.IsTrue(mockUserRepository.Object.Remove(0));
        }

        [TestMethod]
        public void Remove_GivenInValidIndex_IsRemovedTrue()
        {
            Mock<IUserRepository> mockUserRepository = new();
            mockUserRepository.Setup(item => item.Remove(0))
            .Returns(true);

            Assert.IsFalse(mockUserRepository.Object.Remove(1));
        }

        [TestMethod]
        public void Create_WhenCalled_AddsNewUserToUserListWithItem()
        {
            User newUser = new()
            {
                FirstName = "New",
                LastName = "User",
                Id = 0
            };
            Mock<IUserRepository> mockUserRepository = new();
            mockUserRepository.Setup(item => item.Create(newUser)).Returns(newUser);

            Assert.AreEqual<User>(newUser, mockUserRepository.Object.Create(newUser));
            mockUserRepository.Verify(item => item.Create(newUser), Times.Once());
        }

        [TestMethod]
        public void Update_WhenCalled_UpdatesUserWithItem()
        {
            User updatedUser = new()
            {
                FirstName = "Updated",
                LastName = "User",
                Id = 0
            };

            Mock<IUserRepository> mockUserRepository = new();
            mockUserRepository.Setup(item => item.Update(updatedUser));
            mockUserRepository.Object.Update(updatedUser);

            mockUserRepository.Verify(item => item.Update(updatedUser), Times.Once());
        }
    }
}
