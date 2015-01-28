using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lightning_talk.demos
{
    public abstract class DemoBase
    {
        private static Random _rnd = new Random();

        /*"krist00fer.redis.cache.windows.net,ssl=true,password=CMwYYbUF7e2ZyYZcXK0JR65XRrqBpCzbDrNwi1bHH5k="*/
        protected IDatabase cache = ConnectionMultiplexer.Connect("localhost").GetDatabase();

        public string[] ReadQuotesFromFile()
        {
            return File.ReadAllLines("quotes.txt");
        }

        public bool CrashSimulated()
        {
            return _rnd.Next(100) < 5; // Simulate crash 5% of the times
        }
    }

    public static class DemoExtensions
    {
        private static Random _rnd = new Random();
        public static string Random(this string[] array)
        {
            return array[_rnd.Next(array.Length - 1)];
        }
    }
}
