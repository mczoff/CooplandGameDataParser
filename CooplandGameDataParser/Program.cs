using CooplandGameDataParser.Core;
using CooplandGameDataParser.Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooplandGameDataParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ICooplandGameDataParserContext context = new CooplandGameDataParserContext(new CooplandGameDataParserContextParams { ThreadsCount = 1 });
            await context.StartAsync();
        }
    }
}
