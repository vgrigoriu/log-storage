using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace db
{
    class Program
    {
        private static Database db = new Database();

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                await Handle(line);
            }
        }

        private static async Task Handle(string line)
        {
            var parts = line.Split();
            var command = parts[0];
            switch (command)
            {
                case "set":
                    await HandleSet(parts[1], parts[2]);
                    break;
                default:
                    DisplayHelp();
                    break;
            }
        }

        private static async Task HandleSet(string key, string value)
        {
            await db.SetAsync(key, value);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine(@"
Usage:
    set <key> <value>
        stores the pair key, value
    get <key>
        return the value associated with the key
    help
        displays this help message");
        }
    }
}
