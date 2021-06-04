using System.Collections.Generic;
using System.Threading.Tasks;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public interface IUserRepository
    {
        ICollection<User> List();
        Task<User?> GetItem(int id);
        Task<bool> Remove(int id);
        Task<User> Create(User item);
        Task Save(User item);
    }

}
