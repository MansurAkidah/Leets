using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets
{

    class Graph

    {

        private int _v;

        private bool _direct;

        LinkedList<int>[] _adj;

        public Graph(int v, bool direct)

        {

            _adj = new LinkedList<int>[v];

            for (int i = 0; i < _adj.Length; i++)

            {

                _adj[i] = new LinkedList<int>();

            }

            _v = v;

            _direct = direct;

        }

        public void Add_Edge(int v, int w)

        {

            _adj[v].AddLast(w);

            if (!_direct)

            {

                _adj[w].AddLast(v);

            }

        }

        public void DepthFirstSearch(int v)

        {

            // Mark all the vertices as not visited

            bool[] visit = new bool[_v];

            for (int i = 0; i < _v; i++)

                visit[i] = false;

            // Call the recursive function to print DFS traversal

            DFStil(v, visit);

        }

        private void DFStil(int v, bool[] visit)

        {

            // Mark the current node as visited and display it

            visit[v] = true;

            Console.Write(v + " ");

            // Recur for all the vertices adjacent to this vertex

            LinkedList<int> list = _adj[v];

            foreach (var value in list)

            {

                if (!visit[value])

                    DFStil(value, visit);

            }

        }

    }
}