using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using SecretSanta.Web.Api;
using SecretSanta.Web.Tests.Api;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;
using SecretSanta.Web.ViewModels;


namespace SecretSanta.Web.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        private WebApplicationFactory Factory { get; } = new();

        [TestMethod]
        public async Task Index_WithEvents_InvokesGetAllAsync()
        {
            UserDto fullUser = new() { FirstName = "Tyler", LastName = "Jones", Id = 0 };
            UserDto emptyUser = new() { FirstName = null, LastName = null, Id = null };
            List<UserDto> usersList = new() { fullUser, emptyUser };

            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();
            usersClient.GetAllUserDtosReturnValue = usersList;

            HttpResponseMessage response = await client.GetAsync("/Users/");

            response.EnsureSuccessStatusCode();
            Assert.AreEqual<int>(1, usersClient.GetAllAsyncInvocationCount);
        }

        [TestMethod]
        public async Task CreatePost_WithValidModelState_InvokesPostAsync()
        {
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            // UserDto user = new(){ FirstName = "Tyler", LastName = null, Id = null };
            // string json = System.Text.Json.JsonSerializer.Serialize(user);
            // StringContent content = new(json);
            // We did this in class to make a json string but when I used it it didn't seem to be actually sending it to the web controllers Create parameters

            Dictionary<string, string?> values = new()
            {
                { nameof(UserViewModel.FirstName), "Tyler" }
            };
            FormUrlEncodedContent content = new(values!);

            HttpResponseMessage response = await client.PostAsync("/Users/Create", content);

            response.EnsureSuccessStatusCode();
            Assert.AreEqual<int>(1, usersClient.PostAsyncInvocationCounter);
            Assert.IsTrue(usersClient.PostAsyncInvocationParameters
                            .Select(item => item.FirstName)
                            .Contains("Tyler"));
        }

        [TestMethod]
        public async Task EditPost_WithValidModelState_InvokesPutAsync()
        {
            string firstName = "Tyler";
            int id = 0;

            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            usersClient.PutAsyncInvocationParameters.Add(new UserDto()
                { FirstName = firstName + ", Just Kidding", Id = id });

            Dictionary<string, string?> values = new()
            {
                { nameof(UserViewModel.FirstName), firstName },
                { nameof(UserViewModel.Id), id.ToString() },
            };
            FormUrlEncodedContent content = new(values!);

            HttpResponseMessage response = await client.PostAsync("/Users/Edit", content);

            response.EnsureSuccessStatusCode();
            Assert.AreEqual<int>(1, usersClient.PutAsyncInvocationCounter);
            Assert.IsTrue(usersClient.PutAsyncInvocationParameters
                .Select(item => item.FirstName)
                .Contains("Tyler"));
        }
        [TestMethod]
        public async Task EditGet_WithValidId_InvokesGetAsync(){
            UserDto user = new() { FirstName = "Tyler", Id = 0 };

            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            usersClient.GetAsyncReturnValue = user;

            HttpResponseMessage response = await client.GetAsync("/Users/Edit/0");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual<int>(1, usersClient.GetAsyncInvocationCounter);
            Assert.AreEqual<string>("Tyler", usersClient.GetAsyncReturnValue.FirstName);
        }


        [TestMethod]
        public async Task Delete_GivenPositiveId_InvokesDelete(){
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            List<UserDto> usersList = new(){
                new UserDto {FirstName = "Tyler", Id = 0},
                new UserDto {FirstName = "Smells", Id = 1},
                new UserDto {FirstName = "Bad", Id = 2}
            };

           usersClient.DeleteAsyncUsersList = usersList;

           HttpResponseMessage response = await client.PostAsync("/Users/Delete/2", new StringContent("{}"));

           response.EnsureSuccessStatusCode();

           Assert.AreEqual<int>(1, usersClient.DeleteAsyncInvocationCount);
           Assert.IsFalse(usersClient.DeleteAsyncUsersList
                    .Select(item => item.FirstName)
                    .Contains("Bad"));
        }

        [TestMethod]
        public async Task Delege_GivenNegativeId_DoesNotInvokeDelete ()
        {
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();

            List<UserDto> usersList = new()
            {
                new UserDto { FirstName = "Tyler", Id = 0 },
                new UserDto { FirstName = "Smells", Id = 1 },
                new UserDto { FirstName = "Bad", Id = 2 }
            };

            usersClient.DeleteAsyncUsersList = usersList;

            HttpResponseMessage response = await client.PostAsync("/Users/Delete/-1", new StringContent("{}"));

            response.EnsureSuccessStatusCode();

            Assert.AreEqual<int>(0, usersClient.DeleteAsyncInvocationCount);
            Assert.IsTrue(usersClient.DeleteAsyncUsersList
                     .Select(item => item.FirstName)
                     .Contains("Bad"));
        }

        // I have no clue how to test such that the ModelState would be invalid
        // However, there are no instances where ModelState is invalid and our Web and Api projects
        // communicated with each other so I don't think it's super important considering what we
        // are testing here
    }
}
