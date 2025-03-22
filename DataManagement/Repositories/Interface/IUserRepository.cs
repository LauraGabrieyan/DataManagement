using DataManagement.Models;

namespace DataManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<UserResponse> UpdateUserAsync(UserResponse user);
    }
}
