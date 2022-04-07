using System;

namespace ArtefactDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Kazakh Dungeon";
            Gameplay game = new Gameplay();
            //game.IntroductionLevel();
            //game.SecondLevel();
            game.ThirdLevel();
        }
    }
}
