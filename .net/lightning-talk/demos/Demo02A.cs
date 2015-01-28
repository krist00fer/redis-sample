using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo02A")]
    class Demo02A : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            // Clear list if old items
            cache.KeyDelete("quotelist");

            Console.WriteLine("Pushing 10 quotes to 'quotelist' (10x RPOP)\r\n");

            var quotes = ReadQuotesFromFile();

            for (int i = 0; i < 10; i++)
            {
                var quote = quotes.Random();

                Console.WriteLine("  {0}\r\n", quote);

                cache.ListRightPush("quotelist", quote);
            }

        }
    }
}
