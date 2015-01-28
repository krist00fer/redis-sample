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
            db.KeyDelete("scores");

            Console.CursorVisible = false;
         
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Highscore - Top 25 players");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();

                var scores = db.SortedSetRangeByRankWithScores("scores", 0, 25, Order.Descending);

                foreach (var score in scores)
                {
                    Console.WriteLine("  {0}   {1}", score.Score, score.Element);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
