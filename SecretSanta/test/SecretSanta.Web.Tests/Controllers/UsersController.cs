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
    public class UsersController
    {
        private WebApplicationFactory Factory { get; } = new();

        [TestMethod]
        public async Task Index_WithEvents_InvokesGetAllAsync()
        {            
            UserDto fullUser = new(){ FirstName = "Tyler", LastName = "Jones", Id = 0 };
            UserDto emptyUser = new(){ FirstName = null, LastName = null, Id = null };
            List<UserDto> usersList = new(){fullUser, emptyUser};

            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();
            usersClient.GetAllUserDtosReturnValue = usersList;

            HttpResponseMessage response = await client.GetAsync("/Users/");

            response.EnsureSuccessStatusCode();
            Assert.AreEqual<int>(1, usersClient.GetAllAsyncInvocationCount);
        }

        [TestMethod]
        public async Task Create_WithValidModelState_InvokesPostAsync(){
            TestableUsersClient usersClient = Factory.Client;
            HttpClient client = Factory.CreateClient();
            // UserDto user = new(){ FirstName = "Tyler", LastName = null, Id = null };
            // string json = System.Text.Json.JsonSerializer.Serialize(user);
            // StringContent content = new(json);
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
    }
}
