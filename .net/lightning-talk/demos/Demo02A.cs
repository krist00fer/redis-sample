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
            Console.Clear();
            Console.CursorVisible = false;

            // Clear list if old items
            db.KeyDelete("quotelist");

            ConsoleX.WriteLine("Pushing 10 quotes to 'quotelist' (10x RPOP)");
            ConsoleX.WriteLine();

            var quotes = ReadQuotesFromFile();

            for (int i = 0; i < 10; i++)
            {
                var quote = quotes.Random();

                db.ListRightPush("quotelist", quote);

                ConsoleX.WriteLine("  {0}", quote);
                ConsoleX.WriteLine();

            }

        }
    }
}
