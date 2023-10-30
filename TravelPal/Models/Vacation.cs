using System;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, bool allInclusive) : base(destination, countries, travellers, startDate, endDate)
        {
            AllInclusive = allInclusive;
        }
        public override string GetInfo()
        {
            return base.GetInfo();
        }

    }
}
