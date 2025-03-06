using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SKBookApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly HttpClient _httpClient = new();

    protected async Task<T?> FetchData<T>(string url)
    {
        var response = await _httpClient.GetStringAsync(url);
        return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}