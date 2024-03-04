﻿using ScheduleRooms.Models.Dtos;
using ScheduleRooms.Web.Models;

namespace ScheduleRooms.Web.Service.Interface;

public interface IClientService
{
    Task<ClientView> GetAll(int page, int size, string search);
    Task<ClientDto> GetById(int id);
    Task<ClientDto> Create(ClientDto clientDto);
    Task<ClientDto> Update(ClientDto clientDto);
    Task<bool> Delete(int id);
}
