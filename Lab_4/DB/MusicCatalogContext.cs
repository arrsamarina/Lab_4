﻿using Lab_4.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Lab_4.DB;

public class MusicCatalogContext : DbContext {
    public DbSet<MusicModel> Musics { get; set; }
    public MusicCatalogContext(DbContextOptions<MusicCatalogContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}