﻿using CalendarSchedule.Models.Dtos;

namespace CalendarSchedule.Web.Models;

public class UserContactView
{
    public int TotalData { get; set; }
    public int Page { get; set; }
    public int TotalPage { get; set; }
    public int Size { get; set; }
    public IEnumerable<UserContactDto>? UserContactsDto { get; set; }
}
