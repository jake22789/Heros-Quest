using System.ComponentModel.DataAnnotations;
public class Hero
{
    int strength { get; set;}
    int agility { get; set;}
    int intelegence { get; set;}
    int health { get; set;}

     public Queue<Item> invintory = new Queue<Item>();

    public Hero(){
        strength = 5;
        agility = 5;
        intelegence = 5;
        health = 20;
        invintory.Enqueue(new Item("sword","deal +5 damage",5,"Strength"));
        invintory.Enqueue(new Item("Health Potion","heal 10 damage",10,"Health"));
    }
    public void damage(int ammount){
        health -= ammount;
        if(health <= 0){
            Console.WriteLine("you have died");
        }
    }
    public void DisplayHero(){
        var strength_ = strength; 
        var agility_ = agility;
        var intelegence_ = intelegence;
        var health_ = health;
        foreach(var item in invintory){
            if(item.statTarget.Equals("strength")){
                 strength_ += item.effectmod;
            }
            if(item.statTarget.Equals("health")){
                 health_ += item.effectmod;
            }
            if(item.statTarget.Equals("intelegence")){
                 intelegence_ += item.effectmod;
            }
            if(item.statTarget.Equals("agility")){
                 agility_ += item.effectmod;
            }
        }
        Console.WriteLine("Strength :  "+strength_);
        Console.WriteLine("Agility :  "+agility_);
        Console.WriteLine("Intelegence :  "+intelegence_);
        Console.WriteLine( "Health :  "+ health_);
        foreach(var item in invintory){
            Console.WriteLine(item.name +": "+item.description);
        }
    }
    public void AddItem(Item newthing){
        if (invintory.Count >= 5){
            Item oldThing = invintory.Dequeue();
            if (oldThing.statTarget.Equals("Health")){
                health +=oldThing.effectmod;
            }
            if (oldThing.statTarget.Equals("Agility")){
                agility +=oldThing.effectmod;
            }
            if (oldThing.statTarget.Equals("Intelegence")){
                intelegence +=oldThing.effectmod;
            }
            if (oldThing.statTarget.Equals("Strength")){
                strength +=oldThing.effectmod;
            }
        }
        invintory.Enqueue(newthing);
    }

    public int GetStrength()
    {
        return strength;
    }

    public int GetAgility()
    {
        return agility;
    }

    public int GetIntelegence()
    {
        return intelegence;
    }

    public int GetHealth()
    {
        return health;
    }
}