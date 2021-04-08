﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Web.ViewModels
{
    public class Group
    {
        [Required]
        public string GroupName;

        public List<User> Users;
    }
}
