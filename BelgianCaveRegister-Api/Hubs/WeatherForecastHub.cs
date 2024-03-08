using BelgianCaveRegister_Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class WeatherForecastHub : Hub
    {
        public async Task SendWeatherUpdate()
        {
            // Send weather update to all connected clients
            if (Clients is not null)
                await Clients.All.SendAsync("receiveweatherforecastupdate");
        }
        public async Task RefreshWeatherForecast()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewweatherforecast");
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("weatherforecast");
        }
        public async Task GetWeatherForecast()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("weartherforecast");
        }
    }
}
