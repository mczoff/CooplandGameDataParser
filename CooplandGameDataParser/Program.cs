using CooplandGameDataParser.Core;
using CooplandGameDataParser.Core.Params;
using CooplandGameDataParser.MongoHandler.Params;
using CooplandGameDataParser.MongoHandler.Models;
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
            ICooplandGameDataParserContext context = new CooplandGameDataParserContext(new CooplandGameDataParserContextParams
            {
                Handler = new MongoHandler.Models.MongoHandler(new MongoHandlerParams
                {
                    ConnectionString = "mongodb://localhost:27017",
                    DatabaseName = "gameAdvisorDb"
                })
            });
            await context.StartAsync();
        }
    }
}
