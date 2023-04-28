using Microsoft.AspNetCore.SignalR;

namespace Services
{
    public class OrderHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}