using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using mvcdemo.Data;
using mvcdemo.Infrastructure;
using mvcdemo.Models;

namespace mvcdemo.Repository{
    public class NotificationRepository : INotificationRepository
    {
        public ApplicationDbContext _context { get; }
        public IWatchlistRepository _watchlistRepository { get; }

        private IHubContext<SignalServer> _hubContext;

        public NotificationRepository(ApplicationDbContext context, 
                                        IWatchlistRepository watchlistRepository,
                                        IHubContext<SignalServer> hubContext)
        {
            _context = context;
            _watchlistRepository = watchlistRepository;
            _hubContext = hubContext;
        }

        public void Create(Notification notification,int petId)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            //TODO: Assign notification to users
            var watchlists = _watchlistRepository.GetWatchlistFromPetId(petId);
            foreach (var watchlist in watchlists)
            {
                var userNotification = new NotificationApplicationUser();
                userNotification.ApplicationUserId = watchlist.UserId;
                userNotification.NotificationId = notification.Id;

                _context.UserNotifications.Add(userNotification);
                _context.SaveChanges();
            }

            _hubContext.Clients.All.InvokeAsync("displayNotification","");
        }

        public List<NotificationApplicationUser> GetUserNotifications(string userId)
        {
            return _context.UserNotifications.Where(u=>u.ApplicationUserId.Equals(userId) && !u.IsRead)
                                            .Include(n=>n.Notification)
                                            .ToList();
        }

        public void ReadNotification(int notificationId, string userId)
        {
            var notification = _context.UserNotifications
                                        .FirstOrDefault(n=>n.ApplicationUserId.Equals(userId) 
                                        && n.NotificationId==notificationId);
            notification.IsRead = true;
            _context.UserNotifications.Update(notification);
            _context.SaveChanges();
        }
    }
}