using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SKBookApi.Controllers;

    public class ShortsController : BaseApiController
{
    private const string ApiUrl = "https://stephen-king-api.onrender.com/api/shorts";


[HttpGet]
public async Task<IActionResult> GetShorts()
{
    var shortResponse = await FetchData<ShortResponse>(ApiUrl);

    if (shortResponse == null || shortResponse.Data == null)
        return NotFound("No books found.");

    return Ok(shortResponse.Data);
}

/*     [HttpGet]
    public async Task<IActionResult> GetShorts()
    {
        var shorts = await FetchData<List<Short>>(ApiUrl);
        return shorts != null ? Ok(shorts) : NotFound("No shorts found.");
    } */
}
