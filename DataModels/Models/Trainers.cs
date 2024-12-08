namespace DataModels.Models;

public class Trainers
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public required string Email { get; set; }
    public required string Password { get; set; } 

    // Relacja: Jeden trener ma wielu podopiecznych
    public ICollection<Pupils>? Pupils { get; set; }
} 