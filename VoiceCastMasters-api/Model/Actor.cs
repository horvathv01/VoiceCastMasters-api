namespace VoiceCastMasters_api.Model;

public class Actor : User
{
    public Dictionary<Actor, byte> Relations { get; set; }
    public List<string> SampleURL { get; set; }
    public bool IsDirector { get; set; } = false;
}