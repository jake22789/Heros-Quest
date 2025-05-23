using System;
public class BinarySearchTree
{

    public Node Root;

    public BinarySearchTree()
    {
        Root = null;
    }

    // Insert a new value into the BST
    public void InsertBalanced(int value, Challenge trial)
    {
        Root = InsertBalanced(Root, value, trial);
    }

    private Node InsertBalanced(Node root, int value, Challenge trial)
    {
        if (root == null)
        {
            root = new Node(value, trial);
            return root;
        }

        if (value < root.ID)
            root.Left = InsertBalanced(root.Left, value, trial);
        else if (value > root.ID)
            root.Right = InsertBalanced(root.Right, value, trial);

        return root;
    }

    public void BalanceTree()
    {
        List<Node> nodes = new List<Node>();
        StoreInOrder(Root, nodes);
        Root = BuildBalancedTree(nodes, 0, nodes.Count - 1); // Rebuild the tree
    }

    private void StoreInOrder(Node root, List<Node> nodes)
    {
        if (root == null)
            return;

        StoreInOrder(root.Left, nodes);
        nodes.Add(root);
        StoreInOrder(root.Right, nodes);
    }

    private Node BuildBalancedTree(List<Node> nodes, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        Node node = nodes[mid];

        node.Left = BuildBalancedTree(nodes, start, mid - 1);
        node.Right = BuildBalancedTree(nodes, mid + 1, end);

        return node;
    }



    public bool Search(int value)
    {
        return SearchRec(Root, value);
    }

    private bool SearchRec(Node root, int value)
    {
        if (root == null)
            return false;

        if (root.ID == value)
            return true;

        if (value < root.ID)
            return SearchRec(root.Left, value);

        return SearchRec(root.Right, value);
    }


    public void InOrderTraversal()
    {

        InOrderRec(Root);
    }

    private void InOrderRec(Node root)
    {

        if (root != null)
        {
            InOrderRec(root.Left);
            Console.WriteLine(root.ID + " ");
            InOrderRec(root.Right);
        }
    }

    public Challenge FindClosest(int value)
    {
        return FindClosestRec(Root, value, Root).thing;
    }

    private Node FindClosestRec(Node root, int value, Node closest)
    {
        if (root == null)
            return closest;

       
        if (Math.Abs(root.ID - value) < Math.Abs(closest.ID - value))
            closest = root;

        
        if (value < root.ID)
            return FindClosestRec(root.Left, value, closest);
        else
            return FindClosestRec(root.Right, value, closest);
    }

    public void RemoveChallengeRec(int value)
    {
        Root = RemoveChallengeRec(Root, value);
    }

    private Node RemoveChallengeRec(Node root, int value)
    {
        if (root == null)
            return root;

        // Traverse the tree to find the node to remove
        if (value < root.ID)
            root.Left = RemoveChallengeRec(root.Left, value);
        else if (value > root.ID)
            root.Right = RemoveChallengeRec(root.Right, value);
        else
        {
            // Node with only one child or no child
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            // Node with two children: Get the in-order successor (smallest in the right subtree)
            Node successor = FindMin(root.Right);

            // Copy the successor's data to this node
            root.ID = successor.ID;
            root.thing = successor.thing;

            // Delete the successor
            root.Right = RemoveChallengeRec(root.Right, successor.ID);
        }

        return root;
    }

    // Helper function to find the minimum value node in a subtree
    private Node FindMin(Node root)
    {
        Node current = root;

        // Loop to find the leftmost leaf
        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }
    public bool IsEmpty(){
        if (Root == null)
            return true;
        else
            return false;
    }




}