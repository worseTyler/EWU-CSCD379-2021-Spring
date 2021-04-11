using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Web.ViewModels
{
    public class GiftViewModel
    {
        [Required]
        public string Title {get; set;} = "";
        [Required]
        public string Description {get; set;} = "";
        [Required]
        [Url]
        public string Url {get; set;} = "";
        [Required]
        public int Priority {get; set;}
        public string User {get; set;}
        [Display(Name = "User")]
        public int UserId {get; set;}
        public int Id {get; set;}
    }
}
