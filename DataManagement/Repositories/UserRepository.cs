using DataManagement.Models;
using DataManagement.Repositories.Interface;

namespace DataManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _connectionString;

        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _connectionString = "https://reqres.in";
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var url = $"{_connectionString}/api/users";

            var response = await _httpClient.PostAsJsonAsync(url, user);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }

            return null;
        }

        public async Task<UserResponse> UpdateUserAsync(UserResponse user)
        {
            var url = $"{_connectionString}/api/users/{user.Data.Id}";
            var response = await _httpClient.PutAsJsonAsync(url, user);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadFromJsonAsync<UserResponse>();
                return res;
            }

            return null;
        }
    }
}
