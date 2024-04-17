﻿using ScheduleRooms.Models.Dtos;

namespace ScheduleRooms.API.Service.Interface;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAll(int page, int size, string search);
    Task<IEnumerable<UserDto>> GetManagerAll(int page, int size, string search);
    Task<UserDto> GetById(int id);
    Task<bool> GetPassword(LoginDto login);
    Task Create(UserDto userDto);
    Task Update(UserDto userDto);
    Task Delete(int id);
    Task<int> TotalUsers(string search);
}
