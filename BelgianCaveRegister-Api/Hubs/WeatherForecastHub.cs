using BelgianCaveRegister_Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class WeatherForecastHub : Hub
    {
        public async Task SendWeatherUpdate(WeatherForecast weatherUpdate)
        {
            // Send weather update to all connected clients
            await Clients.All.SendAsync("ReceiveWeatherUpdate", weatherUpdate);
        }
        public async Task RefreshWeaterForecast()
        {
            if (Clients is not null) await Clients.All.SendAsync("notifyNewWeatherForecast");
            
        }
    }
}
