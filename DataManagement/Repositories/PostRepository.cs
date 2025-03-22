using DataManagement.Models;
using DataManagement.Repositories.Interface;

namespace DataManagement.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _connectionString;
        public PostRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _connectionString = "https://jsonplaceholder.typicode.com";
        }

        public async Task<bool> DeletePostByIdAsync(int id)
        {
            var url = $"{_connectionString}/posts/{id}";

            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var url = $"{_connectionString}/posts/{id}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var post = await response.Content.ReadFromJsonAsync<Post>();
                return post;
            }

            return null;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync(int? userId, string title)
        {
            var url = $"{_connectionString}/posts";

            if (userId.HasValue || !string.IsNullOrEmpty(title))
            {
                url += "?";
                if (userId.HasValue)
                    url += $"userId={userId.Value}&";
                if (!string.IsNullOrEmpty(title))
                    url += $"title={Uri.EscapeDataString(title)}";
            }

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var posts = await response.Content.ReadFromJsonAsync<IEnumerable<Post>>();
                return posts;
            }

            return null;
        }
    }
}
