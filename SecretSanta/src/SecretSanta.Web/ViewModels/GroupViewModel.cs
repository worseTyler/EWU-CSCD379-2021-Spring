using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Web.ViewModels
{
    public class GroupViewModel
    {
        [Display(Name = "Group Name")]
        [Required]
        public string GroupName {get; set;} = "";

        public List<UserViewModel> Users;

        public int Id {get; set;}
    }
}
