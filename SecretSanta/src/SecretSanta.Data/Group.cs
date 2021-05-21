﻿using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<User> Users { get; } = new();
        public List<Assignment> Assignments { get; set; } = new();
    }
}
