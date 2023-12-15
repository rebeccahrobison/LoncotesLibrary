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
    });
  }
}
