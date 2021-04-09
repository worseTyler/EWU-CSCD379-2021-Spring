using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Web.ViewModels
{
    public class GroupViewModel
    {
        [Required]
        public string GroupName;

        public List<UserViewModel> Users;

        int Id {get; set;}
    }
}
