using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooplandGameDataParser.Core
{
    public interface ICooplandGameDataParserContext
    {
        Task StartAsync();
        Task StopAsync();
    }
}
