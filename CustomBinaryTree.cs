public class CustomBinaryTree
{
    public Node? RootNode { get; set; }
    public int DepthCounter { get; set; }


    public CustomBinaryTree()
    {
        RootNode = null;
    }

    public void Insert(int data, Challenge item)
    {
        RootNode = InsertNode(RootNode, data, item);
    }

    public Node InsertNode(Node node, int data, Challenge item)
    {
        if (node == null)
        {
            return new Node(data, item);
        }

        if (data < node.ID)
        {
            node.Left = InsertNode(node.Left, data, item);
        }
        else if (data > node.ID)
        {
            node.Right = InsertNode(node.Right, data, item);
        }

        return node;
    }

    public void InsertIteratively(int data, Challenge thing)
    {
        if (RootNode == null)
        {
            RootNode = new Node(data, thing);
            return;
        }

        Node current = RootNode;
        while (true)
        {
            if (data < current.ID)
            {
                if (current.Left == null)
                {
                    current.Left = new Node(data, thing);
                    return;
                }
                current = current.Left;
            }
            else if (data > current.ID)
            {
                if (current.Right == null)
                {
                    current.Right = new Node(data,thing);
                    return;
                }
                current = current.Right;
            }
            else
            {
                return;
            }
        }
    }

    public void DeleteNode(Node target)
    {
        DeleteNode(target.ID);
    }

    public void DeleteNode(int target)
    {
        RootNode = DeleteNode(RootNode, target);
    }
    public Node? DeleteNode(Node currentNode, int target)
    {
        if (currentNode == null)
        {
            return currentNode;
        }

        if (target < currentNode.ID)
        {
            currentNode.Left = DeleteNode(currentNode.Left, target);//search left
        }
        else if (target > currentNode.ID)
        {
            currentNode.Right = DeleteNode(currentNode.Right, target);//search right
        }
        else
        {
            //Found the number

            //Leaf
            if (currentNode.Left == null && currentNode.Right == null)
            {
                return null;
            }

            // 1 Child
            if (currentNode.Left == null || currentNode.Right == null)
            {
                //Node? result = currentNode.Left == null ? currentNode.Right : currentNode.Left;
                return currentNode.Left == null ? currentNode.Right : currentNode.Left;
            }

            // 2 Children
            currentNode.ID = GetMinValue(currentNode.Right);
            currentNode.Right = DeleteNode(currentNode.Right, currentNode.ID);

        }

        return currentNode;
    }

    public bool IsBalanced()
    {
        return CheckHeight(RootNode) != -1;
    }


    public int CheckHeight(Node? node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftHeight = CheckHeight(node.Left);
        if (leftHeight == -1)
        {
            return -1;
        }

        int rightHeight = CheckHeight(node.Right);
        if (rightHeight == -1)
        {
            return -1;
        }

        if (Math.Abs(leftHeight - rightHeight) > 1)
        {
            return -1;
        }

        return Math.Max(leftHeight, rightHeight) + 1;
    }

public static Node BuildBalancedBST(List<Challenge> sortedList, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;

        Challenge midChallenge = sortedList[mid];

        Node node = new Node(midChallenge.ID,midChallenge);

        // Recursively build the left and right subtrees
        node.Left = BuildBalancedBST(sortedList, start, mid - 1);
        node.Right = BuildBalancedBST(sortedList, mid + 1, end);

        return node;
    }
     public void BalanceBST()
    {
        List<Challenge> sortedList = new List<Challenge>();

        InOrderTraversal(RootNode, sortedList);

        RootNode = BuildBalancedBST(sortedList, 0, sortedList.Count - 1);
    }

    public void InOrderTraversal(Node? node,List<Challenge> result)
    {
        if (node == null)
        {
            return;
        }
        
        InOrderTraversal(node.Left,result);
        result.Add(node.thing);
        InOrderTraversal(node.Right,result);
    }
    public void printInOrderTraversal(){
        printInOrderTraversal(RootNode);
    }
    public void printInOrderTraversal(Node? node)
    {
        if (node == null)
        {
            return;
        }

        printInOrderTraversal(node.Left);
        node.thing.DisplayChallengeInfo();
        printInOrderTraversal(node.Right);
    }

    public void DescendingOrder()
    {
        DescendingOrder(RootNode);
    }
    public void DescendingOrder(Node? node)
    {
        if (node == null)
        {
            return;
        }

        DescendingOrder(node.Right);
        Console.WriteLine(node.ID);
        DescendingOrder(node.Left);
    }


    public void PostOrderTraversal()
    {
        PostOrderTraversal(RootNode);
    }
    public void PostOrderTraversal(Node? node)
    {
        if (node == null)
        {
            return;
        }

        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.WriteLine(node.ID);
    }


    public void PreOrderTraversal()
    {
        PreOrderTraversal(RootNode);
    }
    public void PreOrderTraversal(Node? node)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine(node.ID);
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }

    public void LevelOrderTraversal()
    {
        if (RootNode == null)
        {
            return;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(RootNode);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            Console.WriteLine(current.ID);

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }

    public bool Search(int target)
    {
        return SearchRecursive(RootNode, target);
    }

    public bool SearchRecursive(Node node, int target)
    {
        if (node == null)
        {
            Console.WriteLine("");
            Console.WriteLine("Error that ID is unused");
            return false;
        }
        DepthCounter++;

        //NODE
        if (target == node.ID)
        {
            node.thing.DisplayChallengeInfo();
            return true;
        }
        //LEFT
        if (target < node.ID)
        {
            return SearchRecursive(node.Left, target);
        }
        //RIGHT
        else
        {
            return SearchRecursive(node.Right, target);
        }
            
        
    }

    public int GetMinValue(Node? currentNode)
    {
        if (currentNode == null)
        {
            throw new ArgumentNullException(nameof(currentNode), "Tree is empty.");
        }

        while (currentNode.Left != null)
        {
            currentNode = currentNode.Left;
        }

        return currentNode.ID;
    }


    public int GetMaxValue()
    {
        Node result = RootNode;

        while (result.Right != null)
        {
            result = result.Right;
        }
        return result.ID;
    }
}
