using ClientNotifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcdemo.Models;
using mvcdemo.Repository;
using static ClientNotifications.Helpers.NotificationHelper;

namespace mvcdemo.Controllers{

    [Authorize]
    public class WatchlistController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IWatchlistRepository _watchlistRepository;
        private IClientNotification _clientNotification;
        public WatchlistController(IWatchlistRepository watchlistRepository,
                                    UserManager<ApplicationUser> userManager,
                                    IClientNotification clientNotification)
        {
            _watchlistRepository = watchlistRepository;
            _userManager = userManager;
            _clientNotification = clientNotification;
        }

        public IActionResult Index(){
            var userId = _userManager.GetUserId(HttpContext.User);

            var watchlists = _watchlistRepository.GetUserWatchlist(userId);

            return View(watchlists);
        }

        public IActionResult New(int petId){
            var userId = _userManager.GetUserId(HttpContext.User);

            var watchlist = new Watchlist{
                PetId = petId,
                UserId = userId
            };

            _watchlistRepository.Create(watchlist);

            _clientNotification
                    .AddSweetNotification("Success","Pet has been added to watchlist",NotificationType.success);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id){
            var watchlist = _watchlistRepository.GetWatchlist(id);

            _watchlistRepository.Remove(watchlist);

            _clientNotification
                    .AddSweetNotification("Success","Pet has been removed from watchlist",NotificationType.success);

            return RedirectToAction(nameof(Index));
        }
        
    }
}