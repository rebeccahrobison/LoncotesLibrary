using LoncotesLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using LoncotesLibrary.Models.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<LoncotesLibraryDbContext>(builder.Configuration["LoncotesLibraryDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ENDPOINTS SECTION

// Get all Circulating Materials
app.MapGet("/api/materials", (LoncotesLibraryDbContext db) =>
{
    return db.Materials
        .Where(r => r.OutofCirculationSince == null)
        .Include(r => r.Genre)
        .Include(r => r.MaterialType)
        .OrderBy(res => res.MaterialName)
        .Select(r => new MaterialDTO
        {
            Id = r.Id,
            MaterialName = r.MaterialName,
            MaterialTypeId = r.MaterialTypeId,
            GenreId = r.GenreId,
            OutofCirculationSince = r.OutofCirculationSince,
            MaterialType = new MaterialTypeDTO
            {
                Id = r.MaterialType.Id,
                Name = r.MaterialType.Name,
                CheckoutDays = r.MaterialType.CheckoutDays
            },
            Genre = new GenreDTO
            {
                Id = r.Genre.Id,
                Name = r.Genre.Name
            }
        });
});

// Get Materials by Genre and/or MaterialType
app.MapGet("/api/materials/bygenrematerialtype", (LoncotesLibraryDbContext db, int? genreId, int? materialTypeId) =>
{
    return db.Materials
        .Where(r => (!genreId.HasValue || r.GenreId == genreId) && (!materialTypeId.HasValue || r.MaterialTypeId == materialTypeId))
        .Include(r => r.Genre)
        .Include(r => r.MaterialType)
        .OrderBy(res => res.Id)
        .Select(m => new MaterialDTO
        {
            Id = m.Id,
            MaterialName = m.MaterialName,
            MaterialTypeId = m.MaterialTypeId,
            GenreId = m.GenreId,
            OutofCirculationSince = m.OutofCirculationSince,
            MaterialType = new MaterialTypeDTO
            {
                Id = m.MaterialType.Id,
                Name = m.MaterialType.Name,
                CheckoutDays = m.MaterialType.CheckoutDays
            },
            Genre = new GenreDTO
            {
                Id = m.Genre.Id,
                Name = m.Genre.Name
            }
        });
});

// Get Material Details
app.MapGet("/api/materials/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    Material foundMaterial = db.Materials
        .Include(r => r.Genre)
        .Include(r => r.MaterialType)
        .Include(r => r.Checkouts)
        .ThenInclude(r => r.Patron)
        .FirstOrDefault(co => co.Id == id);

    //error handler
    if (foundMaterial == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new MaterialDTO

    {
        Id = foundMaterial.Id,
        MaterialName = foundMaterial.MaterialName,
        MaterialTypeId = foundMaterial.MaterialTypeId,
        GenreId = foundMaterial.GenreId,
        OutofCirculationSince = foundMaterial.OutofCirculationSince,
        MaterialType = new MaterialTypeDTO
        {
            Id = foundMaterial.MaterialType.Id,
            Name = foundMaterial.MaterialType.Name,
            CheckoutDays = foundMaterial.MaterialType.CheckoutDays
        },
        Genre = new GenreDTO
        {
            Id = foundMaterial.Genre.Id,
            Name = foundMaterial.Genre.Name
        },
        Checkouts = foundMaterial.Checkouts.Select(c => new CheckoutDTO
        {
            Id = c.Id,
            MaterialId = c.MaterialId,
            PatronId = c.PatronId,
            CheckoutDate = c.CheckoutDate,
            ReturnDate = c.ReturnDate,
            Patron = new PatronDTO
            {
                Id = c.Patron.Id,
                FirstName = c.Patron.FirstName,
                LastName = c.Patron.LastName,
                Address = c.Patron.Address,
                Email = c.Patron.Email,
                IsActive = c.Patron.IsActive
            }
        }).ToList()
    });
});

// Add a Material
app.MapPost("/api/materials", (LoncotesLibraryDbContext db, Material material) =>
{
    db.Materials.Add(material);
    db.SaveChanges();
    return Results.Created($"/api/materials/{material.Id}", material);
});

// Delete a Material
app.MapDelete("/api/materials/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    Material foundMaterial = db.Materials.SingleOrDefault(fm => fm.Id == id);
    if (foundMaterial == null)
    {
        return Results.NotFound();
    }
    db.Materials.Remove(foundMaterial);
    db.SaveChanges();
    return Results.NoContent();
});

