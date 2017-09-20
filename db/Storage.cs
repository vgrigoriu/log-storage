using System;
using System.IO;
using System.Threading.Tasks;

namespace db
{
    public class Storage
    {
        private readonly string fileName = "database.log";

        public async Task SetAsync(string key, string value)
        {
            using (var stream = File.Open(this.fileName, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteLineAsync($"{key},{value}");
            }
        }

        public Task<string> GetAsync(string key) => throw new NotImplementedException("No get yet");
    }
}