namespace KnightsQuest;

public class Player {
    public int gold = 99999;
    public int level = 0;
    public int experience = 0;
    public int xpToNextLevel = 100;

    public override string ToString()
    {
        return $"Player: {gold} gold, {level} level, {experience} experience, {xpToNextLevel} xp to next level";
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= xpToNextLevel)
        {
            level++;
            experience -= xpToNextLevel;
            xpToNextLevel += 100;
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

}