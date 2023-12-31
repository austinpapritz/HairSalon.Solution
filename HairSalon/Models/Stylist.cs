using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models;

public class Stylist
{
    public Stylist()
    {
        Clients = new List<Client>();
    }

    public int StylistId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Specialty { get; set; }
    [Required]
    public decimal Wage { get; set; }
    public ICollection<Client> Clients { get; set; }
}
