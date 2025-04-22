using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

class Graph
{
    private Dictionary<string, List<(string,int)>> adjList;

    public Graph()
    {
        adjList = new Dictionary<string, List<(string,int)>>();
    }

    public void AddVertex(string vertex)
    {
        if (!adjList.ContainsKey(vertex))
        {
            adjList[vertex] = new List<(string,int)>();
        }
    }

    public void AddEdge(string vertex1, string vertex2, int number)
    {
        AddVertex(vertex1);
        AddVertex(vertex2);

        adjList[vertex1].Add((vertex2, number));
        adjList[vertex2].Add((vertex1, number));
    }

    public void PrintGraph()
    {
        foreach (var vertex in adjList)
        {
            Console.Write(vertex.Key + " -> ");
            Console.WriteLine(string.Join(", ", vertex.Value));
        }
    }
     public void PrintRoom(string room)
    {
        foreach (var vertex in adjList)
        {
            if (vertex.Key.Equals(room)){
            Console.Write(vertex.Key + " -> ");
            Console.WriteLine(string.Join(", ", vertex.Value));
            }
        }
    }
     public bool checkroom(string here,string there)
    {
        foreach (var vertex in adjList)
        {
            //Console.WriteLine(vertex.Key+":"+here);
            if (vertex.Key == here){
                foreach(var (room,difficulty) in vertex.Value){
                    //Console.WriteLine(room+":"+there);
                    if(room == there){
                        //Console.WriteLine("2 true");
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public int GetDifficulty(string vertex, string targetRoom)
    {
        if (adjList.ContainsKey(vertex))
        {
            foreach (var (room, difficulty) in adjList[vertex])
            {
                if (room == targetRoom)
                {
                    return difficulty;
                }
            }
        }
        throw new Exception($"Room '{targetRoom}' not found in connections of '{vertex}'.");
    }
}

