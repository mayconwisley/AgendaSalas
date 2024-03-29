﻿using Microsoft.EntityFrameworkCore;
using ScheduleRooms.API.Data;
using ScheduleRooms.API.Model;
using ScheduleRooms.API.Repository.Interface;

namespace ScheduleRooms.API.Repository;

public class ScheduleRoomRepository : IScheduleRoomRepository
{
    private readonly ScheduleContext _scheduleContext;

    public ScheduleRoomRepository(ScheduleContext scheduleContext)
    {
        _scheduleContext = scheduleContext;
    }

    public async Task<ScheduleRoom> Create(ScheduleRoom scheduleRoom)
    {
        try
        {
            if (scheduleRoom is not null)
            {

                // Verifique se existe uma schedule que se sobrepõe na mesma room
                var overlappingAgendas = await _scheduleContext.ScheduleRooms
                    .Where(a => a.RoomId == scheduleRoom.RoomId &&
                                a.DateStart < scheduleRoom.DateFinal &&
                                a.DateFinal > scheduleRoom.DateStart)
                    .ToListAsync();

                if (overlappingAgendas.Count() > 0)
                {
                    // Existe sobreposição, faça algo aqui, como lançar uma exceção.
                    throw new Exception("409");
                }
                _scheduleContext.ScheduleRooms.Add(scheduleRoom);
                await _scheduleContext.SaveChangesAsync();
                return scheduleRoom;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ScheduleRoom> Delete(int id)
    {
        try
        {
            var schedule = await GetById(id);

            if (schedule is not null)
            {
                _scheduleContext.Remove(schedule);
                await _scheduleContext.SaveChangesAsync();
                return schedule;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<ScheduleRoom>> GetAll(int page, int size, string search)
    {
        try
        {
            var schedules = await _scheduleContext.ScheduleRooms
                .Include(i => i.Room)
                .OrderByDescending(o => o.DateFinal)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return schedules;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<ScheduleRoom>> GetByAgendaActive()
    {
        try
        {
            var schedules = await _scheduleContext.ScheduleRooms            
                .Include(i => i.Room)
               // .Where(w => w.DateFinal >= DateTime.Now)
                .OrderBy(o => o.DateFinal)
                .ToListAsync();

            return schedules;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<ScheduleRoom>> GetByAgendaActiveSalaId(int roomId, DateTime dateSalected)
    {
        try
        {
            var schedules = await _scheduleContext.ScheduleRooms
                .Include(i => i.Room)
                .Where(w => w.DateFinal.Date == dateSalected.Date &&
                            w.RoomId == roomId)
                .OrderBy(o => o.DateStart)
                .ToListAsync();

            return schedules;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ScheduleRoom> GetById(int id)
    {
        try
        {
            var schedule = await _scheduleContext.ScheduleRooms
                .Include(i => i.Room)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            if (schedule is not null)
            {
                return schedule;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> TotalSchedules(string search)
    {
        var totalAgendas = await _scheduleContext.ScheduleRooms
            .Where(w => w!.Description!.Contains(search))
            .CountAsync();

        return totalAgendas;

    }

    public async Task<ScheduleRoom> Update(ScheduleRoom schedule)
    {
        try
        {
            if (schedule is not null)
            {

                // Verifique se existe uma schedule que se sobrepõe na mesma room
                var overlappingAgendas = await _scheduleContext.ScheduleRooms
                    .Where(a => a.RoomId == schedule.RoomId &&
                                a.Id != schedule.Id && // Exclua a própria schedule da verificação
                                a.DateStart < schedule.DateFinal &&
                                a.DateFinal > schedule.DateStart)
                    .ToListAsync();

                if (overlappingAgendas.Count() > 0)
                {
                    // Existe sobreposição, faça algo aqui, como lançar uma exceção.
                    throw new Exception("A atualização resultaria em uma sobreposição de datas para esta room.");
                }

                _scheduleContext.ScheduleRooms.Entry(schedule).State = EntityState.Modified;
                await _scheduleContext.SaveChangesAsync();
                return schedule;
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
