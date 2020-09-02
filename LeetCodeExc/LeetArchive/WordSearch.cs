using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExc
{
    class WordSearch : IRunnable
    {
        public void Run()
        {
            var board = new char[][]
            {
                new char[] { 'A', 'B', 'C', 'E'},
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            };
            
            RunWith(board, "CESCE");
            RunWith(board, "ABCCED");
            RunWith(board, "SEE");
            RunWith(board, "ABCB");
        }

        private void RunWith(char[][] board, string word)
        {
            var result = Exist(board, word);
            Console.WriteLine($"       Result of [{word}]: {result}");
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"");
        }

        private void PrintBoardMatrix(BoardItem[][] boardMatrix)
        {
            if (boardMatrix.Length == 0 || boardMatrix[0].Length == 0)
                return;

            var lengthX = boardMatrix[0].Length;
            var lengthY = boardMatrix.Length;

            for (int y = 0; y < lengthY; y++)
            {
                Console.Write("       ");
                for (int x = 0; x < lengthX; x++)
                {
                    Console.Write($"{boardMatrix[y][x]}  ");
                }
                Console.WriteLine();
            }
        }

        public bool Exist(char[][] board, string word)
        {
            var boardMatrix = BuildBoardItemMatrix(board);

            if (boardMatrix == null)
                return false;

            var lengthX = board[0].Length;
            var lengthY = board.Length;
            var found = false;

            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    var item = boardMatrix[y][x];
                    if (item.letter == word[0])
                    {
                        found = MoveNext(item, word, 0);
                        if (found)
                            break;
                    }
                }

                if (found)
                    break;
            }

            PrintBoardMatrix(boardMatrix);
            return found;
        }

        private BoardItem[][] BuildBoardItemMatrix(char[][] board)
        {
            if (board.Length == 0 || board[0].Length == 0)
                return null;

            var lengthX = board[0].Length;
            var lengthY = board.Length;
            var boardMatrix = new BoardItem[lengthY][];

            // init board matrix
            for (int y = 0; y < lengthY; y++)
            {
                boardMatrix[y] = new BoardItem[lengthX];

                for (int x = 0; x < lengthX; x++)
                {
                    boardMatrix[y][x] = new BoardItem(board[y][x]);
                }
            }

            // set neighbors on board matrix
            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    var item = boardMatrix[y][x];
                    item.left = x > 0 ? boardMatrix[y][x - 1] : null;
                    item.top = y > 0 ? boardMatrix[y - 1][x] : null;
                    item.right = x < lengthX - 1 ? boardMatrix[y][x + 1] : null;
                    item.bottom = y < lengthY - 1 ? boardMatrix[y + 1][x] : null;
                }
            }

            return boardMatrix;
        }

        private bool MoveNext(BoardItem current, string word, int wordPos)
        {
            current.isUsed = true;
            
            if (++wordPos >= word.Length)
                return true;

            var nextLetter = word[wordPos];
            var found = false;

            if (current.right != null && current.right.IsValidFor(nextLetter))
                found = MoveNext(current.right, word, wordPos);

            if (!found && current.bottom != null && current.bottom.IsValidFor(nextLetter))
                found = MoveNext(current.bottom, word, wordPos);

            if (!found && current.left != null && current.left.IsValidFor(nextLetter))
                found = MoveNext(current.left, word, wordPos);

            if (!found && current.top != null && current.top.IsValidFor(nextLetter))
                found = MoveNext(current.top, word, wordPos);

            current.isUsed = found;
            return found;
        }
    }

    class BoardItem
    {
        public char letter;
        public BoardItem top;
        public BoardItem bottom;
        public BoardItem left;
        public BoardItem right;
        public bool isUsed;

        public BoardItem(char letter)
        {
            this.letter = letter;
        }

        public bool IsValidFor(char target)
        {
            return !isUsed && this.letter == target;
        }

        public override string ToString()
        {
            return $"{letter}[{(isUsed ? 'X' : ' ')}]";
        }
    }
}
