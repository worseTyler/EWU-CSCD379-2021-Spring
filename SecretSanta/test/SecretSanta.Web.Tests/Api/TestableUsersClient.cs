using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SecretSanta.Web.Api;
using System.Linq;

namespace SecretSanta.Web.Tests.Api
{
    public class TestableUsersClient : IUsersClient
    {
        public List<UserDto> DeleteAsyncUsersList { get; set; } = new();
        public int DeleteAsyncInvocationCount { get; set; } = 0;
        public Task DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                DeleteAsyncInvocationCount++;
                DeleteAsyncUsersList.RemoveAt(id);
            });
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<UserDto> GetAllUserDtosReturnValue { get; set; } = new();
        public int GetAllAsyncInvocationCount { get; set; } = 0;
        public Task<ICollection<UserDto>?> GetAllAsync()
        {
            GetAllAsyncInvocationCount++;
            return Task.FromResult<ICollection<UserDto>?>(GetAllUserDtosReturnValue);
        }

        public Task<ICollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public UserDto? GetAsyncReturnValue { get; set; } = new();
        public int GetAsyncInvocationCounter { get; set; } = 0;
        public Task<UserDto?> GetAsync(int id)
        {
            GetAsyncInvocationCounter++;
            return Task.FromResult<UserDto?>(GetAsyncReturnValue);
        }

        public Task<UserDto> GetAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<UserDto> PostAsyncInvocationParameters { get; } = new();
        public int PostAsyncInvocationCounter { get; set; } = 0;
        public Task<UserDto> PostAsync(UserDto userDto)
        {
            PostAsyncInvocationCounter++;
            PostAsyncInvocationParameters.Add(userDto);
            return Task.FromResult(userDto);
        }

        public Task<UserDto> PostAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<UserDto> PutAsyncInvocationParameters { get; } = new();
        public int PutAsyncInvocationCounter { get; set; } = 0;
        public Task PutAsync(int id, UserDto userDto)
        {
            PutAsyncInvocationCounter++;
            PutAsyncInvocationParameters[id] = userDto;
            return Task.FromResult(userDto);
        }

        public Task PutAsync(int id, UserDto user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
