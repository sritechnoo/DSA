using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._130SurroundedRegions
{
    public class Solution
    {
        public void Solve(char[][] board)
        {
            new DFSApproach().Solve(board);
        }
    }

    public class DFSApproach
    {
        public void Solve(char[][] board)
        {
            int rowLength = board.Length;
            int colLength = board[0].Length;


            //'O' to 'T' for Borders
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (
                        (r == 0 || r == rowLength - 1)
                        && (c == 0 || c == colLength - 1)
                        && board[r][c] == 'O'
                        )
                    {
                        DFS(board, r, c);
                    }
                }
            }

            //'O' to 'X' for other than Borders
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (board[r][c] == 'O')
                    {
                        board[r][c] = 'X';
                    }
                }
            }

            //'T' to 'O' for reverting Borders
            for (int r = 0; r < rowLength; r++)
            {
                for (int c = 0; c < colLength; c++)
                {
                    if (board[r][c] == 'T')
                    {
                        board[r][c] = '0';
                    }
                }
            }
        }

        List<(int, int)> directions = new List<(int, int)> { (0, -1), (0, 1), (-1, 0), (1, 0) };

        private void DFS(char[][] board, int ux, int uy)
        {
            int rowLength = board.Length;
            int colLength = board[0].Length;

            if ((ux < 0 && ux == rowLength)
                && (uy < 0 && uy == colLength)
                && board[ux][uy] != 'O'
               )
            {
                return;
            }

            board[ux][uy] = 'T';
            foreach (var direction in directions)
            {
                int vx = ux + direction.Item1;
                int vy = uy + direction.Item2;

                DFS(board, vx, vy);
            }
        }
    }
}
