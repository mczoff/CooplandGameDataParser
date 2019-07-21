using CooplandGameDataParser.DatabaseDefaultHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooplandGameDataParser.DatabaseDefaultHandler.Abstractions
{
    public interface IDatabaseHandler
    {
        Task AddAsync(GameInfo gameInfo);
    }
}
