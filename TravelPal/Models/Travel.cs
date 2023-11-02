using System;
using System.Collections.Generic;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public Country Country { get; set; }
        public int Travellers { get; set; }
        public List<PackingListItem> PackingList { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TravelDays { get; set; }
        public Guid Id { get; set; } = new Guid();

        public Travel(string destination, Country country, int travellers, DateTime startDate, DateTime endDate)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
            StartDate = startDate;
            EndDate = endDate;
        }

        public virtual string GetInfo()
        {
            return $"{Destination} {Country} {StartDate.ToShortDateString()} to {EndDate.ToShortDateString()}";
        }

        private int CalculateTravelDays()
        {
            return 0;
        }
    }
}
