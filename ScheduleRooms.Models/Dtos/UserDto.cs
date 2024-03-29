﻿using System.ComponentModel.DataAnnotations;

namespace ScheduleRooms.Models.Dtos;

public class UserDto
{
    public int Id { get; set; } = 0;
    [Required(ErrorMessage = "Nome obrigatório")]
    public string? Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Celular obrigatório")]
    [MaxLength(16, ErrorMessage = "Máximo 16 digito")]
    [MinLength(11, ErrorMessage = "Mínino 11 digito")]
    public string? Cellphone { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
}
