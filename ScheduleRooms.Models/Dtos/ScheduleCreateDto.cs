﻿using System.ComponentModel.DataAnnotations;

namespace ScheduleRooms.Models.Dtos;

public class ScheduleCreateDto
{
    public int Id { get; set; }
    public string? Description { get; set; } = null;
    [Required(ErrorMessage = "Data Inicio Obrigatório")]
    public DateTime DateStart { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Data Final Obrigatório")]
    public DateTime DateFinal { get; set; } = DateTime.Now.AddHours(1);
    public bool MeetingType { get; set; } = false;
    public bool StatusSchedule { get; set; } = false;
    public bool Particular { get; set; } = false;
    public int? UserId { get; set; } = null;
    public int? ClientId { get; set; } = null;
}
