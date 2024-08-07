﻿using Microsoft.EntityFrameworkCore;
using CalendarSchedule.Models;

namespace ScheduleRooms.Data;

public class ScheduleContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Banco\\Schedule.db");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
}
