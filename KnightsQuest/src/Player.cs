namespace KnightsQuest;

public class Player {
    public int gold = 99999;
    public int level = 5;
    public int experience = 0;
    public int xpToNextLevel = 100;
    
    public override string ToString()
    {
        return $"Player: {gold} gold, {level} level, {experience} experience, {xpToNextLevel} xp to next level";
    }

    /// <summary>
    /// Add experience to the player.
    /// </summary>
    /// <param name="amount">Amount of experience to add.</param>    
    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= xpToNextLevel)
        {
            // Level up
            level++;
            experience -= xpToNextLevel;
            xpToNextLevel += 100;
        }
    }

    /// <summary>
    /// Add gold to the player.
    /// </summary>
    /// <param name="amount">Amount of gold to add.</param>
    public void AddGold(int amount)
    {
        gold += amount;
    }

}