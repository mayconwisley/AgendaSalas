﻿using CalendarSchedule.API.Model;
using CalendarSchedule.Models.Dtos;

namespace CalendarSchedule.API.MappingDto.UserDtos;

public static class UserMappingDto
{
    public static IEnumerable<UserDto> ConvertUsersToDto(this IEnumerable<User> users)
    {
        return (from user in users
                select new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,

                    Description = user.Description,
                    Username = user.Username,
                    Password = user.Password,
                    Manager = user.Manager,
                    Active = user.Active
                }).ToList();

    }
    public static IEnumerable<User> ConvertDtoToUsers(this IEnumerable<UserDto> userDtos)
    {
        return (from user in userDtos
                select new User
                {
                    Id = user.Id,
                    Name = user.Name,

                    Description = user.Description,
                    Username = user.Username,
                    Password = user.Password,
                    Manager = user.Manager,
                    Active = user.Active
                }).ToList();
    }
    public static UserDto ConvertUserToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,

            Description = user.Description,
            Username = user.Username,
            Password = user.Password,
            Manager = user.Manager,
            Active = user.Active

        };
    }
    public static User ConvertDtoToUser(this UserDto userDto)
    {
        return new User
        {
            Id = userDto.Id,
            Name = userDto.Name,

            Description = userDto.Description,
            Username = userDto.Username,
            Password = userDto.Password,
            Manager = userDto.Manager,
            Active = userDto.Active
        };
    }
}
