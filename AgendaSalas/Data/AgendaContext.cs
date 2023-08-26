﻿using AgendaSalas.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaSalas.Data;

public class AgendaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Banco\\Agenda.db");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Sala> Salas { get; set; }
    public DbSet<Reuniao> Reunioes { get; set; }
}
