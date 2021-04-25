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
            return UserList.Users[id];
        }
        public bool Remove(int id)
        {
            if (UserList.Users[id] != null)
            {
                UserList.Users.RemoveAt(id);
                return true;
            }
            return false;
        }
        public User Create(User item)
        {
            UserList.Users.Add(item);
            return item;
        }
        public void Update(User item)
        {
            UserList.Users[item.Id] = item;
        }
    }
}
