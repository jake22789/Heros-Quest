Graph map = new Graph();
void buildMap()
{
    map.AddEdge("A", "B", 1);
    map.AddEdge("A", "C", 2);
    map.AddEdge("B", "D", 3);
    map.AddEdge("C", "D", 4);
    map.AddEdge("D", "E", 5);
    map.AddEdge("F", "E", 6);
    map.AddEdge("G", "F", 7);
    map.AddEdge("H", "G", 8);
    map.AddEdge("I", "D", 9);
    map.AddEdge("J", "E", 10);
    map.AddEdge("K", "A", 11);
    map.AddEdge("L", "K", 12);
    map.AddEdge("M", "K", 13);
    map.AddEdge("N", "L", 14);
    map.AddEdge("O", "L", 15);
    map.AddEdge("P", "L", 16);
    map.AddEdge("Q", "M", 17);
    map.AddEdge("R", "M", 18);
    map.AddEdge("S", "M", 19);
    map.AddEdge("T", "S", 20);
    map.AddEdge("U", "T", 2);
    map.AddEdge("V", "P", 3);
    map.AddEdge("W", "V", 5);
    map.AddEdge("X", "V", 5);
    map.AddEdge("Y", "J", 19);
    map.AddEdge("Z", "Y", 20);
}
buildMap();
Stack<Item> items = new Stack<Item>();
void buildItems(){
 items.Push(new Item("health pot", "",20,"Health"));
 items.Push(new Item("cape", "",100,"Health"));
 items.Push(new Item("book", "",10,"Intelegence"));
 items.Push(new Item("gun", "",15,"Strength"));
 items.Push(new Item("horse", "",15,"Agility"));
 items.Push(new Item("armor", "",10,"Health"));
 items.Push(new Item("gemstone", "",5,"Agility"));
 items.Push(new Item("coin", "",5,"Intelegence"));
 items.Push(new Item("hope", "",5,"Health"));
 items.Push(new Item("picture", "",5,"Intelegence"));
 items.Push(new Item("bow", "",5,"Strength"));
 items.Push(new Item("bottle", "",2,"Intelegence"));
 items.Push(new Item("sheild", "",10,"Health"));
 items.Push(new Item("technoblade", "",10,"Strength"));
 items.Push(new Item("anger", "",5,"Strength"));
 items.Push(new Item("freindship", "",5,"Intelegence"));
 items.Push(new Item("cat", "",3,"Agility"));
 items.Push(new Item("knife", "",2,"Strength"));
 items.Push(new Item("key", "",10,"Intelegence"));
 items.Push(new Item("rock", "",3,"Strength"));
 items.Push(new Item("glasses", "",1,"Intelegence"));
}
buildItems();
CustomBinaryTree challanges = new CustomBinaryTree();
void buildChalanges()
{
challanges.Insert(1,new Challenge( EncounterType.Puzzle, 2,new Item("glasses", "",1,"Intelegence") , "Intelegence" ));
challanges.Insert(2,new Challenge( EncounterType.Combat, 2,new Item("rock", "",3,"Strength") , "Strength" ));
challanges.Insert(3,new Challenge( EncounterType.Puzzle, 2,new Item("key", "",10,"Intelegence") , "Intelegence" ));
challanges.Insert(4,new Challenge( EncounterType.Combat, 2,new Item("knife", "",2,"Strength") , "Strength" ));
challanges.Insert(5,new Challenge( EncounterType.Trap, 2,new Item("cat", "",3,"Agility") , "Agility" ));
challanges.Insert(6,new Challenge( EncounterType.Puzzle, 2,new Item("freindship", "",5,"Intelegence") , "Intelegence" ));
challanges.Insert(7,new Challenge( EncounterType.Combat, 2,new Item("anger", "",5,"Strength") , "Strength" ));
challanges.Insert(8,new Challenge( EncounterType.Combat, 2,new Item("technoblade", "",10,"Strength") , "Strength" ));
challanges.Insert(9,new Challenge( EncounterType.Puzzle, 2,new Item("sheild", "",10,"Health") , "Health" ));
challanges.Insert(10,new Challenge( EncounterType.Puzzle, 2,new Item("bottle", "",2,"Intelegence") , "Intelegence" ));
challanges.Insert(11,new Challenge( EncounterType.Combat, 2,new Item("bow", "",5,"Strength") , "Strength" ));
challanges.Insert(12,new Challenge( EncounterType.Puzzle, 2,new Item("picture", "",5,"Intelegence") , "Intelegence" ));
challanges.Insert(13,new Challenge( EncounterType.Puzzle, 2,new Item("hope", "",5,"Health") , "Health" ));
challanges.Insert(14,new Challenge( EncounterType.Puzzle, 2,new Item("coin", "",5,"Intelegence") , "Intelegence" ));
challanges.Insert(15,new Challenge( EncounterType.Trap, 2,new Item("gemstone", "",5,"Agility") , "Agility" ));
challanges.Insert(16,new Challenge( EncounterType.Combat, 2,new Item("armor", "",10,"Health") , "Health" ));
challanges.Insert(17,new Challenge( EncounterType.Trap, 2,new Item("horse", "",15,"Agility") , "Agility" ));
challanges.Insert(18,new Challenge( EncounterType.Combat, 2,new Item("gun", "",15,"Strength") , "Strength" ));
challanges.Insert(19,new Challenge( EncounterType.Combat, 2,new Item("cape", "",100,"Health") , "Health" ));
challanges.Insert(20,new Challenge( EncounterType.Combat, 2,new Item("health pot", "",20,"Health") , "Health" ));
       
challanges.BalanceBST();
// challanges.PostOrderTraversal();
}
buildChalanges();

Hero Bob = new Hero();

bool win = false;
string priviousRoom = "A";
string currentRoom = "A";
string input;
Random rand = new Random();
while (win != true)
{
    Console.Clear();
    Bob.DisplayHero();
    map.PrintRoom(currentRoom);
    Console.WriteLine("what room would you like to enter: ");
    input = Console.ReadLine().ToUpper();
    if (map.checkroom(currentRoom, input.ToUpper()) == true)
    {
        rand = new Random();
        if(rand.NextDouble() < 0.80 && items != null){
            Item here = items.Pop();
            Console.WriteLine("there is an Item here the :"+ here.name +"would you like this item? :");
            input = Console.ReadLine().ToUpper();
            if(input == "Y"){
                Bob.AddItem(here);
                input = currentRoom;
            }


        }
        priviousRoom = currentRoom;
        currentRoom = input;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("that room is not connected to this one");
        Console.WriteLine();
    }
    // need spawnig items
    // need to implement challenges
    if (currentRoom == "Z")
    {
        Console.WriteLine("you win.");
        win = true;
    }


}
