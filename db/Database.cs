using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace db
{
    public class Database
    {
        private Storage db = new Storage();

        public async Task Run()
        {
            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                await Handle(line);
            }
        }

        private async Task Handle(string line)
        {
            var parts = line.Split();
            var command = parts[0];
            switch (command)
            {
                case "quit":
                    Environment.Exit(0);
                    break;
                case "set":
                    await HandleSet(parts[1], parts[2]);
                    break;
                case "get":
                    await HandleGet(parts[1]);
                    break;
                default:
                    DisplayHelp();
                    break;
            }
        }

        private async Task HandleSet(string key, string value)
        {
            await db.SetAsync(key, value);
        }

        private async Task HandleGet(string key)
        {
            var value = await db.GetAsync(key);
            Console.WriteLine(value);
        }

        private void DisplayHelp()
        {
            Console.WriteLine(@"
Usage:
    set <key> <value>
        stores the pair key, value
    get <key>
        return the value associated with the key
    quit
        quit this wonderful program
    help
        displays this help message");
        }
    }
}
