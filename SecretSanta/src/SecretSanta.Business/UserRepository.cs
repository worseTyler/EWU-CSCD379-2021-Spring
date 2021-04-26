using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class UserRepository : IUserRepository
    {
        public ICollection<User> List()
        {
            return UserList.Users;
        }

        public User? GetItem(int id)
        {
            return UserList.Users.Find(user => user.Id == id);
        }

        public bool Remove(int id)
        {
            User? user = UserList.Users.Find(user => user.Id == id);
            if (user is not null)
            {
                return UserList.Users.Remove(user);
            }
            return false;
        }

        public User Create(User item)
        {
            if (UserList.Users.Find(user => user.Id == item.Id) is null)
            {
                UserList.Users.Add(item);
                return item;
            }
            return null!;
        }

        public void Save(User item)
        {
            User? user = UserList.Users.Find(user => user.Id == item.Id);
            if (user is not null)
            {
                int index = UserList.Users.IndexOf(user);
                UserList.Users[index] = item;
            }
        }
    }
}
