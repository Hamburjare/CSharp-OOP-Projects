
/// <summary>
///Tämä C#-koodi on yksinkertainen tekstipohjainen roolipeli, jossa pelaaja ottaa roolin ritarina, joka lähetetään kukistamaan kylää uhkaava örkki. Pelaajaa kehotetaan joko hyökkäämään tai puolustautumaan, ja hänen valintansa vaikuttaa sekä pelaajan että örkin terveyteen. Peli päättyy, kun joko pelaajan tai örkin terveys on nolla. Peli käyttää myös Console-luokkaa tulostamaan viestejä konsoliin ja muuttamaan tekstin väriä. Peli käyttää myös satunnaislukugeneraattoria, jolla määritetään annetun vahingon määrä.
/// </summary>

double knightHealth = 15;
double enemyHealth = 15;

Console.ForegroundColor = ConsoleColor.Cyan;

Console.WriteLine("Olet urhea ritari, joka on lähetetty kukistamaan kylää uhkaavan örkin. Löydät örkin kun tulet metsään. Varo örkin hyökkäystä!");

Console.ResetColor();

while (enemyHealth > 0 && knightHealth > 0) {
    AskPlyer();
}

if (enemyHealth <= 0) {
    PrintLine(50);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Örkki on kukistettu!");
    Console.ResetColor();
} else if (knightHealth <= 0) {
    PrintLine(50);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Örkki on voittanut!");
    Console.ResetColor();
}

void AskPlyer() {
    PrintLine(50);
    Console.WriteLine($"Ritari: {knightHealth}/15 Örkki: {enemyHealth}/15");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("1. Hyökkää \n2. Puolusta");
    Console.ResetColor();
    Console.Write("Mitä teet? ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    string? playerChoice = Console.ReadLine();
    Console.ResetColor();
    if (playerChoice == "1") {
        Attack();
    } else if (playerChoice == "2") {
        Defend();
    } else {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nVirheellinen valinta!");
        Console.ResetColor();
        AskPlyer();
    }
}

void Attack() {
    double knightDamage = RandomDamage(1, 5);
    double enemyDamage = RandomDamage(1, 5);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Hyökkäät!");
    RegisterDamage("knight", knightDamage);
    Console.WriteLine($"Teet {knightDamage} vahinkoa örkkiin!");
    Console.ResetColor();
    if (enemyHealth <= 0) 
        return;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Örkki hyökkää!");
    RegisterDamage("enemy", enemyDamage);
    Console.WriteLine($"Örkki tekee {enemyDamage} vahinkoa sinuun!");
    Console.ResetColor();
}

void Defend() {
    double enemyDamage = RandomDamage(1, 5) / 2;
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Puolustaudut!");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Örkki hyökkää!");
    RegisterDamage("enemy", enemyDamage);
    Console.WriteLine($"Örkki tekee {enemyDamage} vahinkoa sinuun!");
    Console.ResetColor();
}

double RandomDamage(int min, int max) {
    Random rnd = new Random();
    double number = rnd.Next(min, max + 1);
    return number;
}

void RegisterDamage(string attacker, double damage) {
    switch (attacker) {
        case "knight":
            enemyHealth -= damage;
            break;
        case "enemy":
            knightHealth -= damage;
            break;

    }

}

void PrintLine(int length)
{
    Console.WriteLine("\n" + new string('-', length));
}
