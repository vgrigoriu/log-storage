using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace db
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Database().Run();
        }
    }
}
