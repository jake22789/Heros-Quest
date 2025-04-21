using System.Runtime;

public class Item{
    public string name { get; set;}
    public string description { get; set;} 
    public string statTarget {get;set;} 
    public int effectmod {get; set;}
    public Item(string _name, string _description,int _effect,string _statTarget) 
    {
        name = _name;
        description = _description;
        effectmod = _effect;
        statTarget = _statTarget;
    }
    public Item() 
    {
        name = "blank";
        description = "";
        effectmod = 0;
        statTarget = "";
    }

    
}