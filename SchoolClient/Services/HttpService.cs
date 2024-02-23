using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.JSInterop;
using School.Common.Models;
using School.Common.Models.TaskModels;

namespace SchoolClient.Services;

public class HttpService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IJSRuntime _jsRuntime;

    public HttpService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpContextAccessor = httpContextAccessor;
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task<string> AuthorizeApiRequest()
    {
        string token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        Console.WriteLine(token);
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("JWT token not found in request header.");
        }


        return $"Bearer {token}";
    }
    private IEnumerable<Claim> ParseToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
        return jsonToken?.Claims ?? new List<Claim>();
    }

    public async Task<IEnumerable<Claim>> GetClaims()
    {
        string token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        var claims = ParseToken(token);
        return claims;
    }
    public async Task<string> GetJwtToken()
    {
        string token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        
        return token;
    }

    public async Task<Guid> GetUserId()
    {
        string userIdString = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "userId");

        if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out Guid userId))
        {
            return userId;
        }
        return Guid.Empty;
    }

    public async Task<List<T>> GetEntitiesFromApi<T>(string apiUrl, object? obj = null)
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        if (obj is int)
        {
            request = new HttpRequestMessage(HttpMethod.Get, apiUrl + $"/{Convert.ToInt32(obj)}");
            request.Headers.Add("Authorization", await AuthorizeApiRequest());
        }

        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        List<T> entities = JsonConvert.DeserializeObject<List<T>>(responseBody) ?? new List<T>();
        Console.WriteLine(response.StatusCode);
        return entities;
    }

    public async Task<T> GetEntityFromApi<T>(string apiUrl, object? obj = null) where T : new()
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        if (obj is int)
        {
            request = new HttpRequestMessage(HttpMethod.Get, apiUrl + $"/{Convert.ToInt32(obj)}");
            request.Headers.Add("Authorization", await AuthorizeApiRequest());
        }

        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        T entity = JsonConvert.DeserializeObject<T>(responseBody) ?? new T();
        Console.WriteLine(response.StatusCode);
        return entity;
    }

    public async Task<HttpResponseMessage> UpdatePhoto(string url, IFormFile file)
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        var formData = new MultipartFormDataContent();
        formData.Add(new StreamContent(file.OpenReadStream()), "file", file.Name);
        var jsonContent = new StringContent(JsonConvert.SerializeObject(formData), Encoding.UTF8, "application/json");
        request.Content = jsonContent;
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return response;
    }

    public async Task<HttpResponseMessage> Post(string apiUrl, object obj)
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
        var jsonContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        request.Content = jsonContent;
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(response.StatusCode);
        return response;
    }

    public async Task<HttpResponseMessage> Update(string apiUrl, object obj)
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, apiUrl);
        var jsonContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        request.Content = jsonContent;
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(response.StatusCode);
        return response;
    }

    public async Task<List<TaskModel>> GetRelatedTasks(string apiUrl)
    {
        using var httpClient = new HttpClient();
        var userId = await GetUserId();
        var request = new HttpRequestMessage(HttpMethod.Post, apiUrl + $"/{userId}");
        var jsonContent = new StringContent(JsonConvert.SerializeObject(userId), Encoding.UTF8, "application/json");
        request.Content = jsonContent;
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        List<TaskModel> entities =
            JsonConvert.DeserializeObject<List<TaskModel>>(responseBody) ?? new List<TaskModel>();
        Console.WriteLine(response.StatusCode);
        return entities;
    }


    public async Task<UserModel> LogIn(string apiUrl, LoginUserModel entityToSend)
    {
        using var httpClient = new HttpClient();
        var jsonContent =
            new StringContent(JsonConvert.SerializeObject(entityToSend), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, jsonContent);

        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync();
        JObject responseJson = JObject.Parse(responseContent);
        string token = responseJson.Value<string>("token");

        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("Token not found in API response.");
        }

        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "token", token);
        var userModel = await GetProfile();
        return userModel;
    }

    public async Task<UserModel> GetProfile()
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7251/api/Users/profile");
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        UserModel entity = JsonConvert.DeserializeObject<UserModel>(responseBody) ?? new UserModel();
        Console.WriteLine(response.StatusCode);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "userId", entity.Id);
        return entity;
    }

    public async Task<string?> GetUserRole()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken( await GetJwtToken());

        // Get the claims from the JWT token
        var claims = jwtToken.Claims;

        // Find the user role claim
        var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

        if (roleClaim != null)
        {
            var userRole = roleClaim.Value;
            return userRole;
        }
        return null;
    }

    public async Task<Guid?> GetUserId(string text)
    {
        return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }

    public async Task LogoutAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", await GetJwtToken());
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", await GetUserId());
    }
}