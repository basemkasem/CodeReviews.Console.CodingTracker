namespace CodingTracker;

internal class CodingSession
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Duration 
    { 
        get
        {
            return(int)(EndTime - StartTime).TotalSeconds;
        }
    }

    public CodingSession(){ }

    public CodingSession(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        if (endTime > startTime)
        {
            EndTime = endTime;
        }
    }

    public override string ToString()
    {
        return $"ID: {Id}, Start Time: {StartTime}, End Time: {EndTime}";
    }
}
