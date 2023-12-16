using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models;

public class Checkout
{
  public int Id { get; set; }
  [Required]
  public int MaterialId { get; set; }
  [Required]
  public int PatronId { get; set; }
  [Required]
  public DateTime CheckoutDate { get; set; }
  public DateTime? ReturnDate { get; set; }
  public Material Material { get; set; }
  public Patron Patron { get; set; }
  public bool Paid { get; set; }
}





  // private static decimal _lateFeePerDay = .50M;
  // public decimal? LateFee
  // {
  //   get
  //   {
  //     DateTime dueDate = CheckoutDate.AddDays(Material.MaterialType.CheckoutDays);
  //     if(ReturnDate != null && dueDate < ReturnDate)
  //     {
  //       int daysLate = ((DateTime)ReturnDate - dueDate).Days;
  //       decimal fee = daysLate * _lateFeePerDay;
  //       return fee;
  //     }
  //   }
  // }