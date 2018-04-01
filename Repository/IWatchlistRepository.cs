using System.Collections.Generic;
using mvcdemo.Models;

namespace mvcdemo.Repository{
    public interface IWatchlistRepository
    {
        Watchlist GetWatchlist(int Id);
        void Create(Watchlist watchlist);
        List<Watchlist> GetUserWatchlist(string userId);
        void Remove(Watchlist watchlist);
        bool CheckIfAlreadyExists(string userId, int petId);
        List<Watchlist> GetWatchlistFromPetId(int petId);
    }
}