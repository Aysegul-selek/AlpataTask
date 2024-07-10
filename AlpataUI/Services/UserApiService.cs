using AlpataCore.Entities.Concrete;
namespace AlpataUI.Services
{

    namespace AlpataTask.Services
    {
        public class UserApiService
        {
            private readonly HttpClient _httpClient;

            public UserApiService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<List<User>> GetUsersAsync()
            {
                var response = await _httpClient.GetFromJsonAsync<List<User>>("https://your-api-endpoint/api/users");
                return response;
            }

            public async Task<User> GetUserByIdAsync(int id)
            {
                var response = await _httpClient.GetFromJsonAsync<User>($"https://your-api-endpoint/api/users/{id}");
                return response;
            }

            
        }
    }

}
