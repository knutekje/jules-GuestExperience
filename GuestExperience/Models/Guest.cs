using System.ComponentModel.DataAnnotations.Schema;

namespace GuestExperience.Models;


[Table("guest")]
public class Guest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Nationality { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}