using Leets;
namespace Leets
{
    public class Program
    {
        public static void Main()
        {


            //int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];
            //int[] newInt = [4, 8];

            //InsertIntervals ins = new();

            //ins.Insert(intervals, newInt);

            Graph gr = new Graph(7, true);

            gr.Add_Edge(0, 1);

            gr.Add_Edge(0, 2);

            gr.Add_Edge(0, 3);

            gr.Add_Edge(1, 0);

            gr.Add_Edge(1, 5);

            gr.Add_Edge(2, 5);

            gr.Add_Edge(3, 0);

            gr.Add_Edge(3, 4);

            gr.Add_Edge(4, 6);

            gr.Add_Edge(5, 1);

            gr.Add_Edge(6, 5);

            Console.Write("Depth First Traversal from vertex 2:\n");

            gr.DepthFirstSearch(2);


        }
    }
}