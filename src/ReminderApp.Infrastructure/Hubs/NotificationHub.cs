using Microsoft.AspNetCore.SignalR;
using ReminderApp.Domain.Entities;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Infrastructure.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly ReminderDbContext _context;

        public NotificationHub(ReminderDbContext context)
        {
            _context = context;
        }

        public async Task SendNotificationToAll(string message)
        {
            await Clients.All.SendAsync("ReceivedNotification", message);
        }

        public async Task SendNotificationToClient(string message, string email)
        {
            var hubConnections = _context.HubConnections.Where(con => con.Email == email).ToList();
            foreach (var hubConnection in hubConnections)
            {
                await Clients.Client(hubConnection.ConnectionId).SendAsync("ReceivedPersonalNotification", message, email);
            }
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("OnConnectedNotification");
            return base.OnConnectedAsync();
        }

        public async Task SaveUserConnection(string email)
        {
            var connectionId = Context.ConnectionId;
            HubConnection hubConnection = new HubConnection
            {
                ConnectionId = connectionId,
                Email = email,
                ConnectionType = Domain.Enums.ConnectionType.NotificationConnectionType
            };

            _context.HubConnections.Add(hubConnection);
            await _context.SaveChangesAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var hubConnection = _context.HubConnections.FirstOrDefault(con => con.ConnectionId == Context.ConnectionId && con.ConnectionType == Domain.Enums.ConnectionType.NotificationConnectionType);
            if (hubConnection != null)
            {
                _context.HubConnections.Remove(hubConnection);
                _context.SaveChangesAsync();
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
