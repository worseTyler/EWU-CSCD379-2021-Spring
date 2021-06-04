using System;

namespace SecretSanta.Data
{
    public class Assignment
    {
        public int AssignmentId {get; set;}
        public User Giver { get; set;}
        public User Receiver { get; set;}
    }
}
