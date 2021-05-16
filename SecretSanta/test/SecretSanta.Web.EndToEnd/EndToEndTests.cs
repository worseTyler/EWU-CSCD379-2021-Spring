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
        public async Task CreateGift()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");
            var gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            int startingGifts = gifts.Count();
            await page.ClickAsync("text=Create");

            await page.TypeAsync("input#Title", "This");
            await page.TypeAsync("input#Description", "Jones");
            await page.TypeAsync("input#Url", "https://google.com");
            await page.TypeAsync("input#Priority", "1");
            await page.SelectOptionAsync("select#UserId", "1");

            await page.ClickAsync("text=Create");

            gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            int endingGifts = gifts.Count();
            Assert.AreEqual<int>(startingGifts + 1, endingGifts);
        }

        [TestMethod]
        public async Task UpdateGift()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");
            await page.WaitForSelectorAsync("body > section > section > section:last-child > a > section");
            await page.ClickAsync("body > section > section > section:last-child > a > section");

            await page.ClickAsync("input#Title", clickCount: 3);
            await page.TypeAsync("input#Title", "ThisIsATest");

            await page.ClickAsync("text=Update");
            await page.WaitForSelectorAsync("body > section > section > section:last-child");
            string lastGift = await page.GetTextContentAsync("body > section > section > section:last-child");

            Assert.IsTrue(lastGift.Contains("ThisIsATest"));
        }

        [TestMethod]
        public async Task DeleteUser()
        {
            var page = await Browser.NewPageAsync();
            var response = await page.GoToAsync(LocalHost);

            Assert.IsTrue(response.Ok);

            await page.ClickAsync("text=Gifts");
            var gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            int startingGifts = gifts.Count();

            page.Dialog += (_, args) => args.Dialog.AcceptAsync();

            await page.WaitForSelectorAsync("body > section > section > section:last-child > a > section > form > button");
            await page.ClickAsync("body > section > section > section:last-child > a > section > form > button");

            gifts = await page.QuerySelectorAllAsync("body > section > section > section");
            int endingGifts = gifts.Count();
            Assert.AreEqual<int>(startingGifts - 1, endingGifts);
        }
    }
}
