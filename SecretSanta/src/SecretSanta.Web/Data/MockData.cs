using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static Dictionary<int, List<GiftViewModel>> GiftsDictionary = new Dictionary<int, List<GiftViewModel>>
        {
            [0] = new List<GiftViewModel>{
              new GiftViewModel {Title = "Keyboard", Description = "A mechanical keyboard that goes click-clack", Url = "https://www.google.com/search?q=mechanical+keyboard", Priority = 1, User = "Tyler Jones"},
              new GiftViewModel {Title = "Model Digestive System", Description = "Life size model of the human digestive system", Url = "https://www.amazon.com/Doc-Royal-Digestive-Simulation-Medical-Anatomy/dp/B00WWTXNSS/ref=sr_1_2?dchild=1&keywords=life+size+digestive+system&qid=1618206645&sr=8-2", Priority = 1, User = "Tyler Jones"}
            },
            [1] = new List<GiftViewModel>{
              new GiftViewModel {Title = "Sack of Potatoes", Description = "A simple sack of potatoes", Url = "https://www.google.com/search?q=sack+o+potatoes", Priority = 1, User = "Mia Hunt"},
              new GiftViewModel {Title = "Monitor", Description = "27\" Dell monitor", Url = "https://www.amazon.com/Dell-backlit-Monitor-SE2719H-1080p/dp/B07KW6HFD1/ref=sr_1_3?dchild=1&keywords=27%22+dell+monitor&qid=1618206353&sr=8-3", Priority = 1, User = "Mia Hunt"}
            }
        };
        public static List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel {FirstName = "Tyler", LastName = "Jones", GroupName = "Super Duper Omega Astro Cool Giga Stomping Group", Id = 0, Gifts = GiftsDictionary[0]},
            new UserViewModel {FirstName = "Mia", LastName = "Hunt", GroupName = "Super Duper Omega Astro Cool Giga Stomping Group", Id = 1, Gifts = GiftsDictionary[1]}
        };

        public static List<GroupViewModel> Groups = new List<GroupViewModel>
        {
            new GroupViewModel {GroupName = Users[0].GroupName, Users=new List<UserViewModel>{Users[0], Users[1]} }
        };
    }
}
