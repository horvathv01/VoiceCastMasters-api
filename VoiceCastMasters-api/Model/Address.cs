using VoiceCastMasters_api.Enums;

namespace VoiceCastMasters_api.Model;

public class Address
{
    public string Country { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    
    public Roles Role { get; set; }

    public Address(string country, string zip, string city, string street, string role)
    {
        Country = country;
        Zip = zip;
        City = city;
        Street = street;
        try
        {
            Role = Enum.Parse<Roles>(role);
        }
        catch (Exception e)
        {
            Role = Roles.Actor;
        }
    }
}