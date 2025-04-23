
public class Challenge
{
    public int ID;
    EncounterType type;
    int difficulty;
    Item alternate;
    string stat;

    public Challenge()
    {
        type = EncounterType.empty;
        difficulty = 0;
        alternate = new Item();
        stat = "health";
    }
    public Challenge(EncounterType _type, int _difficulty, Item _alternate, string _stat)
    {
        type = _type;
        difficulty = _difficulty;
        alternate = _alternate;
        stat = _stat;
    }
    public int GetDifficulty()
    {
        return difficulty;
    }
    public void DisplayChallengeInfo()
    {
        Console.Clear();
        Console.WriteLine("you face a challange");
        Console.WriteLine("dificulty : " + difficulty);
        Console.WriteLine("have at least " + difficulty + " " + stat + " or a " + alternate.name);
    }
    public bool passchallange(Hero hero)
    {
        if (stat == "Health")
        {
            if (hero.GetHealth() >= difficulty)
            {
                Console.WriteLine("you pass the challenge");
                return true;
            }
        }
        else if (stat == "Strength")
        {
            if (hero.GetStrength() >= difficulty)
            {
                Console.WriteLine("you pass the challenge");
                return true;
            }
        }
        else if (stat == "Agility")
        {
            if (hero.GetAgility() >= difficulty)
            {
                Console.WriteLine("you pass the challenge");
                return true;
            }
        }
        else if (stat == "Intelegence")
        {
            if (hero.GetIntelegence() >= difficulty)
            {
                Console.WriteLine("you pass the challenge");
                return true;
            }
        }
        else if (hero.invintory.Contains(alternate))
        {
            Console.WriteLine("you pass the challenge with the " + alternate.name);
            return true;
        }

        return false;

    }
}
