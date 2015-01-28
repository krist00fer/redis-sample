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
            while (true)
            {
                var quote = db.StringGet("quote");

                Console.WriteLine("Current quote is:\r\n  {0}\r\n", quote);

                Thread.Sleep(3000);
            }
        }
    }
}
