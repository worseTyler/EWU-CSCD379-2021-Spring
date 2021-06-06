using System.Collections.Generic;
using SecretSanta.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Business
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext DbContext;

        public UserRepository(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }

        public async Task<User> Create(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            DbContext.Users.Add(item);
            await DbContext.SaveChangesAsync();
            return item;
        }

        public async Task<User?> GetItem(int id)
        {
            return await DbContext.Users.FindAsync(id);
        }

        public ICollection<User> List()
        {
            return DbContext.Users.ToList();
        }

        public async Task<bool> Remove(int id)
        {
            User? user = await GetItem(id);
            if(user is not null)
            {
                DbContext.Users.Remove(user);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<User>> GetAssignmentUsers(int id)
        {
            List<Assignment> assignments = DbContext.Assignments.Where(item => item.Giver.UserId == id).ToList();
            System.Console.WriteLine(assignments.Count());
            List<User> users = new();
            foreach(Assignment assignment in assignments)
            {
                if(assignment.Giver is null){
                    System.Console.WriteLine("This is null");
                } else{
                    System.Console.WriteLine(assignment.Giver.FirstName);
                }
                //User? user = await DbContext.Users.FindAsync(assignment.Receiver.UserId);
                // if(user is not null){
                //     users.Add(user);
                // }
            }
            return users;
        }
        public async Task Save(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }
            await Remove(item.UserId);
            DbContext.Users.Add(item);
            await DbContext.SaveChangesAsync();
        }
    }
}
