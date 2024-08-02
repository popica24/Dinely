namespace Dinely.Domain.DinnerAggregate.ValueObjects;

public class Location
{
    public string Name { get; set; }
    public string Address { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }

    private Location(string name, string address, float latitude, float longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(string name, string address, float latitude, float longitude)
    {
        return new(name, address, latitude, longitude);
    }
}