// Get MaterialTypes
app.MapGet("/api/materialTypes", (LoncotesLibraryDbContext db) =>
{
    return db.MaterialTypes
        .Select(mt => new MaterialTypeDTO
        {
            Id = mt.Id,
            Name = mt.Name,
            CheckoutDays = mt.CheckoutDays
        });
});

// Get Genres
app.MapGet("/api/genres", (LoncotesLibraryDbContext db) =>
{
    return db.Genres
    .Select(g => new GenreDTO
    {
        Id = g.Id,
        Name = g.Name
    });
});

// Get Patrons
app.MapGet("/api/patrons", (LoncotesLibraryDbContext db) =>
{
    return db.Patrons
    .OrderBy(p => p.Id)
    .Select(p => new PatronDTO
    {
        Id = p.Id,
        FirstName = p.FirstName,
        LastName = p.LastName,
        Address = p.Address,
        Email = p.Email,
        IsActive = p.IsActive
    });
});

// Get Patron Details
app.MapGet("/api/patrons/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    Patron foundPatron = db.Patrons
        .Include(p => p.Checkouts)
        .FirstOrDefault(p => p.Id == id);

    if (foundPatron == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new PatronDTO
    {
        Id = foundPatron.Id,
        FirstName = foundPatron.FirstName,
        LastName = foundPatron.LastName,
        Address = foundPatron.Address,
        Email = foundPatron.Email,
        IsActive = foundPatron.IsActive,

        Checkouts = db.Checkouts
            .Where(pco => pco.PatronId == foundPatron.Id)
            .Select(c => new CheckoutDTO
            {
                Id = c.Id,
                MaterialId = c.MaterialId,
                PatronId = c.PatronId,
                CheckoutDate = c.CheckoutDate,
                ReturnDate = c.ReturnDate
            })
            .ToList(),
        CheckoutsWithLateFee = db.Checkouts
            .Where(pco => pco.PatronId == foundPatron.Id)
            .Select(c => new CheckoutWithLateFeeDTO
            {
                Id = c.Id,
                MaterialId = c.MaterialId,
                PatronId = c.PatronId,
                CheckoutDate = c.CheckoutDate,
                ReturnDate = c.ReturnDate,
                Material = new MaterialDTO
                {
                    Id = c.Material.Id,
                    MaterialName = c.Material.MaterialName,
                    MaterialTypeId = c.Material.MaterialTypeId,
                    GenreId = c.Material.GenreId,
                    OutofCirculationSince = c.Material.OutofCirculationSince,
                    MaterialType = new MaterialTypeDTO
                    {
                        Id = c.Material.MaterialType.Id,
                        Name = c.Material.MaterialType.Name,
                        CheckoutDays = c.Material.MaterialType.CheckoutDays
                    }
                }
            })
            .ToList()
    });
});

// Get Patron with Checkouts
app.MapGet("/api/patrons/withcheckouts", (LoncotesLibraryDbContext db) =>
{
    return db.Patrons
    .Where(p => p.Checkouts.Any())
    .Select(p => new PatronDTO
    {
        Id = p.Id,
        FirstName = p.FirstName,
        LastName = p.LastName,
        Address = p.Address,
        Email = p.Email,
        IsActive = p.IsActive,
        Checkouts = p.Checkouts.Select(c => new CheckoutDTO
        {
            Id = c.Id,
            MaterialId = c.MaterialId,
            PatronId = c.PatronId,
            CheckoutDate = c.CheckoutDate,
            ReturnDate = c.ReturnDate
        }).ToList()
    });
});

// Update Patron
app.MapPut("/api/patrons/{id}", (LoncotesLibraryDbContext db, int id, Patron patron) =>
{
    Patron patronToUpdate = db.Patrons.SingleOrDefault(p => p.Id == id);
    if (patronToUpdate == null)
    {
        return Results.NotFound();
    }
    patronToUpdate.FirstName = patron.FirstName;
    patronToUpdate.LastName = patron.LastName;
    patronToUpdate.Address = patron.Address;
    patronToUpdate.Email = patron.Email;
    patronToUpdate.IsActive = patron.IsActive;

    db.SaveChanges();
    return Results.NoContent();
});

