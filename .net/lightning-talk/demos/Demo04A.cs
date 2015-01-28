using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo04A")]
    class Demo04A : DemoBase, IConsoleCommand
    {
        Random _rnd = new Random();

        public void Execute(CommandArgs args)
        {
            int x = 10, y = 10;

            Console.CursorVisible = false;
            Console.Clear();

            var sub = redis.GetSubscriber();

            while (true)
            {
                x += GetRandomPositionDiff();
                y += GetRandomPositionDiff();

                if (x < 0)
                    x = 0;
                else if (x >= 20)
                    x = 19;

                if (y < 0)
                    y = 0;
                else if (y >= 20)
                    y = 19;

                string pos = string.Format("{0},{1}", x, y);
                Console.WriteLine(pos);

                sub.Publish("positions", pos);

                Thread.Sleep(50);
            }
        }

        private int GetRandomPositionDiff()
        {
            var r = _rnd.Next(100);

            if (r < 10)
                return -1;
            else if (r >= 90)
                return 1;
            else
                return 0;
        }
    }
}
