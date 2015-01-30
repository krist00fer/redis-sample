using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo05A")]
    class Demo05A : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.CursorVisible = false;
            Console.Clear();

            db.KeyDelete("scores");

            ConsoleX.WriteLine("Simulating player scores");
            ConsoleX.WriteLine();

            var users = ReadUserNamesFromFile();

            while (true)
            {
                var user = users.Random();
                var score = GetRandomScore();

                ConsoleX.WriteLine("  {0}, {1} points", user, score);

                db.SortedSetAdd("scores", user, score);

                Thread.Sleep(300);
            }
        }
    }
}
