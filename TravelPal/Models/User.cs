﻿using System.Collections.Generic;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Travel> Travels { get; set; }
        public Country Location { get; set; }
    }
}