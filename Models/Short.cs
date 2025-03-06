using System;
using System.ComponentModel.DataAnnotations;

namespace SKBookApi.Models;

public class ShortResponse
{
    public List<Short>? Data { get; set; }
}
public class Short
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? type { get; set; }
    public string? originallyPublishedIn { get; set; }
    public string? collectedIn { get; set; }
    public List<string>? notes { get; set; }
    public List<Villain>? villains { get; set; } 
}



