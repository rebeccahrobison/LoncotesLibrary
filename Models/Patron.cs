using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models;

public class Patron
{
  [Required]
  public string FirstName { get; set; }
  [Required]
  public string LastName { get; set; }
  [Required]
  public string Address { get; set; }
  [Required]
  public string Email { get; set; }
  [Required]
  public bool IsActive { get; set; }
  public int Id { get; set; }
  public List<Checkout> Checkouts { get; set; }
}