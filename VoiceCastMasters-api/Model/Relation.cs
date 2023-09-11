using System.ComponentModel.DataAnnotations.Schema;

namespace VoiceCastMasters_api.Model;

public class Relation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; } 
    public long Actor1Id { get; set; }
    public Actor Actor1 { get; set; }
    public long Actor2Id { get; set; }
    public Actor Actor2 { get; set; }
    public int Percentage { get; set; }
    
    public Relation()
    {
        
    }

    public Relation(Actor actor1, Actor actor2, int percentage)
    {
        Actor1 = actor1;
        Actor2 = actor2;
        Actor1Id = actor1.ID;
        Actor2Id = actor2.ID;
        Percentage = percentage;
    }

    
}