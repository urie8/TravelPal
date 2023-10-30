using System;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }
        public WorkTrip(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, string meetingDetails) : base(destination, countries, travellers, startDate, endDate)
        {
            MeetingDetails = meetingDetails;
        }
        public override string GetInfo()
        {
            return base.GetInfo();
        }
    }
}
