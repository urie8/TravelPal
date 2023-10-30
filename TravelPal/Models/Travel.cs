using System;
using System.Collections.Generic;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public Country Countries { get; set; }
        public int Travellers { get; set; }
        public List<PackingListItem> PackingList { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelDays { get; set; }

        public Travel(string destination, Country countries, int travellers)
        {
            Destination = destination;
            Countries = countries;
            Travellers = travellers;
        }

        public virtual string GetInfo()
        {
            return Destination;
        }

        private int CalculateTravelDays()
        {
            return 0;
        }
    }
}
