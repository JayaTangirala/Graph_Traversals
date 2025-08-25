using System.IO;

public class Graph
{
   public static void Main(string[] args)
    {
        int n, m;
        Console.WriteLine("Enter Number of vertices");
        n=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Number of edges");
        m = Convert.ToInt32(Console.ReadLine());
        int[] vertices = new int[n];
        int[,] A = new int[n, n];
        bool[] visited = new bool[n];

        //Read from console
        //A = ReadFromConsole(n,m);

        //Read from file        
        string fileName = "C:\\Users\\jt3951\\Desktop\\edge_list1.txt";
        A = ReadFromFile(n, m, fileName);

        Console.WriteLine("Adj Matrix");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < n; j++)
                Console.Write(A[i, j] + " ");
        }
         Console.WriteLine("\nDFS");        
        //for loop to handle disconnected Graph
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
                DFS(A, n, visited, i);
        }
        for (int i = 0; i < n; i++)
        {
            visited[i] = false;
        }
        Console.WriteLine();
        Console.WriteLine("BFS");
        //for loop to handle disconnected Graph
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
                BFS(A, n, visited, i);
        }
    }
    public static int [,] ReadFromConsole(int n, int m)
    {
        int s, d;
        int[,] A = new int[n, n];
        Console.WriteLine("Enter Edges");
        for (int i = 0; i < m; i++)
        {            
            string[] edge = Console.ReadLine().Split(' ');
            s = Convert.ToInt32(edge[0]);
            d = Convert.ToInt32(edge[1]);
            A[s, d] = 1;
            A[d, s] = 1;            
        }
        return A;
    }
    public static int[,] ReadFromFile(int n, int m, string fileName)
    {
        int s, d;
        int[,] A = new int[n, n];                

        if (File.Exists(fileName))
        {
            StreamReader sr = new StreamReader(File.OpenRead(fileName));                       

            while (!sr.EndOfStream)
            {
                string[] edge = sr.ReadLine().Split(' ');
                s = Convert.ToInt32(edge[0]);
                d = Convert.ToInt32(edge[1]);
                A[s, d] = 1;
                A[d, s] = 1;
            }                              
        }
        return A;       
    }
    public static void DFS(int[,] A, int n, bool[] visited, int si)
    {
        visited[si] = true;
        Console.Write(si + " ");
        for (int i = 0; i < n; i++)
        {
            if (i == si)
                continue;
            if (!visited[i] && A[si, i] == 1)
            {
                DFS(A, n, visited, i);
            }
        }
    }
    public static void BFS(int[,] A, int n, bool[] visited, int si)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(si);
        visited[si] = true;
        while (queue.Count != 0)
        {
            int currentVertex = queue.Dequeue();
            Console.Write(currentVertex + " ");
            for (int i = 0; i < n; i++)
            {
                if (i == currentVertex)
                    continue;
                if (!visited[i] && A[currentVertex, i] == 1)
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                }
            }
        }
    }
}