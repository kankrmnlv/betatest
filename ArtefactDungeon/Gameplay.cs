using System;
using System.Collections.Generic;
using System.Text;

namespace ArtefactDungeon
{
    class Gameplay
    {
        private Dungeon dungeon;
        private Player player;
        private Monster monster;
        private Item sword;
        Random random = new Random();
        private void Intro()
        {
            Console.WriteLine("Welcome to the 'Kazakh Dungeon'");
            Console.Write("**You are one of the best treasure hunters in the world. You got a mission to " +
                "\nfind the rarest diamond ever existed. You arrived to the dungeon to look for the treasure." +
                "\nChallenge yourself with dungeons quests, mazes and monsters. Obtain the treasure and safely escape." +
                "\nGood luck and have fun!**");
            Console.WriteLine("\n\nPress any key to continue\n>>");
            Console.ReadKey(true);
            Console.Clear();
        }
        private void Draw()
        {
            dungeon.DrawDungeon();
            player.DrawPlayer();
        }
        private void Movement()
        {
            // Read the latest key input
            ConsoleKey input;
            do
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);
                input = keyInput.Key;
            } while (Console.KeyAvailable);
            
            switch (input)
            {
                case ConsoleKey.W:
                    if (dungeon.CanWalk(player.X, player.Y - 1))
                    {
                        player.Y -= 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (dungeon.CanWalk(player.X - 1, player.Y))
                    {
                        player.X -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (dungeon.CanWalk(player.X, player.Y + 1))
                    {
                        player.Y += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (dungeon.CanWalk(player.X + 1, player.Y))
                    {
                        player.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        public void MonsterScript()
        {
            switch(random.Next(1, 5))
            {
                case 1:
                    if (dungeon.CanWalk(monster.X, monster.Y - 1))
                    {
                        monster.Y -= 1;
                    }
                    break;
                case 2:
                    if (dungeon.CanWalk(monster.X - 1, monster.Y))
                    {
                        monster.X -= 1;
                    }
                    break;
                case 3:
                    if (dungeon.CanWalk(monster.X, monster.Y + 1))
                    {
                        monster.Y += 1;
                    }
                    break;
                case 4:
                    if (dungeon.CanWalk(monster.X + 1, monster.Y))
                    {
                        monster.X += 1;
                    }
                    break;
            }
        }

        public void IntroductionLevel()
        {
            Console.CursorVisible = false;

            string[,] block = LevelLoader.LoadLevel("IntroLevel.txt");
            dungeon = new Dungeon(block);

            player = new Player(5, 3);

            Intro();
            Console.SetCursorPosition(0, 18);
            Console.Write("**You appear in a labyrnith. Find a way out!**");
            Console.Write("\n\nIntroduction level: Try out the moving system." +
                "\nUse WASD buttons. W - up, D - right, A - left, S - down." +
                "\nGet to the exit which is showns as >>");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" █");
            Console.ResetColor();

            while (true)
            {
                Draw();
                Movement();

                string checkBlock = dungeon.CheckObject(player.X, player.Y);
                if (checkBlock == "█")
                {
                    break;
                }

                System.Threading.Thread.Sleep(20);
            }
            Console.Clear();
            Console.WriteLine("**Good job! You escaped the labyrinth!**" +
                "\n\nPress 'Enter' to proceed");
            Console.ReadLine();
        }
        
        public void SecondLevel()
        {
            Console.Clear();
            Console.CursorVisible = false;

            string[,] block = LevelLoader.LoadLevel("Level2.txt");
            dungeon = new Dungeon(block);

            player = new Player(5, 1);

            Console.SetCursorPosition(0, 17);
            Console.WriteLine("**You appear in another labyrnith. You see the exit but its blocked...**" +
                "\n**You must find a path that leads to the exit.**");
            Console.Write("\n\nLevel 2: Interact with the world." +
                "Your goal is to press on a button, shown as >>");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" B");
            Console.ResetColor();
            Console.Write("Step on it and it will open a path to the exit. " +
                "Avoid traps, if you step on them = instant lose. Shown as >> ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" #");
            Console.ResetColor();
            Console.WriteLine("Good luck and be careful, the button will spawn another bunch of traps!");
            while (true)
            {
                Draw();
                Movement();

                string checkBlock = dungeon.CheckObject(player.X, player.Y);
                if (checkBlock == "#")
                {
                    Console.Clear();
                    Console.WriteLine("**You got into the trap. You lost...**");
                    break;
                }
                else if (checkBlock == "B")
                {
                    block = LevelLoader.LoadLevel("Level2Ext.txt");
                    dungeon = new Dungeon(block);
                    player = new Player(4, 15);
                    while (true)
                    {
                        Draw();
                        Movement();
                        checkBlock = dungeon.CheckObject(player.X, player.Y);
                        if (checkBlock == "█")
                        {
                            Console.Clear();
                            Console.WriteLine("**Good job! You have escaped another maze.**" +
                                "\n\nPress 'Enter' to proceed to Level 3.");
                            Console.ReadLine();
                            break;
                        }
                    }
                    break;
                }
                System.Threading.Thread.Sleep(20);
            }
        }

        public void ThirdLevel()
        {
            Console.Clear();
            Console.CursorVisible = false;

            string[,] block = LevelLoader.LoadLevel("Level3.txt");
            dungeon = new Dungeon(block);
            player = new Player(1, 1);
            monster = new Monster(random.Next(1, block.GetLength(1) - 1), random.Next(1, block.GetLength(0) - 1));
            while (true)
            {
                Draw();
                monster.DrawMonster();
                Movement();
                MonsterScript();
                string checkBlock = dungeon.CheckObject(player.X, player.Y);
                if (checkBlock == "#")
                {
                    Console.Clear();
                    Console.WriteLine("**You got into the trap. You lost...**");
                    break;
                }
            }
            System.Threading.Thread.Sleep(20);
        }
    }
}
