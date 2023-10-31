﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ControlWork_Preview.Classes;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    protected AppDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Путь к базе данных SQLite. Файл будет создан в текущей директории приложения. (bin/Debug/)
        var databasePath = Path.Combine(Environment.CurrentDirectory, "MyDatabase.db");

        // Используем SQLite.
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }
}
