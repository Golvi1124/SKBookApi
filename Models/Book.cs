using System;
using System.ComponentModel.DataAnnotations;

namespace SKBookApi.Models;

public class Book
{
    [Key]
    public int id { get; set; }
    public int Year { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public int Pages { get; set; }
    public List<string> notes { get; set; } = new List<string>();
    public List<Villain> villains { get; set; } = new List<Villain>();
}