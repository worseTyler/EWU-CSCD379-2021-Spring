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
        public string Title;
        [Required]
        public string Description;
        [Required]
        [Url]
        public string Url;
        [Required]
        public int Priority;
        [Required]
        public string User;
    }
}
