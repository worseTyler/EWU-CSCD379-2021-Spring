using System.Collections.Generic;
using System.Threading.Tasks;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public interface IGroupRepository
    {
        ICollection<Group> List();
        Task<Group?> GetItem(int id);
        Task<bool> Remove(int id);
        Task<Group> Create(Group item);
        Task Save(Group item);
        Task<AssignmentResult> GenerateAssignments(int groupId);
    }

}
