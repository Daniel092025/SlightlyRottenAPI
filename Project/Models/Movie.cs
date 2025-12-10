using System;
using System.Collections.Generic;

namespace Project.Models;

// Scaffolded(reverse engineered) using EF Core from MovieDatabaseSQL 
public partial class Movie
{
    public string? Id { get; set; }

    public string? Title { get; set; }

    public string? Genre { get; set; }

    public string? Director { get; set; }

    public string? Actors { get; set; }

    public int? Year { get; set; }

    public int? Playtime { get; set; }

    public int? Rating { get; set; }

    public string? Review { get; set; }
}
