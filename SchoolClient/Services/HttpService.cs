using Newtonsoft.Json;
using SchoolData.Models.SubjectModels;
using System.Net.Http.Headers;
using SchoolData.Models;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.JSInterop;
using SchoolData.Models.TaskModels;

namespace SchoolClient.Services;

public  class HttpService
{
     private  readonly HttpClient _httpClient ;
     private readonly IHttpContextAccessor _httpContextAccessor;
     private readonly IJSRuntime _jsRuntime;

    public HttpService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient, IJSRuntime jsRuntime)
     {
         _httpContextAccessor = httpContextAccessor;
         _httpClient = httpClient;
         _jsRuntime = jsRuntime;
     }

    public  async Task<string> AuthorizeApiRequest()
    {
        string token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        Console.WriteLine(token);
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("JWT token not found in request header.");
        }


        return $"Bearer {token}";
    }

    public async Task<Guid> GetUserId()
    {
        Guid userId = await _jsRuntime.InvokeAsync<Guid>("localStorage", "userId");
        return userId;
    }
    public   async Task<List<SubjectModelByAdmin>> GetEntitiesFromApi(string apiUrl)
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
        request.Headers.Add("Authorization",await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode(); 

        string responseBody = await response.Content.ReadAsStringAsync();
        List<SubjectModelByAdmin> entities = JsonConvert.DeserializeObject<List<SubjectModelByAdmin>>(responseBody) ?? new List<SubjectModelByAdmin>();
        Console.WriteLine(response.StatusCode);
        return entities;
    }

    public async Task<List<TaskModel>> GetRelatedTasks(string apiUrl)
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, apiUrl); 
        var jsonContent = new StringContent(JsonConvert.SerializeObject(await GetUserId()), Encoding.UTF8, "application/json");
        request.Content = jsonContent;
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        List<TaskModel> entities = JsonConvert.DeserializeObject<List<TaskModel>>(responseBody) ?? new List<TaskModel>();
        Console.WriteLine(response.StatusCode);
        return entities;
    }


    public  async Task<UserModel> LogIn(string apiUrl, LoginUserModel entityToSend)
    {

        using var httpClient = new HttpClient();
        var jsonContent = new StringContent(JsonConvert.SerializeObject(entityToSend), Encoding.UTF8, "application/json");
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
        var userModel =  await GetProfile();
        return userModel;
    }

    public async Task<UserModel> GetProfile()
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7251/api/Users/profile");
        var jsonContent = new StringContent(JsonConvert.SerializeObject(await GetUserId()), Encoding.UTF8, "application/json");
        request.Content = jsonContent;
        request.Headers.Add("Authorization", await AuthorizeApiRequest());
        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        UserModel entity = JsonConvert.DeserializeObject<UserModel>(responseBody) ?? new UserModel();
        Console.WriteLine(response.StatusCode);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "userId", entity.UserId);
        return entity;
    }
}