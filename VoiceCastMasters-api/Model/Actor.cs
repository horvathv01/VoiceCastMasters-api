namespace VoiceCastMasters_api.Model;

public class Actor : User
{
    public Dictionary<Actor, byte> Relations;
    public List<string> SampleURL;
    public bool IsDirector { get; set; } = false;
}