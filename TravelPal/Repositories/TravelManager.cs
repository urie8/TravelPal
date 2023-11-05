using System.Collections.Generic;
using System.Linq;
using TravelPal.Models;

namespace TravelPal.Repositories
{
    public static class TravelManager
    {
        // Adds all the travels of user to the travels list using LINQ
        public static List<Travel> Travels { get; set; } = UserManager.Users.Where(u => u.GetType() == typeof(User)).SelectMany(u => ((User)u).Travels).ToList();

        public static void AddTravel(Travel travel)
        {
            Travels.Add(travel);
        }

        public static void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
        }
    }
}
