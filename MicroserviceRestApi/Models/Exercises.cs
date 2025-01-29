namespace MicroserviceRestApi.Models;

public class Exercises
{
    public int Id { get; set; }
    public required string Label { get; set; }
    public required string Weight { get; set; }

    public int Reps { get; set; }
    public string? Comment { get; set; }
} 