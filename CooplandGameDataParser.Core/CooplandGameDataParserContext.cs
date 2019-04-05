using CooplandGameDataParser.Core.Models;
using CooplandGameDataParser.Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooplandGameDataParser.Core
{
    public class CooplandGameDataParserContext
        : ICooplandGameDataParserContext
    {
        readonly CooplandGameDataParserContextParams _params;

        public CooplandGameDataParserContext(CooplandGameDataParserContextParams @params)
        {
            _params = @params;
        }

        public async Task StartAsync()
        {
            await new CooplandGameDataParserHandler().StartAsync();
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
