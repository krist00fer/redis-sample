using ConsoleTools;
using lightning_talk.demos;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lightning_talk
{
    class Program
    {
        //private static ConnectionMultiplexer _connection;
        //private static IDatabase _cache;

        static void Main(string[] args)
        {
            ConsoleHelper.RegisterCommand<Demo01A>();
            ConsoleHelper.RegisterCommand<Demo01B>();
            ConsoleHelper.RegisterCommand<Demo02A>();
            ConsoleHelper.RegisterCommand<Demo02B>();
            ConsoleHelper.RegisterCommand<Demo02C>();
            ConsoleHelper.RegisterCommand<Demo03A>();
            ConsoleHelper.RegisterCommand<Demo03B>();
            ConsoleHelper.RegisterCommand<Demo05A>();
            ConsoleHelper.RegisterCommand<Demo05B>();

            ConsoleHelper.ProcessCommand(args);
        }
    }
}
