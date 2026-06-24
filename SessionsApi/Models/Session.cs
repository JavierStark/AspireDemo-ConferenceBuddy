namespace SessionsApi.Models;

public class Session
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SpeakerName { get; set; } = string.Empty;
    public string SpeakerBio { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];
    public int MaxAttendees { get; set; }
    public bool IsBookmarked { get; set; }
}
