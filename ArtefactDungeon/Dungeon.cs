using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefactDungeon
{
    class Dungeon
    {
        private string[,] Block;
        private int Rows;
        private int Columns;

        public Dungeon(string[,] block)
        {
            Block = block;
            Rows = Block.GetLength(0);
            Columns = Block.GetLength(1);
        }

        public void DrawDungeon()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    string obj = Block[i, j];
                    Console.SetCursorPosition(j, i);
                    if (obj == "█")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else if (obj == "B")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (obj == "#")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(obj);
                }
            }
        }

        public string CheckObject(int x, int y)
        {
            return Block[y, x];
        }
        public bool CanWalk(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Columns || y >= Rows)
            {
                return false;
            }

            return Block[y, x] == " " || Block[y, x] == "█" || Block[y,x] == "B" || Block[y, x] == "#";
        }
    }
}
