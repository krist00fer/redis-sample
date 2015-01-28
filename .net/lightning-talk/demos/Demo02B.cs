using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo02B")]
    class Demo02B : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Listing quotes in list (LRANGE)\r\n");

                var quotes = cache.ListRange("quotelist", 0, -1);

                foreach (var quote in quotes)
                {
                    Console.WriteLine("  {0}\r\n", quote);
                }

                Thread.Sleep(1000);
            }

        }
    }
}
