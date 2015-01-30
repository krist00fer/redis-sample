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
                string quote = db.ListRightPopLeftPush("quotequeue", "processingquotes");

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
                        ConsoleX.WriteLine();
                        ConsoleX.WriteLine();
                        ConsoleX.WriteLine("WARNING        -    Process simulated a crash during proccessing of quote");
                        Thread.Sleep(5000);
                        ConsoleX.WriteLine("INFORMATION    -    Recovering from simulated crash and continuing processing of quotes\r\n");
                        Console.ForegroundColor = c;
                    }
                    else
                    {
                        ConsoleX.WriteLine();
                        ConsoleX.WriteLine("  {0}", quote.ToUpper());
                        // Simulate light work load by sleeping for 300ms
                        Thread.Sleep(300);
                        db.StringIncrement("processedquotes", 1);
                        db.ListRemove("processingquotes", quote);
                    }
                }
            }

        }
    }
}
