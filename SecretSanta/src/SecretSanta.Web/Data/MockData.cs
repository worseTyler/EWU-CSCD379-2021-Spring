using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static Dictionary<string, List<GiftViewModel>> GiftsDictionary = new Dictionary<string, List<GiftViewModel>>
        {
            ["Tyler Jones"] = new List<GiftViewModel>{
              new GiftViewModel {Title = "Keyboard", Description = "A mechanical keyboard that goes click-clack", Url = "https://www.google.com/search?q=mechanical+keyboard", Priority = 1, User = "Tyler Jones"}
            },
            ["Mia Hunt"] = new List<GiftViewModel>{
              new GiftViewModel {Title = "Sack of Potatoes", Description = "A simple sack of potatoes", Url = "https://www.google.com/search?q=sack+o+potatoes", Priority = 1, User = "Mia Hunt"}
            }

        };
        public static List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel {FirstName = "Tyler", LastName = "Jones", GroupName = "Super Duper Cool Group", Id = 0, Gifts = GiftsDictionary["Tyler Jones"]},
            new UserViewModel {FirstName = "Mia", LastName = "Hunt", GroupName = "Super Duper Cool Group", Id = 1, Gifts = GiftsDictionary["Mia Hunt"]}
        };

        public static List<GroupViewModel> Groups = new List<GroupViewModel>
        {
            new GroupViewModel {GroupName = Users[0].GroupName, Users=new List<UserViewModel>{Users[0], Users[1]} }
        };
    }
}
