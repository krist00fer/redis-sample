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
            Console.Clear();
            Console.CursorVisible = false;

            var quotes = ReadQuotesFromFile();

            while (true)
            {
                var quote = quotes.Random();
                db.StringSet("quote", quote); 
                
                ConsoleX.WriteLine("Quote for the next 10 seconds is:");
                ConsoleX.WriteLine("  {0}", quote);
                ConsoleX.WriteLine();

                Thread.Sleep(10000);
            }
        }
    }
}
