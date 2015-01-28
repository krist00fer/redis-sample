using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo01A")]
    class Demo01A : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            var quotes = ReadQuotesFromFile();

            while (true)
            {
                var quote = quotes.Random();
                Console.WriteLine("Quote for the next 10 seconds is:\r\n  {0}\r\n", quote);

                cache.StringSet("quote", quote);

                Thread.Sleep(10000);
            }
        }
    }
}
