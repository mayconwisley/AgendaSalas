﻿using ScheduleRooms.API.Model;

namespace ScheduleRooms.API.Repository.Interface;

public interface IScheduleRepository
{
    Task<IEnumerable<Schedule>> GetAll(int page, int size, string search);
    Task<IEnumerable<Schedule>> GetByAgendaActive();
    Task<IEnumerable<Schedule>> GetByAgendaActiveSalaId(int roomId, DateTime dateSalected);
    Task<Schedule> GetById(int id);
    Task<Schedule> Create(Schedule schedule);
    Task<Schedule> Update(Schedule schedule);
    Task<Schedule> Delete(int id);
    Task<int> TotalSchedules(string search);
}
