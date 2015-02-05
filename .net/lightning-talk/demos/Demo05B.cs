using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using StackExchange.Redis;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo05B")]
    class Demo05B : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.CursorVisible = false;
         
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Highscore - Top 15 players");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();

                var scores = db.SortedSetRangeByRankWithScores("scores", 0, 15, Order.Descending);

                foreach (var score in scores)
                {
                    Console.WriteLine("  {0}   {1}", score.Score, score.Element);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
