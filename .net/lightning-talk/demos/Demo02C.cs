using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo02C")]
    class Demo02C : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.WriteLine("Press <L> or <R> to POP from quotelist from Left or Right\r\n");

            while(true)
            {
                var key = Console.ReadKey(true);

                string quote;

                if (key.Key == ConsoleKey.L)
                {
                    Console.WriteLine("(LPOP)");
                    quote = cache.ListLeftPop("quotelist");
                }
                else if (key.Key == ConsoleKey.R)
                {
                    Console.WriteLine("(RPOP)");
                    quote = cache.ListRightPop("quotelist");
                }
                else
                {
                    quote = "INCORRECT KEY PRESSED";
                }

                Console.WriteLine("  {0}\r\n", quote);
            }   
        }
    }
}
