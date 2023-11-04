using System;
using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Models;
using TravelPal.Utilities;

namespace TravelPal.Repositories
{
    public static class UserManager
    {
        public static List<IUser> Users { get; set; } = new()
        {
            new User("user","password", Enums.Country.Sweden)
            {
                Travels = new List<Travel>{

                new WorkTrip("New York",Country.UnitedStates,4,DateTime.Now,new DateTime(2023,11,05),"Meeting with the president.")
                {
                    PackingList = new List<PackingListItem>
                    {
                        new OtherItem("Soap",4),
                        new TravelDocument("Visa",true)
                    }
                },

                new Vacation("Tokyo",Country.Japan,4,DateTime.Now,new DateTime(2023,12,6),true)
                {
                    PackingList = new List<PackingListItem>
                    {
                        new OtherItem("Soap",4),
                        new TravelDocument("Visa",true)
                    }
                }

                }

            },

            new Admin("admin","password")

        };
        public static IUser? CurrentSignedInUser { get; set; }

        public static IUser? AddUser(string username, string password, Country country)
        {
            if (ValidateUsername(username))
            {
                User newUser = new(username, password, country);

                Users.Add(newUser);

                return newUser;

            }

            throw new InvalidUsernameException("Username is already taken");
        }

        public static void RemoveUser(IUser user)
        {
            Users.Remove(user);
        }

        //public static bool UpdateUsername()
        //{

        //}

        private static bool ValidateUsername(string username)
        {
            bool isValidUsername = true;

            foreach (var user in Users)
            {
                if (username.Equals(user.Username))
                {
                    isValidUsername = false;
                }

            }

            return isValidUsername;
        }

        public static bool SignInUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    CurrentSignedInUser = user;
                    return true;
                }
            }
            return false;
        }
    }
}
