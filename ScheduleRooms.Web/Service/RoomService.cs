﻿using ScheduleRooms.Models.Dtos;
using ScheduleRooms.Web.Models;
using ScheduleRooms.Web.Service.Interface;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ScheduleRooms.Web.Service;

public class RoomService : IRoomService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _serializerOptions;
    private const string? apiEndPoint = "api/Room";

    public RoomService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<RoomDto> Create(RoomDto roomDto)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient("ConexaoApi");

            StringContent stringContent = new(JsonSerializer.Serialize(roomDto), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(apiEndPoint, stringContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    using Stream resApi = await response.Content.ReadAsStreamAsync();
                    var room = await JsonSerializer.DeserializeAsync<RoomDto>(resApi, _serializerOptions);
                    if (room is not null)
                    {
                        return room;
                    }
                }
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient("ConexaoApi");
            using var response = await httpClient.DeleteAsync($"{apiEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return new();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<RoomView> GetAll(int page = 1, int size = 10, string search = "")
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient("ConexaoApi");
            using var response = await httpClient.GetAsync($"{apiEndPoint}/All?page={page}&size={size}&search={search}");


            if (response.IsSuccessStatusCode)
            {
                RoomView? salaView = await response.Content.ReadFromJsonAsync<RoomView>(_serializerOptions);
                return salaView ??= new();
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new();
                }
                response.EnsureSuccessStatusCode();
                return new();
            }

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RoomDto> GetById(int id)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient("ConexaoApi");
            using var response = await httpClient.GetAsync($"{apiEndPoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var roomDto = await response.Content.ReadFromJsonAsync<RoomDto>(_serializerOptions);
                return roomDto ?? new();
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new();
                }
                response.EnsureSuccessStatusCode();
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RoomDto> Update(RoomDto roomDto)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient("ConexaoApi");

            StringContent stringContent = new(JsonSerializer.Serialize(roomDto), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PutAsync($"{apiEndPoint}/{roomDto.Id}", stringContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    using Stream resApi = await response.Content.ReadAsStreamAsync();
                    var room = await JsonSerializer.DeserializeAsync<RoomDto>(resApi, _serializerOptions);
                    if (room is not null)
                    {
                        return room;
                    }
                }
            }
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
