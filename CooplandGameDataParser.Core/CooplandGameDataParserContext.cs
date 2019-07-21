using CooplandGameDataParser.Core.Args;
using CooplandGameDataParser.Core.Models;
using CooplandGameDataParser.Core.Params;
using CooplandGameDataParser.DatabaseDefaultHandler.Abstractions;
using CooplandGameDataParser.DatabaseDefaultHandler.Models;
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
            CooplandGameDataParserHandler parserHandler = new CooplandGameDataParserHandler();

            parserHandler.OnGameReceived += async delegate (object sender, CooplandGameDataArgs args)
            {
                await _params.Handler.AddAsync(GameInfoTO(args.Game));
            };

            await parserHandler.StartAsync();
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }

        private static GameInfo GameInfoTO(GameInfoModel gameInfoModel)
            => new GameInfo
            {
                Description = gameInfoModel.Description,
                Developer = gameInfoModel.Developer,
                Genre = gameInfoModel.Genre,
                Language = gameInfoModel.Language,
                Name = gameInfoModel.Name,
                Platform = gameInfoModel.Platform,
                Rate = gameInfoModel.Rate,
                Release = gameInfoModel.Release
            };
    }
}
