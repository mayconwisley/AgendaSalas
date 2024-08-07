﻿using CalendarSchedule.Models.Dtos;
using CalendarSchedule.Web.Models;

namespace CalendarSchedule.Web.Service.Interface;

public interface IScheduleUserService
{
    Task<ScheduleUserView> GetAll(int page = 1, int size = 10, string search = "");
    Task<IEnumerable<ScheduleUserDto>> GetByScheduleUserDateStart(DateTime dateSelected);
    Task<ScheduleUserDto> GetById(int scheduleId, int userId);
    Task<IEnumerable<ScheduleUserDto>> GetByScheduleId(int scheduleId);
    Task<ScheduleUserDto> Create(ScheduleUserCreateDto scheduleUserDto);
    Task<ScheduleUserDto> Update(ScheduleUserCreateDto scheduleUserDto);
    Task<bool> Delete(int scheduleId, int userId);
}
