namespace HairSalon.Models;

public class Stylist
{
    public int StylistId { get; set; }
    public string? Name { get; set; }
    public ICollection<Client> Clients { get; set; }
}
