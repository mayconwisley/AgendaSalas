﻿using ScheduleRooms.Models.Dtos;

namespace ScheduleRooms.Web.Models;

public class ClientView
{
    public int TotalData { get; set; }
    public int Page { get; set; }
    public int TotalPage { get; set; }
    public int Size { get; set; }
    public IEnumerable<ClientDto>? ClientsDto { get; set; }
}
