using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Domain.Entities;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Infrastructure.Hubs
{
    public class UserHub : Hub
    {
        private readonly ReminderDbContext _context;

        public UserHub(ReminderDbContext context)
        {
            _context = context;
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("OnConnectedUser");
            return base.OnConnectedAsync();
        }
        public async Task SaveUserConnection(string email)
        {
            var connectionId = Context.ConnectionId;
            HubConnection hubConnection = new HubConnection
            {
                ConnectionId = connectionId,
                Email = email,
                ConnectionType = Domain.Enums.ConnectionType.UserConnectionType
            };

            await _context.HubConnections.AddAsync(hubConnection);
            await _context.SaveChangesAsync();
        }

        public async Task SendUserCount()
        {
            int count = await _context.Set<User>().CountAsync();
            await Clients.Caller.SendAsync("UserCount");
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var hubConnection = _context.HubConnections.FirstOrDefault(con => con.ConnectionId == Context.ConnectionId && con.ConnectionType == Domain.Enums.ConnectionType.UserConnectionType);
            if (hubConnection != null)
            {
                _context.HubConnections.Remove(hubConnection);
                _context.SaveChangesAsync();
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