// Deactivate Patron
app.MapPost("/api/patrons/{id}/deactivate", (LoncotesLibraryDbContext db, int id) =>
{
    Patron patronToDeactivate = db.Patrons.SingleOrDefault(p => p.Id == id);
    if (patronToDeactivate == null)
    {
        return Results.NotFound();
    }
    patronToDeactivate.IsActive = false;
    db.SaveChanges();
    return Results.Ok($"{patronToDeactivate.FirstName} {patronToDeactivate.LastName} is deactivated");
});

// Checkout a Material
app.MapPost("/api/checkouts", (LoncotesLibraryDbContext db, Checkout checkout) =>
{
    try
    {
        checkout.CheckoutDate = DateTime.Today;
        db.Checkouts.Add(checkout);
        db.SaveChanges();
        return Results.Created($"/api/checkouts/{checkout.Id}", checkout);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// Return a Material
app.MapPost("/api/checkouts/{id}/return", (LoncotesLibraryDbContext db, int id) =>
{
    Checkout checkoutToReturn = db.Checkouts.SingleOrDefault(c => c.Id == id);
    if (checkoutToReturn == null)
    {
        return Results.NotFound();
    }
    checkoutToReturn.ReturnDate = DateTime.Today;
    db.SaveChanges();
    return Results.Ok($"Item is returned");
});

// Get all Checkouts
app.MapGet("/api/checkouts", (LoncotesLibraryDbContext db) =>
{
    return db.Checkouts
    .Select(c => new CheckoutDTO
    {
        Id = c.Id,
        MaterialId = c.MaterialId,
        PatronId = c.PatronId,
        CheckoutDate = c.CheckoutDate,
        ReturnDate = c.ReturnDate
    });
});

app.MapDelete("/api/checkouts/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    Checkout checkoutToDelete = db.Checkouts.SingleOrDefault(co => co.Id == id);
    if (checkoutToDelete == null)
    {
        return Results.NotFound();
    }
    db.Checkouts.Remove(checkoutToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

// Get all materials that are not checkedout and in circulation
app.MapGet("/api/materials/available", (LoncotesLibraryDbContext db) =>
{
    return db.Materials
    .Where(m => m.OutofCirculationSince == null)
    .Where(m => m.Checkouts.All(co => co.ReturnDate != null))
    .Select(material => new MaterialDTO
    {
        Id = material.Id,
        MaterialName = material.MaterialName,
        MaterialTypeId = material.MaterialTypeId,
        GenreId = material.GenreId,
        OutofCirculationSince = material.OutofCirculationSince
    })
    .ToList();
});

// Get Overdue materials with late fees
app.MapGet("/api/checkouts/overdue", (LoncotesLibraryDbContext db) =>
{
    return db.Checkouts
    .Include(p => p.Patron)
    .Include(co => co.Material)
    .ThenInclude(m => m.MaterialType)
    .Where(co =>
        (DateTime.Today - co.CheckoutDate).Days > co.Material.MaterialType.CheckoutDays
        &&
        co.ReturnDate == null)
        .Select(co => new CheckoutWithLateFeeDTO
        {
            Id = co.Id,
            MaterialId = co.MaterialId,
            Material = new MaterialDTO
            {
                Id = co.Material.Id,
                MaterialName = co.Material.MaterialName,
                MaterialTypeId = co.Material.MaterialTypeId,
                MaterialType = new MaterialTypeDTO
                {
                    Id = co.Material.MaterialTypeId,
                    Name = co.Material.MaterialType.Name,
                    CheckoutDays = co.Material.MaterialType.CheckoutDays
                },
                GenreId = co.Material.GenreId,
                OutofCirculationSince = co.Material.OutofCirculationSince
            },
            PatronId = co.PatronId,
            Patron = new PatronDTO
            {
                Id = co.Patron.Id,
                FirstName = co.Patron.FirstName,
                LastName = co.Patron.LastName,
                Address = co.Patron.Address,
                Email = co.Patron.Email,
                IsActive = co.Patron.IsActive
            },
            CheckoutDate = co.CheckoutDate,
            ReturnDate = co.ReturnDate
        })
        .ToList();
});


app.Run();