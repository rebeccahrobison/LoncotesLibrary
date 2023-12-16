using System.ComponentModel.DataAnnotations;

namespace LoncotesLibrary.Models.DTOs;

public class PatronDTO
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
  public List<CheckoutDTO> Checkouts { get; set; }
  public List<CheckoutWithLateFeeDTO> CheckoutsWithLateFee { get; set; }
  public decimal? Balance
  {
    get
    {
      // total of unpaid fines a patron owes

      List<CheckoutDTO> unpaidCheckouts = Checkouts.Where(co => !co.Paid).ToList();
      List<CheckoutWithLateFeeDTO> unpaidCheckoutsWithFees = CheckoutsWithLateFee
        .Where(clf => unpaidCheckouts.Select(uc => uc.Id).Contains(clf.Id))
        .ToList();

      return unpaidCheckoutsWithFees
        .Where(uco => uco.LateFee.HasValue)
        .Sum(co => co.LateFee.Value);
    }
  }
}