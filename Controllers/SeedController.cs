using Microsoft.AspNetCore.Mvc;
using SKBookApi.Models;
using System.Text.Json;

namespace SKBookApi.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class SeedController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly HttpClient _httpClient;

    public SeedController(DatabaseContext context)
    {
        _context = context;
        _httpClient = new HttpClient();
    }

    [HttpGet]
    public async Task<IActionResult> Seed()
    {
        string booksJson = await _httpClient.GetStringAsync("https://stephen-king-api.onrender.com/api/books");

        // Print the raw JSON to the console (check your terminal logs)
        Console.WriteLine("RAW JSON RESPONSE:");
        Console.WriteLine(booksJson);

        try
        {
            List<Book>? books = JsonSerializer.Deserialize<List<Book>>(booksJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (books == null)
                return BadRequest("Failed to deserialize books.");

            // Save to database
            _context.Books.AddRange(books);
            await _context.SaveChangesAsync();

            return Ok("Database seeded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            return StatusCode(500, "Internal Server Error: " + ex.Message);
        }
    }
}

}
/* 
Now, you can manually trigger the data fetch by calling:
POST http://localhost:5226/api/seed
from Postman or a browser.
 */