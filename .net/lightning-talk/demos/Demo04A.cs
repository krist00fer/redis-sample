using ConsoleTools.Attributes;
using ConsoleTools.Commands;
using System;
using System.Threading;

namespace lightning_talk.demos
{
    [Command("Demo04A")]
    class Demo04A : DemoBase, IConsoleCommand
    {
        private const int maxX = 40;
        private const int maxY = 30;

        Random _rnd = new Random();

        public void Execute(CommandArgs args)
        {
            int x = maxX / 2, y = maxY / 2;

            Console.CursorVisible = false;
            Console.Clear();

            var sub = redis.GetSubscriber();

            while (true)
            {
                x += GetRandomPositionDiff();
                y += GetRandomPositionDiff();

                if (x < 0)
                    x = 0;
                else if (x >= maxX)
                    x = maxX - 1;

                if (y < 0)
                    y = 0;
                else if (y >= maxY)
                    y = maxY - 1;

                string pos = string.Format("{0},{1}", x, y);
                Console.WriteLine(pos);

                sub.Publish("positions", pos);

                Thread.Sleep(100);
            }
        }

        private int GetRandomPositionDiff()
        {
            var r = _rnd.Next(100);

            if (r < 10)
                return -2;
            if (r < 20)
                return -1;
            if (r < 80)
                return 0;
            if (r < 90)
                return 1;

            return 2;
        }
    }
}
