/* Implement Data Fetching and Storage (Manual Trigger)
You'll need a service to fetch data from the Stephen King API and store it in SQLite. */

using System.Net.Http;
using System.Text.Json;
using SKBookApi.Models;

public class DataSeeder
{
    private readonly DatabaseContext _context;
    private readonly HttpClient _httpClient;

    public DataSeeder(DatabaseContext context)
    {
        _context = context;
        _httpClient = new HttpClient();
    }

    public async Task SeedData()
    {
        if (_context.Books.Any() || _context.Shorts.Any() || _context.Villains.Any())
        {
            return; // Data already exists, no need to fetch again
        }

        var books = await FetchData<List<Book>>("https://stephen-king-api.onrender.com/api/books");
        var shorts = await FetchData<List<Short>>("https://stephen-king-api.onrender.com/api/shorts");
        var villains = await FetchData<List<Villain>>("https://stephen-king-api.onrender.com/api/villains");

        if (books != null) _context.Books.AddRange(books);
        if (shorts != null) _context.Shorts.AddRange(shorts);
        if (villains != null) _context.Villains.AddRange(villains);

        await _context.SaveChangesAsync();
    }

    private async Task<T?> FetchData<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) return default;
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json);
    }
}
