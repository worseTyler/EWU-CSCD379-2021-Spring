using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class UserRepository : IUserRepository
    {
        public List<User> List()
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
            UserList.Users.Add(item);
            return item;
        }

        public bool Update(int id, User item)
        {
            User? user = UserList.Users.Find(user => user.Id == id);
            if (user is not null)
            {
                int index = UserList.Users.IndexOf(user);
                UserList.Users[index] = item;
                return true;
            }
            return false;
        }
    }
}
