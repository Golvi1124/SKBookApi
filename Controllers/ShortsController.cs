using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SKBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortsController : ControllerBase
    {
        [HttpGet]
public async Task<ActionResult<IEnumerable<Short>>> GetShorts([FromServices] DatabaseContext context)
{
    return await context.Shorts.ToListAsync();
}

    }
}
