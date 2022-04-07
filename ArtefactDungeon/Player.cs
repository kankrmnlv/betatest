using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefactDungeon
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string playerSymbol;
        private ConsoleColor playerSymbolColor;

        public Player(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            playerSymbol = "O";
            playerSymbolColor = ConsoleColor.Red;
        }

        public void DrawPlayer()
        {
            Console.ForegroundColor = playerSymbolColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(playerSymbol);
            Console.ResetColor();
        }
    }
}
