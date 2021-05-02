using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SecretSanta.Web.Api;

namespace SecretSanta.Web.Tests.Api
{
    public class TestableUsersClient : IUsersClient
    {
        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
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

        public Task<UserDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> GetAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public List<UserDto> PostAsyncInvocationParameters {get;} = new();
        public int PostAsyncInvocationCounter {get; set;} = 0;
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

        public Task PutAsync(int id, UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task PutAsync(int id, UserDto user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}