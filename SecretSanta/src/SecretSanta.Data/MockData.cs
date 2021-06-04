using System.Collections.Generic;

namespace SecretSanta.Data
{
    public static class MockData
    {
        static MockData()
        {
            PutUserInGroup(Users[1], Groups[1]);
            PutUserInGroup(Users[2], Groups[1]);
            PutUserInGroup(Users[3], Groups[2]);
            PutUserInGroup(Users[4], Groups[2]);
            PutUserInGroup(Users[5], Groups[1]);

            static void PutUserInGroup(User user, Group group)
            {
                user.Groups.Add(group);
                group.Users.Add(user);
            }
        }


        public static Dictionary<int, User> Users { get; } = new()
        {
            {
                1,
                new User
                {
                    UserId = 1,
                    FirstName = "Inigo",
                    LastName = "Montoya"
                }
            },
            {
                2,
                new User
                {
                    UserId = 2,
                    FirstName = "Princess",
                    LastName = "Buttercup"
                }
            },
            {
                3,
                new User
                {
                    UserId = 3,
                    FirstName = "Prince",
                    LastName = "Humperdink"
                }
            },
            {
                4,
                new User
                {
                    UserId = 4,
                    FirstName = "Count",
                    LastName = "Rugen"
                }
            },
            {
                5,
                new User
                {
                    UserId = 5,
                    FirstName = "Miracle",
                    LastName = "Max"
                }
            }
        };

        public static Dictionary<int, Group> Groups { get; } = new()
        {
            {
                1,
                new Group
                {
                    GroupId = 1,
                    Name = "IntelliTect Christmas Party"
                }
            },
            {
                2,
                new Group
                {
                    GroupId = 2,
                    Name = "Friends"
                }
            }
        };
    }
}
