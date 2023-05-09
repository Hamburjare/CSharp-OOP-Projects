namespace KnightsQuest;

public class Save {
    public Player player = null!;
    public List<Monster> monsters = null!;
    public List<Item> items = null!;
    public List<Knight> knights = null!;

    public Save(Player player, List<Monster> monsters, List<Item> items, List<Knight> knights) {
        this.player = player;
        this.monsters = monsters;
        this.items = items;
        this.knights = knights;
    }

}