using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionMultiplexer.Connect("krist00fer.redis.cache.windows.net,ssl=true,password=CMwYYbUF7e2ZyYZcXK0JR65XRrqBpCzbDrNwi1bHH5k=");
            var cache = connection.GetDatabase();

            cache.StringSet("gametitle", "Hitman");

            var entries = cache.HashGetAll("agent:47");

            foreach (var entry in entries)
            {
                Console.WriteLine("{0}: {1}", entry.Name, entry.Value);
            }
        }
    }
}
