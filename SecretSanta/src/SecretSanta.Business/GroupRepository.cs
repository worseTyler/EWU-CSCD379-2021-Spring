using System;
using System.Collections.Generic;
using SecretSanta.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DbContext DbContext;
        public GroupRepository(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Group> Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            await DbContext.Groups.AddAsync(item);
            await DbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Group?> GetItem(int id)
        {
            return await DbContext.Groups.FindAsync(id);
        }

        public ICollection<Group> List()
        {
            return DbContext.Groups.ToList();
        }

        public async Task<bool> Remove(int id)
        {
            Group group = DbContext.Groups.Find(typeof(Group), id);
            if(group is not null)
            {
                DbContext.Groups.Remove(group);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task Save(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (await Remove(item.GroupId))
            {
                await DbContext.Groups.AddAsync(item);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<AssignmentResult> GenerateAssignments(int groupId)
        {
            Group group = await DbContext.Groups.FindAsync(groupId);
            if (group is null)
            {
                return AssignmentResult.Error("Group not found");
            }

            Random random = new();
            var groupUsers = new List<User>(group.Users);

            if (groupUsers.Count < 3)
            {
                return AssignmentResult.Error($"Group {group.Name} must have at least three users");
            }

            var users = new List<User>();
            //Put the users in a random order
            while(groupUsers.Count > 0)
            {
                int index = random.Next(groupUsers.Count);
                users.Add(groupUsers[index]);
                groupUsers.RemoveAt(index);
            }
            //The assignments are created by linking the current user to the next user.
            group.Assignments.Clear();
            for(int i = 0; i < users.Count; i++)
            {
                int endIndex = (i + 1) % users.Count;
                group.Assignments.Add(new Assignment(){
                    Giver = users[i],
                    Receiver = users[endIndex]
                });
                await DbContext.Assignments.AddAsync(group.Assignments[i]);
                await DbContext.SaveChangesAsync();
            }
            return AssignmentResult.Success();
        }
    }
}
