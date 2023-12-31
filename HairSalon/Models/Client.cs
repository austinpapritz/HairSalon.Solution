using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models;

public class Client
{
    public int ClientId { get; set; }
    [Required]
    public string Name { get; set; }
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
}
