using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;
using System.Linq;

namespace SecretSanta.Web.EndToEnd
{
    [TestClass]
    public class EndToEndTests
    {
        private static WebHostServerFixture<Web.Startup, SecretSanta.Api.Startup> Server;
        private static IPlaywright PlaywrightObj;
        private static PlaywrightSharp.Chromium.IChromiumBrowser Browser;
        private static string LocalHost = "";

        [ClassInitialize]
        public static async Task InitializeClass(TestContext testContext)
        {
            Server = new();
            LocalHost = Server.WebRootUri.AbsoluteUri.Replace("127.0.0.1", "localhost");
            PlaywrightObj = await Playwright.CreateAsync();
            Browser = await PlaywrightObj.Chromium.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
        }
        [ClassCleanup]
        public static async Task CleanupClass()
        {
            PlaywrightObj.Dispose();
            await Browser.DisposeAsync();
        }

        [TestMethod]
        public async Task ValidateHomepage()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            var headerContent = await page.GetTextContentAsync("body > header > div > a");
            Assert.AreEqual("Secret Santa", headerContent);
        }

        [TestMethod]
        public async Task NavigateBetweenPages()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");   
            Assert.AreEqual<string>(LocalHost + "Users", page.Url);         
            await page.ClickAsync("text=Gifts"); 
            Assert.AreEqual<string>(LocalHost + "Gifts", page.Url);      
            await page.ClickAsync("text=Groups");                     
            Assert.AreEqual<string>(LocalHost + "Groups", page.Url);    
        }

        [TestMethod]
        public async Task CreateUser()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");
            var speakers = await page.QuerySelectorAllAsync("body > section > section > section");
            int startingSpeakers = speakers.Count();
            await page.ClickAsync("text=Create");

            await page.TypeAsync("input#FirstName", "Tyler");
            await page.TypeAsync("input#LastName", "Jones");

            await page.ClickAsync("text=Create");

            speakers = await page.QuerySelectorAllAsync("body > section > section > section");
            int endingSpeakers = speakers.Count();
            Assert.AreEqual<int>(startingSpeakers + 1, endingSpeakers);
        }

        [TestMethod]
        public async Task UpdateUser()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");
            await page.ClickAsync("body > section > section > section:last-child > a > section");

            await page.ClickAsync("input#FirstName", clickCount: 3);
            await page.TypeAsync("input#FirstName", "ThisIsATest");
            await page.ClickAsync("input#LastName", clickCount: 3);
            await page.TypeAsync("input#LastName", "Name");

            await page.ClickAsync("text=Update");
            string lastSpeaker = await page.GetTextContentAsync("body > section > section > section:last-child");

            Assert.IsTrue(lastSpeaker.Contains("ThisIsATest Name"));
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Users");
            var speakers = await page.QuerySelectorAllAsync("body > section > section > section");
            int startingSpeakers = speakers.Count();

            page.Dialog += (_, args) => args.Dialog.AcceptAsync();

            await page.ClickAsync("body > section > section > section:last-child > a > section > form > button");

            speakers = await page.QuerySelectorAllAsync("body > section > section > section");
            int endingSpeakers = speakers.Count();
            Assert.AreEqual<int>(startingSpeakers - 1, endingSpeakers);
        }
    }
}
