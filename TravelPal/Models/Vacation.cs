using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, Country countries, int travellers, bool allInclusive) : base(destination, countries, travellers)
        {
            AllInclusive = allInclusive;
        }
        public override string GetInfo()
        {
            return base.GetInfo();
        }

    }
}
