using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SKBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromServices] DatabaseContext context)
{
    return await context.Books.ToListAsync();
}

    }
}

