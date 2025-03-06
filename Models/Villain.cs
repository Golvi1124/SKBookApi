using System;
using System.ComponentModel.DataAnnotations;

namespace SKBookApi.Models;

public class VillainResponse
{
    public List<Villain>? Data { get; set; }
}

public class Villain
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? gender { get; set; }
    public string? status { get; set; }
    public List<string> notes { get; set; } = new();
    public List<Book> books { get; set; } = new();
    public List<Short> shorts { get; set; } = new();
}



