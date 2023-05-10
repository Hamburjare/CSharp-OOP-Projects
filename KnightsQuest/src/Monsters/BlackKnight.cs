namespace KnightsQuest;
    public class BlackKnight : Monster
    {
        public override string? name { get; set; } = "Black Knight";
        public override int health { get; set; } = 100;
        public override int defaultHealth { get; set; } = 100;
        public override int maxAttack { get; set; } = 20;
        public override int minAttack { get; set; } = 5;
        public override int minLevel { get; set; } = 5;
    }
