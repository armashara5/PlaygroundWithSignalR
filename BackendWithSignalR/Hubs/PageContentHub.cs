using Microsoft.AspNetCore.SignalR;

namespace BackendWithSignalR.Hubs
{
    public class PageContentHub : Hub
    {
            // create a method that broadcasts a number to all clients
            public async Task SendNumber(int number)
            {
                await Clients.All.SendAsync("ReceiveNumber", number);
            }
    }

}
