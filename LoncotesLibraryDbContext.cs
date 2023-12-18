using Microsoft.EntityFrameworkCore;
using LoncotesLibrary.Models;

public class LoncotesLibraryDbContext : DbContext
{

  public DbSet<Checkout> Checkouts { get; set; }
  public DbSet<Genre> Genres { get; set; }
  public DbSet<Material> Materials { get; set; }
  public DbSet<MaterialType> MaterialTypes { get; set; }
  public DbSet<Patron> Patrons { get; set; }

  public LoncotesLibraryDbContext(DbContextOptions<LoncotesLibraryDbContext> context) : base(context)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Genre>().HasData(new Genre[]
    {
      new Genre {Id = 1, Name = "Nonfiction"},
      new Genre {Id = 2, Name = "Fiction"},
      new Genre {Id = 3, Name = "Reference"},
      new Genre {Id = 4, Name = "Biography"},
      new Genre {Id = 5, Name = "Literature"},
    });
    modelBuilder.Entity<Material>().HasData(new Material[]
    {
      new Material {Id = 1, MaterialName = "Persuasion", MaterialTypeId = 1, GenreId = 5, OutofCirculationSince = null},
      new Material {Id = 2, MaterialName = "The Dictionary", MaterialTypeId = 1, GenreId = 3, OutofCirculationSince = null},
      new Material {Id = 3, MaterialName = "Interstellar", MaterialTypeId = 2, GenreId = 2, OutofCirculationSince = null},
      new Material {Id = 4, MaterialName = "Blue Planet", MaterialTypeId = 2, GenreId = 1, OutofCirculationSince = null},
      new Material {Id = 5, MaterialName = "Good Omens", MaterialTypeId = 3, GenreId = 2, OutofCirculationSince = null},
      new Material {Id = 6, MaterialName = "Becoming", MaterialTypeId = 1, GenreId = 4, OutofCirculationSince = null},
      new Material {Id = 7, MaterialName = "The Alchemist", MaterialTypeId = 1, GenreId = 2, OutofCirculationSince = null},
      new Material {Id = 8, MaterialName = "Everything, Everywhere, All At Once", MaterialTypeId = 2, GenreId = 2, OutofCirculationSince = null},
      new Material {Id = 9, MaterialName = "Mellon Collie", MaterialTypeId = 3, GenreId = 1, OutofCirculationSince = null},
      new Material {Id = 10, MaterialName = "Song and Wind", MaterialTypeId = 1, GenreId = 1, OutofCirculationSince = new DateTime(2021, 12, 14)}
    });
    modelBuilder.Entity<MaterialType>().HasData(new MaterialType[]
    {
      new MaterialType {Id = 1, Name = "Book", CheckoutDays = 21},
      new MaterialType {Id = 2, Name = "DVD/BluRay", CheckoutDays = 7},
      new MaterialType {Id = 3, Name = "CD", CheckoutDays = 21},
    });
    modelBuilder.Entity<Patron>().HasData(new Patron[]
    {
      new Patron {Id = 1, FirstName = "Ada", LastName = "Lovelace", Address = "123 Byte St", Email = "AdaL@gmail.com", IsActive = true},
      new Patron {Id = 2, FirstName = "Alan", LastName = "Turing", Address = "456 Crypto Dr", Email = "AlanT@gmail.com", IsActive = false},
      new Patron {Id = 3, FirstName = "Grace", LastName = "Hopper", Address = "789 Code Ave", Email = "GraceH@gmail.com", IsActive = true},
      new Patron {Id = 4, FirstName = "John", LastName = "von Neumann", Address = "1010 Algorithm Blvd", Email = "JohnN@gmail.com", IsActive = false},
      new Patron {Id = 5, FirstName = "Margaret", LastName = "Hamilton", Address = "1111 Software Ln", Email = "MargaretH@gmail.com", IsActive = true},
      new Patron {Id = 6, FirstName = "Donald", LastName = "Knuth", Address = "1313 Typeset Cir", Email = "DonaldK@gmail.com", IsActive = true},
      new Patron {Id = 7, FirstName = "Barbara", LastName = "Liskov", Address = "1414 Inheritance Rd", Email = "BarbaraL@gmail.com", IsActive = false},
      new Patron {Id = 8, FirstName = "Tim", LastName = "Berners-Lee", Address = "1616 Web St", Email = "TimBL@gmail.com", IsActive = true},
      new Patron {Id = 9, FirstName = "Linus", LastName = "Torvalds", Address = "1717 Kernel Ave", Email = "LinusT@gmail.com", IsActive = false},
      new Patron {Id = 10, FirstName = "Ada", LastName = "Yonath", Address = "1919 Structure Dr", Email = "AdaY@gmail.com", IsActive = true},
      new Patron {Id = 11, FirstName = "Brian", LastName = "Kernighan", Address = "2020 Language Blvd", Email = "BrianK@gmail.com", IsActive = true},
      new Patron {Id = 12, FirstName = "Grace", LastName = "Murray", Address = "2222 Navy St", Email = "GraceM@gmail.com", IsActive = false},

    });
    modelBuilder.Entity<Checkout>().HasData(new Checkout[]
    {
      new Checkout {Id = 1, MaterialId = 1, PatronId = 1, CheckoutDate = new DateTime(2021, 12, 14), ReturnDate = new DateTime(2021, 12, 30), Paid = true},
      new Checkout {Id = 2, MaterialId = 2, PatronId = 2, CheckoutDate = new DateTime(2022, 1, 5), ReturnDate = new DateTime(2022, 1, 20), Paid = true},
      new Checkout {Id = 3, MaterialId = 3, PatronId = 3, CheckoutDate = new DateTime(2022, 2, 10), ReturnDate = new DateTime(2022, 2, 25), Paid = true},
      new Checkout {Id = 4, MaterialId = 4, PatronId = 4, CheckoutDate = new DateTime(2022, 3, 15), ReturnDate = new DateTime(2022, 3, 30), Paid = true},
      new Checkout {Id = 5, MaterialId = 5, PatronId = 5, CheckoutDate = new DateTime(2022, 4, 20), ReturnDate = new DateTime(2022, 5, 5), Paid = true},
      new Checkout {Id = 6, MaterialId = 6, PatronId = 6, CheckoutDate = new DateTime(2022, 5, 25), ReturnDate = new DateTime(2022, 6, 10), Paid = true},
      new Checkout {Id = 7, MaterialId = 7, PatronId = 7, CheckoutDate = new DateTime(2022, 6, 30), ReturnDate = new DateTime(2022, 7, 15), Paid = true},
      new Checkout {Id = 8, MaterialId = 8, PatronId = 8, CheckoutDate = new DateTime(2022, 7, 5), ReturnDate = new DateTime(2022, 7, 20), Paid = true},
      new Checkout {Id = 9, MaterialId = 9, PatronId = 9, CheckoutDate = new DateTime(2022, 8, 10), ReturnDate = new DateTime(2022, 8, 25), Paid = true},
      new Checkout {Id = 10, MaterialId = 10, PatronId = 10, CheckoutDate = new DateTime(2022, 9, 15), ReturnDate = new DateTime(2022, 9, 30), Paid = true},
      new Checkout {Id = 11, MaterialId = 1, PatronId = 11, CheckoutDate = new DateTime(2022, 10, 20), ReturnDate = new DateTime(2022, 11, 5), Paid = true},
      new Checkout {Id = 12, MaterialId = 2, PatronId = 12, CheckoutDate = new DateTime(2022, 11, 10), ReturnDate = new DateTime(2022, 11, 25), Paid = true},
      new Checkout {Id = 13, MaterialId = 3, PatronId = 1, CheckoutDate = new DateTime(2022, 12, 15), ReturnDate = new DateTime(2022, 12, 30), Paid = true},
      new Checkout {Id = 14, MaterialId = 4, PatronId = 2, CheckoutDate = new DateTime(2023, 1, 5), ReturnDate = new DateTime(2023, 1, 20), Paid = true},
      new Checkout {Id = 15, MaterialId = 5, PatronId = 3, CheckoutDate = new DateTime(2023, 2, 10), ReturnDate = new DateTime(2023, 2, 25), Paid = true},
      new Checkout {Id = 16, MaterialId = 6, PatronId = 4, CheckoutDate = new DateTime(2023, 3, 15), ReturnDate = new DateTime(2023, 3, 30), Paid = true},
      new Checkout {Id = 17, MaterialId = 7, PatronId = 5, CheckoutDate = new DateTime(2023, 4, 20), ReturnDate = new DateTime(2023, 5, 5), Paid = true},
      new Checkout {Id = 18, MaterialId = 8, PatronId = 6, CheckoutDate = new DateTime(2023, 5, 25), ReturnDate = new DateTime(2023, 6, 10), Paid = true},
      new Checkout {Id = 19, MaterialId = 9, PatronId = 7, CheckoutDate = new DateTime(2023, 6, 30), Paid = false},
      new Checkout {Id = 20, MaterialId = 10, PatronId = 8, CheckoutDate = new DateTime(2023, 7, 5), Paid = false},
    });
  }
}
