using System.Collections.Generic;
using TravelPal.Models;

namespace TravelPal.Repositories
{
    public static class UserManager
    {
        public static List<IUser> Users { get; set; } = new();
    }
}
