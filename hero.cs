using System.ComponentModel.DataAnnotations;

public class Hero
{
    int strength { get; set;}
    int agility { get; set;}
    int intelegence { get; set;}
    int health { get; set;}

    Queue<Item> invintory = new Queue<Item>();

    public Hero(){
        strength = 1;
        agility = 1;
        intelegence = 1;
        health = 20;
        invintory.Enqueue(new Item("sword","deal +5 damage",5,"strength"));
        invintory.Enqueue(new Item("Health Potion","heal 10 damage",10,"health"));
    }
    public void DisplayHero(){
        foreach(var item in invintory){
            if(item.statTarget.Equals("strength")){
                strength += item.effectmod;
            }
            if(item.statTarget.Equals("health")){
                health += item.effectmod;
            }
            if(item.statTarget.Equals("intelegence")){
                intelegence += item.effectmod;
            }
            if(item.statTarget.Equals("agility")){
                agility += item.effectmod;
            }
        }
        Console.WriteLine("Strength :  "+strength);
        Console.WriteLine("Agility :  "+agility);
        Console.WriteLine("Intelegence :  "+intelegence);
        Console.WriteLine( "Health :  "+ health);
        foreach(var item in invintory){
            Console.WriteLine(item.name +": "+item.description);
        }
    }
    public void AddItem(Item newthing){
        if (invintory.Count <= 5){
            invintory.Dequeue();
        }
        invintory.Enqueue(newthing);
    }
}