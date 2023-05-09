namespace KnightsQuest;

public class Player {
    public int gold = 0;
    public int level = 0;
    public int experience = 0;
    public int xpToNextLevel = 100;
    
    public List<Item> inventory = new List<Item>();


    public override string ToString()
    {
        return $"Player: {gold} gold, {level} level, {experience} experience, {xpToNextLevel} xp to next level";
    }

}