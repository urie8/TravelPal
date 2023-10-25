namespace TravelPal.Models
{
    public class OtherItem : PackingListItem
    {
        public string Name { get; set; }
        public OtherItem(string name)
        {
            Name = name;
        }
        public string GetInfo()
        {
            return Name;
        }
    }
}
