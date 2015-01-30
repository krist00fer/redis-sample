using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo03A")]
    class Demo03A : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.CursorVisible = false;
            Console.Clear();

            // Clear cache of old items
            db.KeyDelete("quotequeue");
            db.KeyDelete("processedquotes");
            db.KeyDelete("processingquotes");

            ConsoleX.WriteLine("Press <Q> to add single quote");
            ConsoleX.WriteLine("Press <W> to add 30 quotes");
            ConsoleX.WriteLine("Press <E> to show number of processed quotes");
            ConsoleX.WriteLine("Press <R> to re-process quotes that failed to be processed");

            var quotes = ReadQuotesFromFile();

            while(true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                {
                    var quote = quotes.Random();
                    db.ListLeftPush("quotequeue", quote);
                    ConsoleX.WriteLine("  {0}", quote);
                }
                else if (key.Key == ConsoleKey.W)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        var quote = quotes.Random();
                        db.ListLeftPush("quotequeue", quote);
                        if (i % 10 == 0)
                            Console.Write(".");
                    }
                }
                else if (key.Key == ConsoleKey.E)
                {
                    ConsoleX.WriteLine("Processed quotes: {0}", db.StringGet("processedquotes"));
                }
                else if (key.Key == ConsoleKey.R)
                {
                    string q;
                    int i = -1;

                    do
                    {
                        q = db.ListRightPopLeftPush("processingquotes", "quotequeue");
                        i++;
                    } 
                    while (!string.IsNullOrEmpty(q));

                    ConsoleX.WriteLine("Re-processing {0} quotes", i);
                }


                ConsoleX.WriteLine();
            }   
        }
    }
}
