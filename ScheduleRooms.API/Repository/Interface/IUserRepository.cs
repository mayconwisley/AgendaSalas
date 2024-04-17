﻿using ScheduleRooms.API.Model;

namespace ScheduleRooms.API.Repository.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll(int page, int size, string search);
    Task<IEnumerable<User>> GetManagerAll(int page, int size, string search);
    Task<User> GetById(int id);
    Task<string> GetPassword(LoginApi login);
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<User> Delete(int id);
    Task<int> TotalUser(string search);
}
