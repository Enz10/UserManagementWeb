using System.Text.Json;

namespace UserManagementWeb.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    private void AddAuthorizationHeader()
    {
        var token = _httpContextAccessor.HttpContext.Request.Cookies["AuthToken"];
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<UserListResponse> GetUsersAsync(int page, int pageSize, int? age, string country)
    {
        AddAuthorizationHeader();
        var response = await _httpClient.GetAsync($"api/user?page={page}&pageSize={pageSize}&age={age}&country={country}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserListResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        AddAuthorizationHeader();
        var response = await _httpClient.GetAsync($"api/user/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UserDto>();
    }

    public async Task<UserDto> CreateUserAsync(UserDto user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/user", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UserDto>();
    }

    public async Task<IEnumerable<UserDto>> CreateUsersAsync(IEnumerable<UserDto> users)
    {
        var response = await _httpClient.PostAsJsonAsync("api/user/bulk-create", users);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
    }

    public async Task<UserDto> UpdateUserAsync(int id, UserDto user)
    {
        AddAuthorizationHeader();
        var response = await _httpClient.PutAsJsonAsync($"api/User/{id}", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UserDto>();
    }

    public async Task DeleteUserAsync(int id)
    {
        AddAuthorizationHeader();
        var response = await _httpClient.DeleteAsync($"api/user/{id}");
        response.EnsureSuccessStatusCode();
    }
}