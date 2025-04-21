public class Node
{
    public int ID { get; set; }
    public Challenge thing = new Challenge();
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int data , Challenge obstical)
    {
        ID = data;
        thing = obstical;
        Left = null;
        Right = null;
    }
    public Node(Challenge obstical)
    {
        ID = obstical.GetDifficulty();
        thing = obstical;
        Left = null;
        Right = null;
    }

}
