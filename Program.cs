using System;
using System.Collections.Generic;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph unDirectedGraph = new Graph();
            unDirectedGraph.addVertex('A');
            unDirectedGraph.addVertex('B');
            unDirectedGraph.addVertex('C');
            unDirectedGraph.addVertex('D');
            unDirectedGraph.addVertex('E');
            unDirectedGraph.addVertex('F');

            unDirectedGraph.connectVertices(0,1);
            unDirectedGraph.connectVertices(0,3);
            unDirectedGraph.connectVertices(1,2);
            unDirectedGraph.connectVertices(1,3);
            unDirectedGraph.connectVertices(3,4);
            unDirectedGraph.connectVertices(4,5);
            unDirectedGraph.breadthFirstSearch();

        }
    }

   // custom typpe of vertext

   class Vertex{
       public char label;
       public bool isVisited;
       public Vertex(char label){
           this.label = label;
           this.isVisited=false;
       }
   }

   // graph functionality
   class Graph{
       private int maxmumSizeOfVertex=10;
       private Vertex [] verticesStore;
       private int [,] edgeStore;
       private Queue<int> queue;
       private int nVerts;// keep track the number of vertces we have stored

       public Graph(){
           verticesStore= new Vertex[maxmumSizeOfVertex];
           edgeStore= new int[maxmumSizeOfVertex, maxmumSizeOfVertex];
           nVerts=0;
           queue= new Queue<int>();
           
       }
       public void addVertex (char newVertLabel){
           verticesStore[nVerts]= new Vertex(newVertLabel);
           nVerts++;
       }
       public void connectVertices(int startVert, int endVert){
           edgeStore[startVert,endVert]=1;
           edgeStore[endVert,startVert]=1;
       }
       public int checkConnectedVertTo(int removedVert){
           for (int vert = 0; vert < nVerts; vert++)
           {
            if(edgeStore[removedVert,vert] ==1 && verticesStore[vert].isVisited==false){
                return vert;
            }   
           }
           return -1;
       }

       public void displayVertices(int vertIndex){
           Console.Write(verticesStore[vertIndex].label +"   ");
       }

       public void breadthFirstSearch(){
       verticesStore[0].isVisited=true;
       displayVertices(0);
       queue.Enqueue(0);
       int unvisitedVert;
       while (queue.Count!=0)
       {
          int vertTogoOut = queue.Dequeue();
          while ((unvisitedVert= checkConnectedVertTo(vertTogoOut) )!=-1)
          {
             verticesStore[unvisitedVert].isVisited=true;
             displayVertices(unvisitedVert);
             queue.Enqueue(unvisitedVert);
          } 
       }
       }

   }
}
