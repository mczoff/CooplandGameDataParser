using CooplandGameDataParser.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooplandGameDataParser.Core.Args
{
    public class CooplandGameDataArgs
        : EventArgs
    {
        public GameInfoModel Game { get; set; }
    }
}
