using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._200NumberofIslands
{
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            //return new DFSApproach().NumIslands(grid);
            //return new BFSApproach().NumIslands(grid);
            return new DisJointSetApproach().NumIslands(grid);
        }
    }

    public class DFSApproach
    {
        private static int[][] directions =
        {
            new int[] { -1,0 },
            new int[] { 1,0 },
            new int[] { 0,-1 },
            new int[] { 0,1 },
        };

        public int NumIslands(char[][] grid)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            int numOfIslands = 0;
            bool[,] visited = new bool[rowLength, colLength];

            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (visited[r, c] == false && grid[r][c] == '1')
                    {
                        DFS(grid, visited, r, c);

                        numOfIslands++;
                    }
                }
            }

            return numOfIslands;
        }

        private void DFS(char[][] grid, bool[,] visited, int x, int y)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            visited[x, y] = true;

            foreach (var direction in directions)
            {
                var newx = x + direction[0];
                var newy = y + direction[1];

                if (
                    (newx >= 0 && newx < rowLength)
                    && (newy >= 0 && newy < colLength)
                    && visited[newx, newy] == false
                    && grid[newx][newy] == '1'
                )
                {
                    DFS(grid, visited, newx, newy);
                }
            }
        }
    }

    public class BFSApproach
    {
        private static int[][] directions =
        {
            new int[] { -1,0 },
            new int[] { 1,0 },
            new int[] { 0,-1 },
            new int[] { 0,1 },
        };

        public int NumIslands(char[][] grid)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            int numOfIslands = 0;
            bool[,] visited = new bool[rowLength, colLength];

            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (visited[r, c] == false && grid[r][c] == '1')
                    {
                        BFS(grid, visited, r, c);

                        numOfIslands++;
                    }
                }
            }
            return numOfIslands;
        }

        private void BFS(char[][] grid, bool[,] visited, int x, int y)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            Queue<(int, int)> q = new Queue<(int, int)>();

            q.Enqueue((x, y));
            visited[x, y] = true;

            while (q.Count > 0)
            {
                (int, int) pair = q.Dequeue();
                foreach (var direction in directions)
                {
                    var newx = pair.Item1 + direction[0];
                    var newy = pair.Item2 + direction[1];

                    if (
                        (newx >= 0 && newx < rowLength)
                        && (newy >= 0 && newy < colLength)
                        && visited[newx, newy] == false
                        && grid[newx][newy] == '1'
                    )
                    {
                        q.Enqueue((newx, newy));
                        visited[newx, newy] = true;
                    }
                }
            }
        }
    }

    public class DisJointSetApproach
    {
        private List<(int, int)> directions = new List<(int, int)> { (0, -1), (0, 1), (-1, 0), (1, 0) };

        private int GetCellNumber(int x, int y, int rowLength, int colLength)
        {
            return colLength * x + y;
        }

        public int NumIslands(char[][] grid)
        {
            int rowLength = grid.Length;
            int colLength = grid[0].Length;

            DisJointSet disJointSet = new DisJointSet(rowLength * colLength);
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    int uCellNumber = this.GetCellNumber(r, c, rowLength, colLength);
                    
                    if (grid[r][c] == '1')
                    {
                        foreach (var direction in directions)
                        {
                            var newr = r + direction.Item1;
                            var newc = c + direction.Item2;

                            if (
                                (newr >= 0 && newr < rowLength)
                                && (newc >= 0 && newc < colLength)
                                && grid[newr][newc] == '1'
                            )
                            {
                                int vCellNumber = this.GetCellNumber(newr, newc, rowLength, colLength);
                                disJointSet.Union(uCellNumber, vCellNumber);
                            }
                        }

                    }
                }
            }

            HashSet<int> connectedIsLands = new HashSet<int>();
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        int cellNumber = this.GetCellNumber(r, c, rowLength, colLength);
                        connectedIsLands.Add(disJointSet.FindParent(cellNumber));
                    }
                }
            }
            return connectedIsLands.Count;
        }

        /*
         * https://www.hackerearth.com/practice/notes/disjoint-set-union-union-find/
         * https://www.scaler.com/topics/data-structures/disjoint-set/
         */
        public class DisJointSet
        {
            private int componentCount;
            private int[] parentComponents;
            private int[] parentComponentSize;

            public DisJointSet(int N)
            {
                this.componentCount = N;
                this.parentComponents = new int[N];
                this.parentComponentSize = new int[N];
                for (int group = 0; group < N; group++)
                {
                    parentComponents[group] = group;
                    parentComponentSize[group] = 1;
                }
            }

            public int Count()
            {
                return componentCount;
            }

            public int[] GetParentComponents()
            {
                return parentComponents;
            }

            public int FindParent(int node)
            {
                if (node == parentComponents[node]) { return node; }

                return parentComponents[node] = FindParent(parentComponents[node]);
            }

            public bool Union(int u, int v)
            {
                int uParent = FindParent(u);
                int vParent = FindParent(v);

                if (uParent == vParent) { return false; }

                parentComponents[vParent] = uParent;
                componentCount--;

                return true;
            }

            public bool UnionWithSize(int u, int v)
            {
                int uGroup = FindParent(u);
                int vGroup = FindParent(v);

                if (uGroup == vGroup) { return false; }

                if (parentComponentSize[uGroup] > parentComponentSize[vGroup])
                {
                    parentComponents[vGroup] = uGroup;
                    parentComponentSize[uGroup] += vGroup;
                    componentCount--;
                }
                else
                {
                    parentComponents[uGroup] = vGroup;
                    parentComponentSize[vGroup] += uGroup;
                    componentCount--;
                }
                return true;
            }
        }
    }
}
