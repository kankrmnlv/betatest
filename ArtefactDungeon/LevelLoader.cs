using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ArtefactDungeon
{
    class LevelLoader
    {
        public static string[,] LoadLevel(string level)
        {
            string[] lines = File.ReadAllLines(level);
            string line1 = lines[0];
            int rows = lines.Length;
            int columns = line1.Length;

            string[,] block = new string[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string line = lines[i];
                for (int j = 0; j < columns; j++)
                {
                    char curSymbol = line[j]; //current symbol
                    block[i, j] = curSymbol.ToString();
                }
            }
            return block;
        }
    }
}
