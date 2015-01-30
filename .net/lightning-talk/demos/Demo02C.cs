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
            Console.Clear();
            Console.CursorVisible = false;

            Console.WriteLine("Press <L> or <R> to POP from quotelist from Left or Right\r\n");

            while(true)
            {
                var key = Console.ReadKey(true);

                string quote;

                if (key.Key == ConsoleKey.L)
                {
                    ConsoleX.WriteLine("(LPOP)");
                    quote = db.ListLeftPop("quotelist");
                }
                else if (key.Key == ConsoleKey.R)
                {
                    ConsoleX.WriteLine("(RPOP)");
                    quote = db.ListRightPop("quotelist");
                }
                else
                {
                    quote = "INCORRECT KEY PRESSED";
                }

                ConsoleX.WriteLine("  {0}", quote);
                ConsoleX.WriteLine();
            }   
        }
    }
}
