using CooplandGameDataParser.Core.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooplandGameDataParser.Core.Abstractions
{
    public interface ICooplandGameDataParserHandler
    {
        event EventHandler<CooplandGameDataArgs> OnGameReceived;

        Task StartAsync();
    }
}
