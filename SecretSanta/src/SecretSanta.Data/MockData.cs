using System.Collections.Generic;

namespace SecretSanta.Data
{
    public static class MockData
    {
        public static Dictionary<int, User> Users { get; } = new()
        {
            {
                0,
                new User
                {
                    Id = 0,
                    FirstName = "Inigo",
                    LastName = "Montoya"
                }
            },
            {
                1, 
                new User
                {
                    Id = 1,
                    FirstName = "Princess",
                    LastName = "Buttercup"
                }
            },
            {
                2,
                new User
                {
                    Id = 2,
                    FirstName = "Prince",
                    LastName = "Humperdink"
                }
            },
            {
                3,
                new User
                {
                    Id = 3,
                    FirstName = "Count",
                    LastName = "Rugen"
                }
            },
            {
                4,
                new User
                {
                    Id = 4,
                    FirstName = "Miracle",
                    LastName = "Max"
                }
            }
        };
    }
}
