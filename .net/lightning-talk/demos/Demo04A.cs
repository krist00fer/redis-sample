using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo04A")]
    class Demo04A : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.CursorVisible = false;
            Console.Clear();

            Console.WriteLine("Simulating player scores\r\n");

            var users = ReadUserNamesFromFile();

            while (true)
            {
                var user = users.Random();
                var score = GetRandomScore();

                Console.WriteLine("  {0}, {1} points", user, score);

                cache.SortedSetAdd("scores", user, score);

                Thread.Sleep(200);
            }
        }
    }
}
