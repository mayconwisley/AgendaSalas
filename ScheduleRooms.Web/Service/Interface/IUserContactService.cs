﻿using ScheduleRooms.Models.Dtos;
using ScheduleRooms.Web.Models;

namespace ScheduleRooms.Web.Service.Interface;

public interface IUserContactService
{
    Task<UserView> GetAll(int page = 1, int size = 10, string search = "");
    Task<UserDto> GetById(int id);
    Task<UserContactView> GetByUserId(int page, int size, int userId);
    Task<UserDto> Create(UserContactCreateDto userContactCreateDto);
    Task<UserDto> Update(UserContactCreateDto userContactCreateDto);
    Task<bool> Delete(int id);
}
