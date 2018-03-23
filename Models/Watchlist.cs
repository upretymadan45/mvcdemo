using System;

namespace mvcdemo.Models{
    public class Watchlist
    {
     public int Id { get; set; }   
     public int PetId { get; set; }
     public Pet Pet { get; set; }
     public string UserId { get; set; }
     public ApplicationUser User { get; set; }
     public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}