using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mvcdemo.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Pet> Pets { get; set; }
        public List<Watchlist> Watchlists { get; set; }
        public List<NotificationApplicationUser> NotificationApplicationUsers { get; set; }
        
    }
}
