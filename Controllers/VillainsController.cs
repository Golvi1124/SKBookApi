using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SKBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillainsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Villain>>> GetVillains([FromServices] DatabaseContext context)
        {
            return await context.Villains.ToListAsync();
        }

    }
}
