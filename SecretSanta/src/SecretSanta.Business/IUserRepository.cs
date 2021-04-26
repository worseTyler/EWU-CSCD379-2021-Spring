using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public interface IUserRepository
    {
        List<User> List();
        User? GetItem(int id);
        bool Remove(int id);
        User Create(User item);
        bool Update(int id, User item);
    }
}
