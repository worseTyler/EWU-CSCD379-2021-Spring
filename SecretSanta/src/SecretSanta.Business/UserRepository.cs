using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class UserRepository : IUserRepository
    {
        private List<User> UsersList = new()
        {
            new User
            {
                FirstName = "Tyler",
                LastName = "Jones",
                Id = 0
            }
        };
        public ICollection<User> List()
        {
            return UsersList;
        }
        public User? GetItem(int id)
        {
            return UsersList[id];
        }
        public bool Remove(int id)
        {
            if (UsersList[id] != null)
            {
                UsersList.RemoveAt(id);
                return true;
            }
            return false;
        }
        public User Create(User item)
        {
            UsersList.Add(item);
            return item;
        }
        public void Save(User item)
        {
            UsersList[item.Id] = item;
        }
    }
}