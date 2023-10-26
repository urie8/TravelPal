using System.Collections.Generic;
using TravelPal.Models;

namespace TravelPal.Repositories
{
    public static class TravelManager
    {
        public static List<Travel> Travels { get; set; } = new();


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
