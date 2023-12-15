using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models;

public class Genre
{
  [Required]
  public string Name { get; set; }
  public int Id { get; set; }
}