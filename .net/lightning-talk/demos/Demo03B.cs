using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;
using StackExchange.Redis;

namespace lightning_talk.demos
{
    [Command("Demo03B")]
    class Demo03B : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.CursorVisible = false;
            Console.Clear();

            while (true)
            {
                string quote = cache.ListRightPopLeftPush("quotequeue", "processingquotes");

                if (string.IsNullOrEmpty(quote))
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }
                else
                {
                    // Simulate crash at 10% of times
                    if (CrashSimulated())
                    {
                        var c = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\r\n");
                        Console.WriteLine("WARNING        -    Process simulated a crash during proccessing of quote");
                        Thread.Sleep(5000);
                        Console.WriteLine("INFORMATION    -    Recovering from simulated crash and continuing processing of quotes\r\n");
                        Console.ForegroundColor = c;
                    }
                    else
                    {
                        Console.WriteLine("\r\n  {0}", quote.ToUpper());
                        // Simulate light work load by sleeping for 500ms
                        Thread.Sleep(500);
                        cache.StringIncrement("processedquotes", 1);
                        cache.ListRemove("processingquotes", quote);
                    }
                }
            }

        }
    }
}
