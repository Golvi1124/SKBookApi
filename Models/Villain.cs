using System;
using System.ComponentModel.DataAnnotations;

namespace SKBookApi.Models;

public class Villain
{
    [Key]
    public int id { get; set; }
    public string? name { get; set; }
    public string? gender { get; set; }
    public string? status { get; set; }
    public List<string> notes { get; set; } = new List<string>();
    public List<Book> books { get; set; } = new List<Book>();
    public List<Short> shorts { get; set; } = new List<Short>();

}



