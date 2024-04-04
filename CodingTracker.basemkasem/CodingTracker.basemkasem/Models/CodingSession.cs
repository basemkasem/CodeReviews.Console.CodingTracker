namespace CodingTracker.basemkasem.Models;

internal class CodingSession
{
    public int SessionId { get; set; }
    public DateTime SessionDate { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public TimeOnly Duration { get; set;}
}
