﻿namespace TravelPal.Models
{
    public class TravelDocument : PackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public TravelDocument(string name, bool required)
        {
            Name = name;
            Required = required;
        }
        public string GetInfo()
        {
            if (Required)
            {
                return $"{Name} | Required";
            }
            return $"{Name}";
        }
    }
}
