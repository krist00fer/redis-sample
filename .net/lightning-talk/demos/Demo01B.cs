using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo01B")]
    class Demo01B : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            while (true)
            {
                var quote = db.StringGet("quote");

                ConsoleX.WriteLine("Current quote is:");
                ConsoleX.WriteLine("  {0}", quote);
                ConsoleX.WriteLine();

                Thread.Sleep(3000);
            }
        }
    }
}
