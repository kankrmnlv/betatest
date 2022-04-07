using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefactDungeon
{
    class Monster
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string monsterSymbol;
        private ConsoleColor monsterSymbolColor;

        public Monster(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            monsterSymbol = "M";
            monsterSymbolColor = ConsoleColor.Blue;
        }

        public void DrawMonster()
        {
            Console.ForegroundColor = monsterSymbolColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(monsterSymbol);
            Console.ResetColor();
        }
    }
}
