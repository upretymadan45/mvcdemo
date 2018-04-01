using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mvcdemo.Data;
using mvcdemo.Models;

namespace mvcdemo.Repository{
    public class WatchlistRepository : IWatchlistRepository
    {
        private ApplicationDbContext _context;
        public WatchlistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckIfAlreadyExists(string userId, int petId)
        {
            return _context.Watchlists.Any(w=>w.UserId.Equals(userId) && w.PetId == petId);
        }

        public void Create(Watchlist watchlist)
        {
            _context.Watchlists.Add(watchlist);
            _context.SaveChanges();
        }

        public List<Watchlist> GetUserWatchlist(string userId)
        {
            return _context.Watchlists
                            .Include(w=>w.Pet)
                            .Where(w=>w.UserId.Equals(userId))
                            .ToList();
        }

        public Watchlist GetWatchlist(int Id)
        {
            return _context.Watchlists.FirstOrDefault(w=>w.Id==Id);
        }

        public List<Watchlist> GetWatchlistFromPetId(int petId)
        {
            return _context.Watchlists.Where(w=>w.PetId == petId).ToList();
        }

        public void Remove(Watchlist watchlist)
        {
            _context.Watchlists.Remove(watchlist);
            _context.SaveChanges();
        }
    }
}