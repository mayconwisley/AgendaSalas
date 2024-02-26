using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ScheduleRooms.Web;
using ScheduleRooms.Web.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7244";

//var baseUrl = "http://192.168.0.102:5050";
//var baseUrl = "http://192.168.10.149:5050";


builder.Services.AddHttpClient("ConexaoApi", con =>
{
    con.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IScheduleRoomService, ScheduleRoomService>();


await builder.Build().RunAsync();
