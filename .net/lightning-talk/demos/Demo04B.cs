using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo04B")]
    class Demo04B : DemoBase, IConsoleCommand
    {
        public void Execute(CommandArgs args)
        {
            int _x = 0, _y = 0;
            Console.CursorVisible = false;
            Console.Clear();

            var sub = redis.GetSubscriber();

            sub.Subscribe("positions", (channel, msg) =>
            {
                var pos = (string)msg;
                var tmp = pos.Split(',');

                int x = int.Parse(tmp[0]);
                int y = int.Parse(tmp[1]);

                Console.SetCursorPosition(x, y);
                Console.Write('@');

                if (x != _x || y != _y)
                {
                    Console.SetCursorPosition(_x, _y);
                    Console.Write(' ');
                }

                _x = x;
                _y = y;
            });

            Console.ReadKey();
        }
    }
}
