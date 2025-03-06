using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class BookResponse
{
    public List<Book>? Data { get; set; }
}

public class Book
{
    public int id { get; set; }
    public int Year { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public int Pages { get; set; }
    public List<string>? Notes { get; set; }
    public List<Villain>? Villains { get; set; }
}

public class Villain
{
    public string? Name { get; set; }
    public string? Url { get; set; }
}
