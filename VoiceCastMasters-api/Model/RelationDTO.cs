namespace VoiceCastMasters_api.Model;

public class RelationDTO
{
    
        public long Id { get; } 
        public long Actor1 { get; set; }
        public long Actor2 { get; set; }
        public int Percentage { get; set; }

        public RelationDTO(Actor actor1, Actor actor2, int percentage, long id = 0)
        {
            Actor1 = actor1.ID;
            Actor2 = actor2.ID;
            Percentage = percentage;
            id = id;
        }

        public RelationDTO(Relation relation)
        {
            Id = relation.Id;
            Actor1 = relation.Actor1.ID;
            Actor2 = relation.Actor2.ID;
            Percentage = relation.Percentage;
        }

        public RelationDTO(long actor1, long actor2, int percentage, long id = 0)
        {
            Actor1 = actor1;
            Actor2 = actor2;
            Percentage = percentage;
            id = id;
        }

        public override string ToString()
        {
            return $"Relation {Id} between actor {Actor1} and {Actor2} percentage: {Percentage}%.";
        }
}