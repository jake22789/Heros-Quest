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
void buildItems()
{
    items.Push(new Item("health pot", "", 20, "Health"));
    items.Push(new Item("cape", "", 100, "Health"));
    items.Push(new Item("book", "", 10, "Intelegence"));
    items.Push(new Item("gun", "", 15, "Strength"));
    items.Push(new Item("horse", "", 15, "Agility"));
    items.Push(new Item("armor", "", 10, "Health"));
    items.Push(new Item("gemstone", "", 5, "Agility"));
    items.Push(new Item("coin", "", 5, "Intelegence"));
    items.Push(new Item("hope", "", 5, "Health"));
    items.Push(new Item("picture", "", 5, "Intelegence"));
    items.Push(new Item("bow", "", 5, "Strength"));
    items.Push(new Item("bottle", "", 2, "Intelegence"));
    items.Push(new Item("sheild", "", 10, "Health"));
    items.Push(new Item("technoblade", "", 10, "Strength"));
    items.Push(new Item("anger", "", 5, "Strength"));
    items.Push(new Item("freindship", "", 5, "Intelegence"));
    items.Push(new Item("cat", "", 3, "Agility"));
    items.Push(new Item("knife", "", 2, "Strength"));
    items.Push(new Item("key", "", 10, "Intelegence"));
    items.Push(new Item("rock", "", 3, "Strength"));
    items.Push(new Item("glasses", "", 1, "Intelegence"));
}
buildItems();
BinarySearchTree challanges = new BinarySearchTree();
void buildChalanges()
{
    challanges.InsertBalanced(1, new Challenge(EncounterType.Puzzle, 1, new Item("glasses", "", 1, "Intelegence"), "Intelegence"));
    challanges.InsertBalanced(2, new Challenge(EncounterType.Combat, 2, new Item("rock", "", 3, "Strength"), "Strength"));
    challanges.InsertBalanced(3, new Challenge(EncounterType.Puzzle, 3, new Item("key", "", 10, "Intelegence"), "Intelegence"));
    challanges.InsertBalanced(4, new Challenge(EncounterType.Combat, 4, new Item("knife", "", 2, "Strength"), "Strength"));
    challanges.InsertBalanced(5, new Challenge(EncounterType.Trap, 5, new Item("cat", "", 3, "Agility"), "Agility"));
    challanges.InsertBalanced(6, new Challenge(EncounterType.Puzzle, 6, new Item("freindship", "", 5, "Intelegence"), "Intelegence"));
    challanges.InsertBalanced(7, new Challenge(EncounterType.Combat, 7, new Item("anger", "", 5, "Strength"), "Strength"));
    challanges.InsertBalanced(8, new Challenge(EncounterType.Combat, 8, new Item("technoblade", "", 10, "Strength"), "Strength"));
    challanges.InsertBalanced(9, new Challenge(EncounterType.Puzzle, 9, new Item("sheild", "", 10, "Health"), "Health"));
    challanges.InsertBalanced(10, new Challenge(EncounterType.Puzzle, 10, new Item("bottle", "", 2, "Intelegence"), "Intelegence"));
    challanges.InsertBalanced(11, new Challenge(EncounterType.Combat, 11, new Item("bow", "", 5, "Strength"), "Strength"));
    challanges.InsertBalanced(12, new Challenge(EncounterType.Puzzle, 12, new Item("picture", "", 5, "Intelegence"), "Intelegence"));
    challanges.InsertBalanced(13, new Challenge(EncounterType.Puzzle, 13, new Item("hope", "", 5, "Health"), "Health"));
    challanges.InsertBalanced(14, new Challenge(EncounterType.Puzzle, 14, new Item("coin", "", 5, "Intelegence"), "Intelegence"));
    challanges.InsertBalanced(15, new Challenge(EncounterType.Trap, 15, new Item("gemstone", "", 5, "Agility"), "Agility"));
    challanges.InsertBalanced(16, new Challenge(EncounterType.Combat, 16, new Item("armor", "", 10, "Health"), "Health"));
    challanges.InsertBalanced(17, new Challenge(EncounterType.Trap, 17, new Item("horse", "", 15, "Agility"), "Agility"));
    challanges.InsertBalanced(18, new Challenge(EncounterType.Combat, 18, new Item("gun", "", 15, "Strength"), "Strength"));
    challanges.InsertBalanced(19, new Challenge(EncounterType.Combat, 19, new Item("cape", "", 100, "Health"), "Health"));
    challanges.InsertBalanced(20, new Challenge(EncounterType.Combat, 20, new Item("health pot", "", 20, "Health"), "Health"));
    challanges.InOrderTraversal();

    challanges.BalanceTree();
    challanges.InOrderTraversal();
}
buildChalanges();
Hero Bob = new Hero();
Stack<(string, int)> visitedrooms = new Stack<(string, int)>();
bool win = false;
string targetRoom = "A";
string currentRoom = "A";
string input;
int dificulty = 0;
Challenge currentChallenge = new Challenge();

bool IsRoomVisited(string room, int difficulty)
{
    foreach (var (visitedRoom, visitedDifficulty) in visitedrooms)
    {
        if (visitedRoom == room && visitedDifficulty == difficulty)
        {
            return true;
        }
    }
    return false;
}

Random rand = new Random();
while (win != true)
{
    //Console.Clear();
    Bob.DisplayHero();
    map.PrintRoom(currentRoom);
    Console.WriteLine("what room would you like to enter: ");
    input = Console.ReadLine().ToUpper();
    if (map.checkroom(currentRoom, input.ToUpper()) == true)
    {
        targetRoom = input.ToUpper();
        dificulty = map.GetDifficulty(currentRoom, input.ToUpper());
        rand = new Random();
        if (rand.NextDouble() < 0.60 && items.Count == 0 && !IsRoomVisited(targetRoom, dificulty))
        {
            Item here = items.Pop();
            Console.WriteLine("there is an Item here the :" + here.name + "would you like this item? :");
            input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                Bob.AddItem(here);
                input = currentRoom;
            }
        }
        if (!IsRoomVisited(targetRoom, dificulty))
        {

            currentChallenge = challanges.FindClosest(dificulty);
            currentChallenge.DisplayChallengeInfo();


            Console.WriteLine("do you want to try the challenge? (Y/N)");
            input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                if (currentChallenge.passchallange(Bob) == true)
                {

                    Console.WriteLine("you have passed the challenge");
                    challanges.RemoveChallengeRec(currentChallenge.ID);
                    visitedrooms.Push((currentRoom, dificulty));
                    currentRoom = targetRoom;
                    if (challanges.IsEmpty() == true)
                    {
                        Console.WriteLine("you have completed the game");
                        win = true;
                    }

                }
                else
                {
                    Console.WriteLine("you have failed the challenge");
                    Console.WriteLine("you lose " + (dificulty) + " health");
                    Bob.damage(dificulty);
                    if (Bob.GetHealth() <= 0)
                    {
                        win = true;
                    }

                }
            }
            else
            {
                Console.WriteLine("you go back to the previous room");
            }

        }
        else
        {
            currentRoom = targetRoom;
        }

    }
    else
    {
        Console.Clear();
        Console.WriteLine("that room is not connected to this one");
        Console.WriteLine();
    }
    if (currentRoom == "Z")
    {
        Console.WriteLine("you win.");
        win = true;
    }


}
