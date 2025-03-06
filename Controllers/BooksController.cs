using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SKBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SKBookApi.Controllers;
public class BooksController : BaseApiController
{
    private const string ApiUrl = "https://stephen-king-api.onrender.com/api/books";

[HttpGet]
public async Task<IActionResult> GetBooks()
{
    var bookResponse = await FetchData<BookResponse>(ApiUrl);

    if (bookResponse == null || bookResponse.Data == null)
        return NotFound("No books found.");

    return Ok(bookResponse.Data);
}

    /* [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await FetchData<List<Book>>(ApiUrl);
        return books != null ? Ok(books) : NotFound("No books found.");
    } */
}