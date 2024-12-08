namespace DataModels.Models;

public class Trainers
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public required string Email { get; set; }
    public required string Password { get; set; } 

    public ICollection<Pupils>? PupilsList { get; set; }
} 