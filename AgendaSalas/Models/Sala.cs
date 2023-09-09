﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleRooms.Models;

public class Room
{
    public int Id { get; set; }
    [Column(TypeName = "VARCHAR(500)")]
    public string SalaReuniao { get; set; }
    [Column(TypeName = "VARCHAR(5)")]
    public string Ramal { get; set; }
    [Column(TypeName = "VARCHAR(1000)")]
    public string Description { get; set; }
}
