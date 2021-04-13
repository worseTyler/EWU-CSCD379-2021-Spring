using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Data
{
    public static class MockData
    {
        public static List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel {FirstName = "Tyler", LastName = "Jones", GroupName = "Super Duper Omega Astro Cool Giga Stomping Group", Id = 0, Gifts =
                new List<GiftViewModel> {
                    new GiftViewModel {Title = "Keyboard", Description = "A mechanical keyboard that goes click-clack", Url = "https://www.amazon.com/Logitech-LIGHTSYNC-Mechanical-Keyboard-Switches/dp/B07QRGGCGP/ref=sxin_11?ascsubtag=amzn1.osa.a78a0d73-878e-457d-9a16-41bfbb6e632a.ATVPDKIKX0DER.en_US&creativeASIN=B07QRGGCGP&crid=1SUYFVTI711IQ&cv_ct_cx=mechanical+keyboard&cv_ct_id=amzn1.osa.a78a0d73-878e-457d-9a16-41bfbb6e632a.ATVPDKIKX0DER.en_US&cv_ct_pg=search&cv_ct_we=asin&cv_ct_wn=osp-single-source-earns-comm&dchild=1&keywords=mechanical+keyboard&linkCode=oas&pd_rd_i=B07QRGGCGP&pd_rd_r=030e2372-0acc-435c-be26-bf6a29754a96&pd_rd_w=vLFrZ&pd_rd_wg=aKB1A&pf_rd_p=e666d5aa-04ca-46aa-86b0-07ac28e037d4&pf_rd_r=NFN4912C6PZD4S4G07ZV&qid=1618294955&sprefix=mechanical+ke%2Caps%2C235&sr=1-1-64f3a41a-73ca-403a-923c-8152c45485fe&tag=reviewedoap-20", Priority = 1, Id = 0, UserId = 0},
                    new GiftViewModel {Title = "Model Digestive System", Description = "Life size model of the human digestive system", Url = "https://www.amazon.com/Doc-Royal-Digestive-Simulation-Medical-Anatomy/dp/B00WWTXNSS/ref=sr_1_2?dchild=1&keywords=life+size+digestive+system&qid=1618206645&sr=8-2", Priority = 2, Id = 1, UserId = 0}
                    }},
            new UserViewModel {FirstName = "Mia", LastName = "Hunt", GroupName = "Super Duper Omega Astro Cool Giga Stomping Group", Id = 1, Gifts =
                new List<GiftViewModel>{
                    new GiftViewModel {Title = "Sack of Potatoes", Description = "A simple sack of potatoes", Url = "https://www.etsy.com/listing/985787395/sack-of-potatoes?gpla=1&gao=1&", Priority = 1, Id = 0, UserId = 1},
                    new GiftViewModel {Title = "Monitor", Description = "27\" Dell monitor", Url = "https://www.amazon.com/Dell-backlit-Monitor-SE2719H-1080p/dp/B07KW6HFD1/ref=sr_1_3?dchild=1&keywords=27%22+dell+monitor&qid=1618206353&sr=8-3", Priority = 2, Id = 1, UserId = 1}
                }}
        };

        public static List<GroupViewModel> Groups = new List<GroupViewModel>
        {
            new GroupViewModel {GroupName = Users[0].GroupName, Users=new List<UserViewModel>{Users[0], Users[1]} }
        };
    }
}
