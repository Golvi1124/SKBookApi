using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SKBookApi.Controllers;
public class VillainsController : BaseApiController
{
    private const string ApiUrl = "https://stephen-king-api.onrender.com/api/villains";

[HttpGet]
public async Task<IActionResult> GetVillains()
{
    var villainResponse = await FetchData<VillainResponse>(ApiUrl);

    if (villainResponse == null || villainResponse.Data == null)
        return NotFound("No books found.");

    return Ok(villainResponse.Data);
}
}

